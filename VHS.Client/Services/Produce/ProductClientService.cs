using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VHS.Services.Produce.DTO;

namespace VHS.Client.Services.Produce
{
    public class ProductClientService
    {
        private readonly HttpClient _httpClient;

        public ProductClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductDTO>?> GetAllProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductDTO>>("api/product");
        }

        public async Task<ProductDTO?> GetProductByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ProductDTO>($"api/product/{id}");
        }

        public async Task<ProductDTO?> CreateProductAsync(ProductDTO produceType)
        {
            var response = await _httpClient.PostAsJsonAsync("api/product", produceType);
            return await response.Content.ReadFromJsonAsync<ProductDTO>();
        }

        public async Task UpdateProductAsync(ProductDTO productDto)
        {
            await _httpClient.PutAsJsonAsync($"api/product/{productDto.Id}", productDto);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/product/{id}");
        }
    }
}
