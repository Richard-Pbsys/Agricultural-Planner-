using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VHS.Services.Batches.DTO;

namespace VHS.Client.Services.Batches
{
    public class BatchConfigurationClientService
    {
        private readonly HttpClient _httpClient;

        public BatchConfigurationClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BatchConfigurationDTO>?> GetAllBatchConfigurationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BatchConfigurationDTO>>("api/batchconfiguration");
        }

        public async Task<BatchConfigurationDTO?> GetBatchConfigurationByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<BatchConfigurationDTO>($"api/batchconfiguration/{id}");
        }

        public async Task<BatchConfigurationDTO?> CreateBatchConfigurationAsync(BatchConfigurationDTO configDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/batchconfiguration", configDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BatchConfigurationDTO>();
        }

        public async Task UpdateBatchConfigurationAsync(BatchConfigurationDTO configDto)
        {
            await _httpClient.PutAsJsonAsync($"api/batchconfiguration/{configDto.Id}", configDto);
        }

        public async Task DeleteBatchConfigurationAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/batchconfiguration/{id}");
        }
    }
}
