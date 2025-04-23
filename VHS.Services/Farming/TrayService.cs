using Microsoft.EntityFrameworkCore;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Farming;
using VHS.Services.Common;
using VHS.Services.Common.DataGrid.Enums;
using VHS.Services.Common.DataGrid;
using VHS.Services.Farming.DTO;

namespace VHS.Services.Farming
{
    public interface ITrayService
    {
        Task<IEnumerable<TrayDTO>> GetAllTraysAsync(Guid farmId);
        Task<TrayDTO?> GetTrayByIdAsync(Guid id);
        Task<TrayDTO> CreateTrayAsync(TrayDTO trayDto);
        Task UpdateTrayAsync(TrayDTO trayDto);
        Task DeleteTrayAsync(Guid id);
        Task InsertTraysForFarmAsync(Guid farmId);
        Task InsertTraysForLayerUsingDepthAsync(Rack rack, Layer layer);
        Task<PaginatedResult<TrayDTO>> GetTraysByStatusAsync(Guid trayStatus, int page, int pageSize, string? sortLabel, SortDirectionEnum sortDirection);
    }

    public class TrayService : ITrayService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private static TrayDTO SelectTrayToDTO(Tray x) => new TrayDTO
        {
            Id = x.Id,
            FarmId = x.FarmId,
            RFIDTag = x.RFIDTag,
            StatusId = x.StatusId
        };

        public async Task<IEnumerable<TrayDTO>> GetAllTraysAsync(Guid farmId)
        {
            var trays = await _unitOfWork.Tray.GetAllAsync(x => x.FarmId == farmId);
            return trays.Select(SelectTrayToDTO);
        }

        public async Task<TrayDTO?> GetTrayByIdAsync(Guid id)
        {
            var tray = await _unitOfWork.Tray.GetByIdAsync(id);
            if (tray == null)
                return null;
            return SelectTrayToDTO(tray);
        }

        public async Task<TrayDTO> CreateTrayAsync(TrayDTO trayDto)
        {
            var trayEntity = new Tray
            {
                Id = trayDto.Id == Guid.Empty ? Guid.NewGuid() : trayDto.Id,
                FarmId = trayDto.FarmId,
                RFIDTag = trayDto.RFIDTag,
                StatusId = trayDto.StatusId,
            };

            await _unitOfWork.Tray.AddAsync(trayEntity);
            await _unitOfWork.SaveChangesAsync();

            return new TrayDTO
            {
                Id = trayEntity.Id,
                FarmId = trayEntity.FarmId,
                RFIDTag = trayEntity.RFIDTag,
                StatusId = trayEntity.StatusId,
            };
        }

        public async Task UpdateTrayAsync(TrayDTO trayDto)
        {
            var tray = await _unitOfWork.Tray.GetByIdAsync(trayDto.Id);
            if (tray == null)
                throw new Exception("Tray not found");

            tray.RFIDTag = trayDto.RFIDTag;
            tray.StatusId = trayDto.StatusId;

            _unitOfWork.Tray.Update(tray);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTrayAsync(Guid id)
        {
            var tray = await _unitOfWork.Tray.GetByIdAsync(id);
            if (tray == null)
                throw new Exception("Tray not found");

            tray.DeletedDateTime = DateTime.UtcNow;
            _unitOfWork.Tray.Update(tray);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task InsertTraysForFarmAsync(Guid farmId)
        {
            var racks = await _unitOfWork.Rack.GetAllAsync(r => r.Floor.FarmId == farmId);
            if (racks == null || !racks.Any())
            {
                throw new Exception("No racks found for the specified farm.");
            }

            foreach (var rack in racks)
            {
                var layers = rack.Layers != null && rack.Layers.Any()
                             ? rack.Layers
                             : await _unitOfWork.Layer.GetAllAsync(l => l.RackId == rack.Id);
                foreach (var layer in layers)
                {
                    await InsertTraysForLayerUsingDepthAsync(rack, layer);
                }
            }
        }

        public async Task InsertTraysForLayerUsingDepthAsync(Rack rack, Layer layer)
        {
            if (rack == null)
                throw new ArgumentNullException(nameof(rack));
            if (layer == null)
                throw new ArgumentNullException(nameof(layer));
            if (layer.RackId != rack.Id)
                throw new Exception("The provided layer does not belong to the specified rack.");

            int depth = rack.TrayCountPerLayer;
            var traysToInsert = new List<Tray>();
            var trayStatesToInsert = new List<TrayCurrentState>();
            var now = DateTime.UtcNow;

            for (int depthNum = 1; depthNum <= depth; depthNum++)
            {
                var rfidTag = Guid.NewGuid().ToString().ToUpper();
                var trayId = Guid.NewGuid();

                var tray = new Tray
                {
                    Id = trayId,
                    FarmId = rack.Floor.FarmId,
                    RFIDTag = rfidTag,
                    AddedDateTime = now,
                    StatusId = GlobalConstants.TRAYSTATUS_INUSE,
                };
                traysToInsert.Add(tray);

                var trayState = new TrayCurrentState
                {
                    TrayId = trayId,
                    DestinationLayerId = layer.Id,
                    OrderOnLayer = depthNum,
                    CurrentPhaseId = GlobalConstants.TRAYPHASE_EMPTY,
                    AddedDateTime = now,
                    ModifiedDateTime = now
                };
                trayStatesToInsert.Add(trayState);
            }

            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Tray.AddRangeAsync(traysToInsert);
                await _unitOfWork.TrayCurrentState.AddRangeAsync(trayStatesToInsert);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<PaginatedResult<TrayDTO>> GetTraysByStatusAsync(Guid trayStatus, int page, int pageSize, string? sortLabel, SortDirectionEnum sortDirection)
        {
            var query = _unitOfWork.TrayCurrentState.Query().Where(t => t.CurrentPhaseId == trayStatus && t.Tray.DeletedDateTime == null && t.Tray.Farm.DeletedDateTime == null);

            var data = await query.Select(t => new TrayDTO
            {
                Id = t.Tray.Id,
                FarmId = t.Tray.FarmId,
                RFIDTag = t.Tray.RFIDTag,
                StatusId = t.Tray.StatusId,
                CurrentPhaseId = t.CurrentPhaseId
            }).ToListAsync();

            if (!string.IsNullOrWhiteSpace(sortLabel))
            {
                var propertyInfo = typeof(TrayDTO).GetProperty(sortLabel);
                if (propertyInfo != null)
                {
                    data = sortDirection == SortDirectionEnum.Ascending
                        ? data.OrderBy(t => propertyInfo.GetValue(t)).ToList()
                        : data.OrderByDescending(t => propertyInfo.GetValue(t)).ToList();
                }
                else
                {
                    data = data.OrderByDescending(t => t.Id).ToList();
                }
            }
            else
            {
                data = data.OrderByDescending(t => t.Id).ToList();
            }

            var totalCount = data.Count;
            var items = data.Skip(page * pageSize).Take(pageSize).ToList();

            return new PaginatedResult<TrayDTO>
            {
                TotalCount = totalCount,
                Items = items
            };
        }
    }
}
