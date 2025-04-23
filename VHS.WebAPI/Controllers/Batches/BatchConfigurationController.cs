using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VHS.Services.Batches;
using VHS.Services.Batches.DTO;

namespace VHS.WebAPI.Controllers.Batches
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] // Temporary allowed
    public class BatchConfigurationController : ControllerBase
    {
        private readonly IBatchConfigurationService _batchConfigurationService;

        public BatchConfigurationController(IBatchConfigurationService batchConfigurationService)
        {
            _batchConfigurationService = batchConfigurationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConfigurations(Guid? farmId = null)
        {
            var configs = await _batchConfigurationService.GetAllBatchConfigurationsAsync(farmId);
            return Ok(configs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConfigurationById(Guid id)
        {
            var config = await _batchConfigurationService.GetBatchConfigurationByIdAsync(id);
            if (config == null)
                return NotFound();
            return Ok(config);
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfiguration([FromBody] BatchConfigurationDTO configDto)
        {
            var createdConfig = await _batchConfigurationService.CreateBatchConfigurationAsync(configDto);
            return CreatedAtAction(nameof(GetConfigurationById), new { id = createdConfig.Id }, createdConfig);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConfiguration(Guid id, [FromBody] BatchConfigurationDTO configDto)
        {
            if (id != configDto.Id)
                return BadRequest("ID mismatch");
            await _batchConfigurationService.UpdateBatchConfigurationAsync(configDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguration(Guid id)
        {
            await _batchConfigurationService.DeleteBatchConfigurationAsync(id);
            return NoContent();
        }
    }
}
