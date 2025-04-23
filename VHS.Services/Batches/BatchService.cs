using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Batches;
using VHS.Services.Batches.DTO;
using VHS.Services.Farming.DTO;

namespace VHS.Services.Batches
{
    public interface IBatchService
    {
        Task<IEnumerable<BatchDTO>> GetAllBatchesAsync(Guid? farmId = null);
        Task<BatchDTO?> GetBatchByIdAsync(Guid id);
        Task<BatchDTO> CreateBatchAsync(BatchDTO batchDto);
        Task UpdateBatchAsync(BatchDTO batchDto);
        Task DeleteBatchAsync(Guid id);
        Task<string> GenerateBatchIdAsync(DateTime seededDate);
    }

    public class BatchService : IBatchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BatchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private static BatchDTO SelectBatchToDTO(Batch b) => new BatchDTO
        {
            Id = b.Id,
            BatchId = b.BatchId,
            FarmId = b.FarmId,
            BatchConfiguration = new BatchConfigurationDTO
            {
                Id = b.BatchConfigurationId,
                Name = b.BatchConfiguration?.Name ?? string.Empty
            },
            SeedDate = b.SeedDate,
            HarvestDate = b.HarvestDate,
            StatusId = b.StatusId
        };

        public async Task<IEnumerable<BatchDTO>> GetAllBatchesAsync(Guid? farmId = null)
        {
            var batches = farmId.HasValue && farmId.Value != Guid.Empty
                ? await _unitOfWork.Batch.GetAllAsync(x => x.FarmId == farmId)
                : await _unitOfWork.Batch.GetAllAsync();
            return batches.Select(SelectBatchToDTO);
        }  

        public async Task<BatchDTO?> GetBatchByIdAsync(Guid id)
        {
            var batch = await _unitOfWork.Batch.GetByIdWithIncludesAsync(id);
            if (batch == null) return null;

            return SelectBatchToDTO(batch);
        }

        public async Task<BatchDTO> CreateBatchAsync(BatchDTO batchDto)
        {
            DateTime seededDate = batchDto.SeedDate ?? DateTime.UtcNow;
            string generatedBatchId = await GenerateBatchIdAsync(seededDate);

            var batch = new Batch
            {
                Id = batchDto.Id == Guid.Empty ? Guid.NewGuid() : batchDto.Id,
                BatchId = generatedBatchId,
                FarmId = batchDto.BatchConfiguration.FarmId,
                BatchConfigurationId = batchDto.BatchConfiguration.Id,
                SeedDate = batchDto.SeedDate,
                HarvestDate = batchDto.HarvestDate,
                StatusId = batchDto.StatusId
            };

            await _unitOfWork.Batch.AddAsync(batch);
            await _unitOfWork.SaveChangesAsync();          

            return SelectBatchToDTO(batch);
        }

        public async Task UpdateBatchAsync(BatchDTO batchDto)
        {
            var batch = await _unitOfWork.Batch.GetByIdAsync(batchDto.Id);
            if (batch == null)
                throw new Exception("Batch not found");

            batch.FarmId = batchDto.FarmId;
            batch.BatchConfigurationId = batchDto.BatchConfiguration.Id;
            batch.SeedDate = batchDto.SeedDate;
            batch.HarvestDate = batchDto.HarvestDate;
            batch.StatusId = batchDto.StatusId;
            batch.ModifiedDateTime = DateTime.UtcNow;

            _unitOfWork.Batch.Update(batch);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteBatchAsync(Guid id)
        {
            var batch = await _unitOfWork.Batch.GetByIdAsync(id);
            if (batch == null)
                throw new Exception("Batch not found");

            batch.DeletedDateTime = DateTime.UtcNow;
            _unitOfWork.Batch.Update(batch);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Generates a human-readable BatchId in the format "BATCH-YYYYMMDD-XXXXXX"
        /// by checking existing batches for the given seeded date and incrementing the sequence.
        /// </summary>
        public async Task<string> GenerateBatchIdAsync(DateTime seededDate)
        {
            string prefix = "BATCH";
            string datePart = seededDate.ToString("yyyyMMdd");
            int nextSequence = 1;

            // Get batches that were seeded on the same date
            var batchesForDate = await _unitOfWork.Batch.Query()
                .Where(b => b.SeedDate.HasValue && b.SeedDate.Value.Date == seededDate.Date)
                .ToListAsync();

            if (batchesForDate.Any())
            {
                var sequenceNumbers = batchesForDate.Select(b =>
                {
                    // Ensure that BatchId is not null and follows the expected format "BATCH-YYYYMMDD-XXXXXX"
                    if (!string.IsNullOrWhiteSpace(b.BatchId))
                    {
                        string[] parts = b.BatchId.Split('-');
                        if (parts.Length == 3 && int.TryParse(parts[2], out int seq))
                            return seq;
                    }
                    return 0;
                });

                nextSequence = sequenceNumbers.Max() + 1;
            }

            // Build the BatchId using the prefix, date part, and zero-padded sequence number (6 digits minimum)
            string generatedBatchId = $"{prefix}-{datePart}-{nextSequence:D4}";
            return generatedBatchId;
        }
    }
}
