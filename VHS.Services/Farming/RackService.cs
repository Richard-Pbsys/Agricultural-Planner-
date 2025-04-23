using VHS.Data.Infrastructure;
using VHS.Data.Models.Farming;
using VHS.Services.Common;
using VHS.Services.Farming.Constants;
using VHS.Services.Farming.DTO;

namespace VHS.Services.Farming
{
    public interface IRackService
    {
        Task<IEnumerable<RackDTO>> GetAllRacksByTypeAsync(Guid farmId, Guid typeId);
        Task<RackDTO?> GetRackByIdAsync(Guid id);
        Task<IEnumerable<RackDTO>> GetAllRacksAsync(Guid? farmId = null);
        Task<RackDTO> CreateRackAsync(RackDTO rackDto);
        Task UpdateRackAsync(RackDTO rackDto);
        Task DeleteRackAsync(Guid id);
        Task InsertRacksForFarmAsync(Guid farmId, List<Floor> floors);
    }
    public class RackService : IRackService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private static RackDTO SelectRackToDTO(Rack r) => new RackDTO(r.Id, r.LayerCount)
        {
            Id = r.Id,
            Name = r.Name,
            Enabled = r.Enabled,
            Floor = new FloorDTO()
            {
                Id = r.Floor.Id,
                Name = r.Floor.Name,
                FarmId = r.Floor.FarmId,
                Enabled = r.Floor.Enabled                
            },
            TypeId = r.TypeId,
            LayerCount = r.LayerCount,
            TrayCountPerLayer = r.TrayCountPerLayer,
            Layers = r.Layers.Select(x => new LayerDTO
            {
                Id = x.Id,
                RackId = x.RackId,
                LayerNumber = x.LayerNumber,
                Enabled = x.Enabled
            }).ToList()
        };

        public async Task<IEnumerable<RackDTO>> GetAllRacksAsync(Guid? farmId = null)
        {
            var racks = farmId.HasValue && farmId.Value != Guid.Empty
                ? await _unitOfWork.Rack.GetAllAsync(x => x.Floor.FarmId == farmId.Value)
                : await _unitOfWork.Rack.GetAllAsync(x => x.Floor.Farm.DeletedDateTime == null);

            return racks
                .OrderBy(r => r.Name)
                .Select(SelectRackToDTO);
        }

        public async Task<IEnumerable<RackDTO>> GetAllRacksByTypeAsync(Guid farmId, Guid typeId)
        {
            var racks = await _unitOfWork.Rack.GetAllAsync(x => x.Floor.FarmId == farmId && x.TypeId == typeId);
            return racks
                .Select(SelectRackToDTO);
        }


        public async Task<RackDTO?> GetRackByIdAsync(Guid id)
        {
            var rack = await _unitOfWork.Rack.GetByIdAsync(id);
            if (rack == null)
                return null;

            return SelectRackToDTO(rack);
        }



        public async Task<RackDTO> CreateRackAsync(RackDTO rackDto)
        {
            var rack = new Rack
            {
                Id = rackDto.Id == Guid.Empty ? Guid.NewGuid() : rackDto.Id,
                Name = rackDto.Name,
                FloorId = rackDto.Floor.Id,
                Layers = new List<Layer>(),
                LayerCount = rackDto.LayerCount,
                TrayCountPerLayer = rackDto.TrayCountPerLayer
            };

            await _unitOfWork.Rack.AddAsync(rack);
            await _unitOfWork.SaveChangesAsync();

            return SelectRackToDTO(rack);
        }

