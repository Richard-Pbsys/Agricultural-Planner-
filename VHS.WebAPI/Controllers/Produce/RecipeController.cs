using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VHS.Data.Models.Produce;
using VHS.Services.Produce.DTO;
using VHS.Services.Produce;

namespace VHS.WebAPI.Controllers.Produce
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] // Temp allowed
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly ILogger<RecipeController> _logger;

        public RecipeController(IRecipeService recipeService, ILogger<RecipeController> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes(Guid? farmId = null)
        {
            var recipes = await _recipeService.GetAllRecipesAsync(farmId);
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeById(Guid id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpGet("byfarm/{farmId}")]
        public async Task<IActionResult> GetRecipesByFarm(Guid farmId)
        {
            var recipes = await _recipeService.GetAllRecipesAsync(farmId);
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] RecipeDTO recipeDto)
        {
            var createdRecipe = await _recipeService.CreateRecipeAsync(recipeDto);
            return CreatedAtAction(nameof(GetRecipeById), new { id = createdRecipe.Id }, createdRecipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(Guid id, [FromBody] RecipeDTO recipeDto)
        {
            if (id != recipeDto.Id)
            {
                return BadRequest("ID mismatch");
            }
            var updatedRecipe = await _recipeService.UpdateRecipeAsync(recipeDto);
            return CreatedAtAction(nameof(GetRecipeById), new { id = updatedRecipe.Id }, updatedRecipe);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            await _recipeService.DeleteRecipeAsync(id);
            return NoContent();
        }
    }
}
