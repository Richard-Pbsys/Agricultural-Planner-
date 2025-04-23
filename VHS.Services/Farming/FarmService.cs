using VHS.Data.Infrastructure;
using VHS.Data.Models.Farming;
using VHS.Services.Farming.DTO;

namespace VHS.Services.Farming
{
    public interface IFarmService
    {
        Task<IEnumerable<FarmDTO>> GetAllFarmsAsync();
        Task<FarmDTO?> GetFarmByIdAsync(Guid id);
        Task<IEnumerable<FarmTypeDTO>> GetAllFarmTypesAsync();
        Task<FarmDTO> CreateFarmAsync(FarmDTO farmDto);
        Task<FarmDTO> UpdateFarmAsync(FarmDTO farmDto);
        Task DeleteFarmAsync(Guid id);
    }

    public class FarmService : IFarmService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFloorService _floorService;
        private readonly IRackService _rackService;
        private readonly ILayerService _layerService;
        private readonly ITrayService _trayService;

        public FarmService(
            IUnitOfWork unitOfWork,
            IFloorService floorService,
            IRackService rackService,
            ILayerService layerService,
            ITrayService trayService
            )
        {
            _unitOfWork = unitOfWork;
            _floorService = floorService;
            _rackService = rackService;
            _layerService = layerService;
            _trayService = trayService;
        }

        private static FarmDTO MapFarmToDTO(Farm f) => new FarmDTO
        {
            Id = f.Id,
            Name = f.Name,
            Description = f.Description,
            FarmTypeId = f.FarmTypeId,
            FarmTypeName = f.FarmType?.Name ?? string.Empty,
            Floors = f.Floors?.Select(fl => new FloorDTO
            {
                Id = fl.Id,
                Name = fl.Name,
                FloorNumber = fl.FloorNumber,
                Enabled = fl.Enabled,
                Racks = fl.Racks?.Select(r => new RackDTO(r.Id, r.LayerCount)
                {
                    Id = r.Id,
                    Name = r.Name,
                    TypeId = r.TypeId,
                    TrayCountPerLayer = r.TrayCountPerLayer,
                    Enabled = r.Enabled,
                    TrayDepth = r.TrayCountPerLayer,
                    Layers = r.Layers?.Select(l => new LayerDTO
                    {
                        Id = l.Id,
                        LayerNumber = l.LayerNumber,
                        RackId = l.RackId,
                        Enabled = l.Enabled,
                        TrayCountPerLayer = r.TrayCountPerLayer,
                        Trays = l.Trays?.Select(t => new TrayCurrentStateDTO
                        {
                            OrderOnLayer = t.OrderOnLayer,
                            CurrentPhaseId = t.CurrentPhaseId,
                            SeededDateTimeUTC = t.SeededDateTimeUTC,                            
                        }).ToList() ?? new List<TrayCurrentStateDTO>()
                    }).ToList() ?? new List<LayerDTO>()
                }).ToList() ?? new List<RackDTO>()
            }).ToList() ?? new List<FloorDTO>()
        };

        public async Task<IEnumerable<FarmDTO>> GetAllFarmsAsync()
        {
            var farms = await _unitOfWork.Farm.GetAllAsync();
            return farms
                .OrderBy(f => f.Name)
                .Select(f => MapFarmToDTO(f));
        }


        public async Task<FarmDTO?> GetFarmByIdAsync(Guid id)
        {
            var farm = await _unitOfWork.Farm.GetByIdAsync(id);
            if (farm == null)
                return null;

            return MapFarmToDTO(farm);
        }

        public async Task<IEnumerable<FarmTypeDTO>> GetAllFarmTypesAsync()
        {
            var farmTypes = await _unitOfWork.FarmType.GetAllAsync();
            return farmTypes.Select(ft => new FarmTypeDTO
            {
                Id = ft.Id,
                Name = ft.Name,
                Description = ft.Description
            });
        }

        public async Task<FarmDTO> CreateFarmAsync(FarmDTO farmDto)
        {
            if (farmDto == null)
                throw new ArgumentNullException(nameof(farmDto));

            var farmId = farmDto.Id == Guid.Empty ? Guid.NewGuid() : farmDto.Id;

            var floors = farmId != Guid.Empty
                ? _floorService.GenerateDefaultFloors(farmId).ToList()
                : new List<Floor>();

            var farmEntity = new Farm
            {
                Id = farmId,
                Name = farmDto.Name,
                Description = farmDto.Description,
                FarmTypeId = farmDto.FarmTypeId,
                Floors = floors
            };

            try
            {
                await _unitOfWork.Farm.AddAsync(farmEntity);
                await _unitOfWork.SaveChangesAsync();

                await _rackService.InsertRacksForFarmAsync(farmEntity.Id, floors);
                await _layerService.InsertLayersForRacksAsync(farmEntity.Id);
                await _trayService.InsertTraysForFarmAsync(farmEntity.Id);
            }
            catch (Exception ex)
            {
                throw;
            }

            return MapFarmToDTO(farmEntity);
        }

        public async Task<FarmDTO> UpdateFarmAsync(FarmDTO farmDto)
        {
            var existingFarm = await _unitOfWork.Farm.GetByIdAsync(farmDto.Id);
            if (existingFarm == null)
            {
                throw new Exception("Farm not found");
            }

            existingFarm.Name = farmDto.Name;
            existingFarm.Description = farmDto.Description;
            existingFarm.FarmTypeId = farmDto.FarmTypeId;

            _unitOfWork.Farm.Update(existingFarm);
            await _unitOfWork.SaveChangesAsync();

            var resultDto = MapFarmToDTO(existingFarm);
            resultDto.FarmTypeName = existingFarm.FarmType?.Name ?? string.Empty;

            return resultDto;
        }

        public async Task DeleteFarmAsync(Guid id)
        {
            var farm = await _unitOfWork.Farm.GetByIdAsync(id);
            if (farm == null)
            {
                throw new Exception("Farm not found");
            }

            farm.DeletedDateTime = DateTime.UtcNow;
            _unitOfWork.Farm.Update(farm);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
