using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Farming;
using VHS.Services.Farming.Constants;
using VHS.Services.Farming.DTO;

namespace VHS.Services.Farming
{
    public interface IFloorService
    {
        Task<IEnumerable<FloorDTO>> GetAllFloorsAsync(Guid? farmId = null);
        Task<FloorDTO?> GetFloorByIdAsync(Guid id);
        Task<FloorDTO> CreateFloorAsync(FloorDTO floorDto);
        Task UpdateFloorAsync(FloorDTO floorDto);
        Task DeleteFloorAsync(Guid id);
        List<Floor> GenerateDefaultFloors(Guid farmId);
    }

    public class FloorService : IFloorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FloorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private static FloorDTO SelectFloorToDTO(Floor f) => new FloorDTO
        {
            Id = f.Id,
            Name = f.Name,
            FloorNumber = f.FloorNumber,
            FarmId = f.FarmId,
            Enabled = f.Enabled,
        };


        public async Task<IEnumerable<FloorDTO>> GetAllFloorsAsync(Guid? farmId = null)
        {
            var floors = farmId.HasValue && farmId.Value != Guid.Empty
                ? await _unitOfWork.Floor.GetAllAsync(x => x.FarmId == farmId.Value)
                : await _unitOfWork.Floor.GetAllAsync();

            return floors
                .OrderBy(f => f.Name)
                .Select(SelectFloorToDTO);
        }


        public async Task<FloorDTO?> GetFloorByIdAsync(Guid id)
        {
            var floor = await _unitOfWork.Floor.GetByIdAsync(id);
            if (floor == null)
                return null;

            return SelectFloorToDTO(floor);
        }

        public async Task<FloorDTO> CreateFloorAsync(FloorDTO floorDto)
        {
            var floor = new Floor
            {
                Id = floorDto.Id == Guid.Empty ? Guid.NewGuid() : floorDto.Id,
                FarmId = floorDto.FarmId,
                Name = floorDto.Name
            };

            await _unitOfWork.Floor.AddAsync(floor);
            await _unitOfWork.SaveChangesAsync();

            return await GetFloorByIdAsync(floor.Id);
        }

        public async Task UpdateFloorAsync(FloorDTO floorDto)
        {
            var floor = await _unitOfWork.Floor.GetByIdAsync(floorDto.Id);
            if (floor == null)
                throw new Exception("Floor not found");

            floor.Name = floorDto.Name;
            floor.FarmId = floorDto.FarmId;
            _unitOfWork.Floor.Update(floor);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteFloorAsync(Guid id)
        {
            var floor = await _unitOfWork.Floor.GetByIdAsync(id);
            if (floor == null)
                throw new Exception("Floor not found");

            floor.DeletedDateTime = DateTime.UtcNow;
            _unitOfWork.Floor.Update(floor);
            await _unitOfWork.SaveChangesAsync();
        }

        public List<Floor> GenerateDefaultFloors(Guid farmId)
        {
            return new List<Floor>
            {
                new Floor { Id = Guid.NewGuid(), Name = FloorConstant.SK1, FloorNumber = 1, FarmId = farmId },
                new Floor { Id = Guid.NewGuid(), Name = FloorConstant.SK2, FloorNumber = 2, FarmId = farmId },
                new Floor { Id = Guid.NewGuid(), Name = FloorConstant.SK3, FloorNumber = 3, FarmId = farmId }
            };
        }
    }
}