        public async Task UpdateRackAsync(RackDTO rackDto)
        {
            var rack = await _unitOfWork.Rack.GetByIdAsync(rackDto.Id);
            if (rack == null)
                throw new Exception("Rack not found");

            rack.Name = rackDto.Name;
            rack.FloorId = rackDto.Floor.Id;
            rack.TrayCountPerLayer = rackDto.TrayCountPerLayer;
            rack.LayerCount = rackDto.LayerCount;
            _unitOfWork.Rack.Update(rack);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteRackAsync(Guid id)
        {
            var rack = await _unitOfWork.Rack.GetByIdAsync(id);
            if (rack == null)
                throw new Exception("Rack not found");

            rack.DeletedDateTime = DateTime.UtcNow;
            _unitOfWork.Rack.Update(rack);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task InsertRacksForFarmAsync(Guid farmId, List<Floor> floors)
        {
            if (floors == null || !floors.Any())
            {
                throw new ArgumentException("No floors available to assign racks.");
            }

            var racksToInsert = new List<Rack>();
            foreach (var floor in floors)
            {
                if (floor.Name == FloorConstant.SK1)
                {
                    racksToInsert.Add(new Rack
                    {
                        Id = Guid.NewGuid(),
                        Name = RackConstant.SK1aName,
                        TypeId = RackConstant.SK1aTypeId,
                        FloorId = floor.Id,
                        LayerCount = RackConstant.SK1aLayers,
                        TrayCountPerLayer = RackConstant.SK1aDepth
                    });
                }
                if (floor.Name == FloorConstant.SK2)
                {
                    racksToInsert.Add(new Rack
                    {
                        Id = Guid.NewGuid(),
                        Name = RackConstant.SK2aName,
                        TypeId = RackConstant.SK2aTypeId,
                        LayerCount = RackConstant.SK2aLayers,
                        TrayCountPerLayer = RackConstant.SK2aDepth,
                        FloorId = floor.Id
                    });

                    racksToInsert.Add(new Rack
                    {
                        Id = Guid.NewGuid(),
                        Name = RackConstant.SK2bName,
                        TypeId = RackConstant.SK2bTypeId,
                        LayerCount = RackConstant.SK2bLayers,
                        TrayCountPerLayer = RackConstant.SK2bDepth,
                        FloorId = floor.Id
                    });

                    racksToInsert.Add(new Rack
                    {
                        Id = Guid.NewGuid(),
                        Name = RackConstant.SK2cName,
                        TypeId = RackConstant.SK2cTypeId,
                        LayerCount = RackConstant.SK2cLayers,
                        TrayCountPerLayer = RackConstant.SK2cDepth,
                        FloorId = floor.Id
                    });

                    racksToInsert.Add(new Rack
                    {
                        Id = Guid.NewGuid(),
                        Name = RackConstant.SK2dName,
                        TypeId = RackConstant.SK2dTypeId,
                        LayerCount = RackConstant.SK2dLayers,
                        TrayCountPerLayer = RackConstant.SK2dDepth,
                        FloorId = floor.Id
                    });
                }
                if (floor.Name == FloorConstant.SK3)
                {
                    racksToInsert.Add(new Rack
                    {
                        Id = Guid.NewGuid(),
                        Name = RackConstant.SK3aName,
                        TypeId = RackConstant.SK3aTypeId,
                        LayerCount = RackConstant.SK3aLayers,
                        TrayCountPerLayer = RackConstant.SK3aDepth,
                        FloorId = floor.Id
                    });

                    racksToInsert.Add(new Rack
                    {
                        Id = Guid.NewGuid(),
                        Name = RackConstant.SK3bName,
                        TypeId = RackConstant.SK3bTypeId,
                        LayerCount = RackConstant.SK3bLayers,
                        TrayCountPerLayer = RackConstant.SK3bDepth,
                        FloorId = floor.Id
                    });

                    racksToInsert.Add(new Rack
                    {
                        Id = Guid.NewGuid(),
                        Name = RackConstant.SK3cName,
                        TypeId = RackConstant.SK3cTypeId,
                        LayerCount = RackConstant.SK3cLayers,
                        TrayCountPerLayer = RackConstant.SK3cDepth,
                        FloorId = floor.Id
                    });
                }
            }

            await _unitOfWork.Rack.AddRangeAsync(racksToInsert);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
