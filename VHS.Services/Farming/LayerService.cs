using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Farming;
using VHS.Services.Farming.DTO;
using VHS.Services.Common.DataGrid;
using VHS.Services.Common.DataGrid.Enums;
using VHS.Services.Farming.Helpers;

namespace VHS.Services.Farming
{
    public interface ILayerService
    {
        Task<IEnumerable<LayerDTO>> GetAllLayersAsync(Guid farmId);
        Task<LayerDTO?> GetLayerByIdAsync(Guid id);
        Task<PaginatedResult<LayerDTO>> GetLayersByRackAsync(Guid rackId, int page, int pageSize, string? sortLabel, SortDirectionEnum sortDirection, string? rackNamePrefix);
        Task<LayerDTO> CreateLayerAsync(LayerDTO layerDto);
        Task UpdateLayerAsync(LayerDTO layerDto);
        Task DeleteLayerAsync(Guid id);
        Task InsertLayersForRacksAsync(Guid farmId);
    }

    public class LayerService : ILayerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private static LayerDTO SelectLayerToDTO(Layer layer) => new LayerDTO
        {
            Id = layer.Id,
            RackId = layer.Rack.Id,
            TrayCountPerLayer = layer.Rack.TrayCountPerLayer,
            LayerNumber = layer.LayerNumber,
            Enabled = layer.Enabled
        };

        public async Task<IEnumerable<LayerDTO>> GetAllLayersAsync(Guid farmId)
        {
            var layers = await _unitOfWork.Layer.GetAllAsync(x=>x.Rack.Floor.FarmId == farmId);
            return layers.Select(l => new LayerDTO
            {
                Id = l.Id,
                RackId =l.Rack.Id,
                TrayCountPerLayer = l.Rack.TrayCountPerLayer,
                LayerNumber = l.LayerNumber
            });
        }

        public async Task<LayerDTO?> GetLayerByIdAsync(Guid id)
        {
            var layer = await _unitOfWork.Layer.GetByIdAsync(id);
            if (layer == null)
                return null;
            return SelectLayerToDTO(layer);
        }       

        public async Task<LayerDTO> CreateLayerAsync(LayerDTO layerDto)
        {
            var layer = new Layer
            {
                Id = layerDto.Id == Guid.Empty ? Guid.NewGuid() : layerDto.Id,
                RackId = layerDto.RackId,
                LayerNumber = layerDto.LayerNumber,
                AddedDateTime = DateTime.UtcNow,
            };

            await _unitOfWork.Layer.AddAsync(layer);
            await _unitOfWork.SaveChangesAsync();

            return SelectLayerToDTO(layer);
        }

        public async Task UpdateLayerAsync(LayerDTO layerDto)
        {
            var layer = await _unitOfWork.Layer.GetByIdAsync(layerDto.Id);
            if (layer == null)
                throw new Exception("Layer not found");

            layer.RackId = layerDto.RackId;
            layer.LayerNumber = layerDto.LayerNumber;
            _unitOfWork.Layer.Update(layer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteLayerAsync(Guid id)
        {
            var layer = await _unitOfWork.Layer.GetByIdAsync(id);
            if (layer == null)
                throw new Exception("Layer not found");

            layer.DeletedDateTime = DateTime.UtcNow;
            _unitOfWork.Layer.Update(layer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task InsertLayersForRacksAsync(Guid farmId)
        {
            var racks = await _unitOfWork.Rack.GetAllAsync(r => r.Floor.FarmId == farmId);

            if (racks == null || !racks.Any())
            {
                throw new ArgumentException("No racks available to assign layers for the given farm.");
            }

            var layersToInsert = new List<Layer>();
            var traysToInsert = new List<Tray>();

            int rackCount = 0;
            foreach (var rack in racks.OrderBy(x => x.Name))
            {
                rackCount++;
                var floor = await _unitOfWork.Floor.GetByIdAsync(rack.FloorId);
                if (floor == null)
                {
                    throw new Exception($"Floor not found for Rack {rack.Name}");
                }

                for (int layerNum = 1; layerNum <= rack.LayerCount; layerNum++)
                {
                    var newLayer = new Layer
                    {
                        Id = Guid.NewGuid(),
                        RackId = rack.Id,
                        LayerNumber = layerNum,
                        AddedDateTime = DateTime.UtcNow,
                    };
                    layersToInsert.Add(newLayer);
                }
            }

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                await _unitOfWork.Layer.AddRangeAsync(layersToInsert);
                await _unitOfWork.Tray.AddRangeAsync(traysToInsert);
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<PaginatedResult<LayerDTO>> GetLayersByRackAsync(Guid rackId, int page, int pageSize, string? sortLabel, SortDirectionEnum sortDirection, string? rackNamePrefix = "SK")
        {
            var query = _unitOfWork.Layer.Query()
                .Include(l => l.Rack)
                .Where(l => l.RackId == rackId);

            var projectedData = await query
                .Select(l => new
                {
                    l.Id,
                    l.RackId,
                    RackName = l.Rack.Name,
                    FloorName = l.Rack.Floor.Name,
                    l.LayerNumber,
                    l.Enabled,
                    l.AddedDateTime
                })
                .ToListAsync();

            var data = projectedData
                .OrderBy(l => l.LayerNumber)
                .Select(l => {
                return new LayerDTO
                {
                    Id = l.Id,
                    LayerNumber = l.LayerNumber,
                    Enabled = l.Enabled
                };
            }).ToList();

            var totalCount = data.Count;
            var items = data.Skip(page * pageSize).Take(pageSize).ToList();

            return new PaginatedResult<LayerDTO>
            {
                TotalCount = totalCount,
                Items = items
            };
        }
    }
}
