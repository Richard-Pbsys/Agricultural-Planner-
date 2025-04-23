using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VHS.Services.Produce;
using VHS.Services.Produce.DTO;

namespace VHS.WebAPI.Controllers.Produce
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] // Temp allow
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduceTypes(Guid? farmId = null)
        {
            var produceTypes = await _productService.GetAllProductsAsync(farmId);
            return Ok(produceTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduceTypeById(Guid id)
        {
            var produceType = await _productService.GetProductByIdAsync(id);
            if (produceType == null)
            {
                return NotFound();
            }
            return Ok(produceType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduceType([FromBody] ProductDTO productDto)
        {
            var createdProduceType = await _productService.CreateProductAsync(productDto);
            return CreatedAtAction(nameof(GetProduceTypeById), new { id = createdProduceType.Id }, createdProduceType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduceType(Guid id, [FromBody] ProductDTO productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest("ID mismatch");
            }
            await _productService.UpdateProductAsync(productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduceType(Guid id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
