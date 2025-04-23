using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Produce;
using VHS.Services.Produce.DTO;

namespace VHS.Services.Produce
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync(Guid? farmId = null);
        Task<ProductDTO?> GetProductByIdAsync(Guid id);
        Task<ProductDTO> CreateProductAsync(ProductDTO productDto);
        Task UpdateProductAsync(ProductDTO productDto);
        Task DeleteProductAsync(Guid id);
    }

    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private static ProductDTO SelectProductToDTO(Product p) => new ProductDTO
        {
            Id = p.Id,
            ProductCategoryId = p.ProductCategoryId,
            FarmId = p.FarmId,
            Name = p.Name,
            Description = p.Description,
            ImageData = p.ImageData,
            SeedNumber = p.SeedNumber,
            AddedDateTime = p.AddedDateTime,
            ModifiedDateTime = p.ModifiedDateTime
        };

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync(Guid? farmId = null)
        {
            var products = farmId.HasValue && farmId.Value != Guid.Empty
                ? await _unitOfWork.Product.GetAllAsync(x => x.FarmId == farmId)
                : await _unitOfWork.Product.GetAllAsync();

            return products
                .OrderBy(p => p.Name)
                .Select(p => SelectProductToDTO(p));
        }

        public async Task<ProductDTO?> GetProductByIdAsync(Guid id)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);
            if (product == null)
                return null;

            return SelectProductToDTO(product);
        }

        public async Task<ProductDTO> CreateProductAsync(ProductDTO productDto)
        {
            var p = new Product
            {
                Id = productDto.Id == Guid.Empty ? Guid.NewGuid() : productDto.Id,
                ProductCategoryId = productDto.ProductCategoryId,
                Name = productDto.Name,
                FarmId = productDto.FarmId,
                Description = productDto.Description,
                ImageData = productDto.ImageData,
                SeedNumber = productDto.SeedNumber
            };

            await _unitOfWork.Product.AddAsync(p);
            await _unitOfWork.SaveChangesAsync();

            return await GetProductByIdAsync(p.Id);
        }

        public async Task UpdateProductAsync(ProductDTO productDto)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(productDto.Id);
            if (product == null)
                throw new Exception("Product not found");

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.ImageData = string.IsNullOrWhiteSpace(productDto.ImageData) ? null : productDto.ImageData;
            product.SeedNumber = productDto.SeedNumber;
            product.ProductCategoryId = productDto.ProductCategoryId;

            _unitOfWork.Product.Update(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);
            if (product == null)
                throw new Exception("Product not found");

            product.DeletedDateTime = DateTime.UtcNow;
            _unitOfWork.Product.Update(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
