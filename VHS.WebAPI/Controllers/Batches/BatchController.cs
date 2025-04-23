using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VHS.Services.Batches;
using VHS.Services.Batches.DTO;

namespace VHS.WebAPI.Controllers.Batches
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] // Temporary allowed
    public class BatchController : ControllerBase
    {
        private readonly IBatchService _batchService;

        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBatches(Guid? farmId = null)
        {
            var batches = await _batchService.GetAllBatchesAsync(farmId);
            return Ok(batches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBatchById(Guid id)
        {
            var batch = await _batchService.GetBatchByIdAsync(id);
            if (batch == null)
                return NotFound();
            return Ok(batch);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBatch([FromBody] BatchDTO batchDto)
        {
            var createdBatch = await _batchService.CreateBatchAsync(batchDto);
            return CreatedAtAction(nameof(GetBatchById), new { id = createdBatch.Id }, createdBatch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBatch(Guid id, [FromBody] BatchDTO batchDto)
        {
            if (id != batchDto.Id)
                return BadRequest("ID mismatch");
            await _batchService.UpdateBatchAsync(batchDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatch(Guid id)
        {
            await _batchService.DeleteBatchAsync(id);
            return NoContent();
        }
    }
}
