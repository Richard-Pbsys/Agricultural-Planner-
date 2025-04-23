using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Produce;
using VHS.Services.Produce.DTO;
using Microsoft.EntityFrameworkCore;

namespace VHS.Services.Produce
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDTO>> GetAllRecipesAsync(Guid? farmId = null);
        Task<RecipeDTO?> GetRecipeByIdAsync(Guid id);
        Task<RecipeDTO> CreateRecipeAsync(RecipeDTO recipeDto);
        Task<RecipeDTO> UpdateRecipeAsync(RecipeDTO recipeDto);
        Task DeleteRecipeAsync(Guid id);
    }

    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private static RecipeDTO SelectRecipeToDTO(Recipe r) => new RecipeDTO
        {
            Id = r.Id,
            Name = r.Name,
            Product = r.Product != null
            ? new ProductDTO
            {
                Id = r.Product.Id,
                Name = r.Product.Name,
                FarmId = r.Product.FarmId
            } : new ProductDTO(),
            Description = r.Description,
            GerminationDays = r.GerminationDays,
            PropagationDays = r.PropagationDays,
            GrowDays = r.GrowDays,
            AddedDateTime = r.AddedDateTime,
            ModifiedDateTime = r.ModifiedDateTime
        };

        public async Task<IEnumerable<RecipeDTO>> GetAllRecipesAsync(Guid? farmId = null)
        {
            var recipes = farmId.HasValue && farmId.Value != Guid.Empty
                ? await _unitOfWork.Recipe.GetAllAsync(x=>x.Product.FarmId==farmId)
                : await _unitOfWork.Recipe.GetAllAsync();

            return recipes.Select(SelectRecipeToDTO);
        }

        public async Task<RecipeDTO?> GetRecipeByIdAsync(Guid id)
        {
            var recipe = await _unitOfWork.Recipe.GetByIdWithIncludesAsync(id);
            if (recipe == null)
            {
                return null;
            }
            return SelectRecipeToDTO(recipe);
        }       

        public async Task<RecipeDTO> CreateRecipeAsync(RecipeDTO recipeDto)
        {
            var recipe = new Recipe
            {
                Id = recipeDto.Id == Guid.Empty ? Guid.NewGuid() : recipeDto.Id,
                Name = recipeDto.Name,                
                Description = recipeDto.Description,
                ProductId = recipeDto.Product.Id,
                GerminationDays = recipeDto.GerminationDays,
                PropagationDays = recipeDto.PropagationDays,
                GrowDays = recipeDto.GrowDays,
                AddedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow
            };

            await _unitOfWork.Recipe.AddAsync(recipe);
            await _unitOfWork.SaveChangesAsync();

            return await GetRecipeByIdAsync(recipe.Id);
        }

        public async Task<RecipeDTO> UpdateRecipeAsync(RecipeDTO recipeDto)
        {

            var recipe = await _unitOfWork.Recipe.GetByIdWithIncludesAsync(recipeDto.Id);
            if (recipe == null)
                throw new Exception("Recipe not found");

            recipe.Name = recipeDto.Name;
            recipe.Description = recipeDto.Description;
            recipe.ProductId = recipeDto.Product.Id;
            recipe.GerminationDays = recipeDto.GerminationDays;
            recipe.PropagationDays = recipeDto.PropagationDays;
            recipe.GrowDays = recipeDto.GrowDays;
            recipe.ModifiedDateTime = DateTime.UtcNow;

            _unitOfWork.Recipe.Update(recipe);
            await _unitOfWork.SaveChangesAsync();

            return await GetRecipeByIdAsync(recipe.Id); ;
        }

        public async Task DeleteRecipeAsync(Guid id)
        {
            var recipe = await _unitOfWork.Recipe.GetByIdAsync(id);
            if (recipe == null)
                throw new Exception("Recipe not found");

            recipe.DeletedDateTime = DateTime.UtcNow;
            _unitOfWork.Recipe.Update(recipe);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
