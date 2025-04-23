using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Batches;
using VHS.Services.Batches.DTO;
using VHS.Services.Farming.DTO;
using VHS.Services.Produce.DTO;

namespace VHS.Services.Batches
{
    public interface IBatchConfigurationService
    {
        Task<IEnumerable<BatchConfigurationDTO>> GetAllBatchConfigurationsAsync(Guid? farmId = null);
        Task<BatchConfigurationDTO?> GetBatchConfigurationByIdAsync(Guid id);
        Task<BatchConfigurationDTO> CreateBatchConfigurationAsync(BatchConfigurationDTO configDto);
        Task UpdateBatchConfigurationAsync(BatchConfigurationDTO configDto);
        Task DeleteBatchConfigurationAsync(Guid id);
    }

    public class BatchConfigurationService : IBatchConfigurationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BatchConfigurationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private static BatchConfigurationDTO SelectBatchConfigurationToDTO(BatchConfiguration c) => new BatchConfigurationDTO
        {
            Id = c.Id,
            Name = c.Name,
            FarmId = c.FarmId,
            Recipe = new RecipeDTO
            {
                Id = c.RecipeId,
                Name = c.Recipe?.Name ?? string.Empty,
                GerminationDays = c.Recipe?.GerminationDays ?? 0,
                PropagationDays = c.Recipe?.PropagationDays ?? 0,
                GrowDays = c.Recipe?.GrowDays ?? 0
            },
            TotalTrays = c.TotalTrays,
            TraysPerDay = c.TraysPerDay,
            StartTime = c.StartTime,
            EndTime = c.EndTime
        };

        public async Task<IEnumerable<BatchConfigurationDTO>> GetAllBatchConfigurationsAsync(Guid? farmId = null)
        {
            var configs = farmId.HasValue && farmId.Value != Guid.Empty
                ? await _unitOfWork.BatchConfiguration.GetAllAsync(x=>x.FarmId==farmId)
                : await _unitOfWork.BatchConfiguration.GetAllAsync();
            return configs.Select(SelectBatchConfigurationToDTO);
        }

        public async Task<BatchConfigurationDTO?> GetBatchConfigurationByIdAsync(Guid id)
        {
            var bc = await _unitOfWork.BatchConfiguration.GetByIdWithIncludesAsync(id);
            if (bc == null) return null;
            return SelectBatchConfigurationToDTO(bc);
        }

        public async Task<BatchConfigurationDTO> CreateBatchConfigurationAsync(BatchConfigurationDTO configDto)
        {
            var recipe = await _unitOfWork.Recipe.GetByIdWithIncludesAsync(configDto.Recipe.Id);
            if (recipe == null)
            {
                throw new Exception("Recipe not found.");
            }

            var bc = new BatchConfiguration
            {
                Id = configDto.Id == Guid.Empty ? Guid.NewGuid() : configDto.Id,
                Name = configDto.Name,
                FarmId = configDto.FarmId,
                RecipeId = configDto.Recipe.Id,
                TotalTrays = configDto.TotalTrays,
                TraysPerDay = configDto.TraysPerDay,
                StartTime = configDto.StartTime,
                EndTime = configDto.EndTime
            };

            await _unitOfWork.BatchConfiguration.AddAsync(bc);
            await _unitOfWork.SaveChangesAsync();          

            return await GetBatchConfigurationByIdAsync(bc.Id);
        }

        public async Task UpdateBatchConfigurationAsync(BatchConfigurationDTO configDto)
        {
            var config = await _unitOfWork.BatchConfiguration.GetByIdAsync(configDto.Id);
            if (config == null)
                throw new Exception("Batch configuration not found");

            config.Name = configDto.Name;
            config.FarmId = configDto.FarmId;
            config.RecipeId = configDto.Recipe.Id;
            config.TotalTrays = configDto.TotalTrays;
            config.TraysPerDay = configDto.TraysPerDay;
            config.StartTime = configDto.StartTime;
            config.EndTime = configDto.EndTime;
            config.AddedDateTime = DateTime.UtcNow;
            config.ModifiedDateTime = DateTime.UtcNow;

            _unitOfWork.BatchConfiguration.Update(config);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteBatchConfigurationAsync(Guid id)
        {
            var config = await _unitOfWork.BatchConfiguration.GetByIdAsync(id);
            if (config == null)
                throw new Exception("Batch configuration not found");

            config.DeletedDateTime = DateTime.UtcNow;
            _unitOfWork.BatchConfiguration.Update(config);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
