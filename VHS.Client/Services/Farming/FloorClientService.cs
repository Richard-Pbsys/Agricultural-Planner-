using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using VHS.Services.Farming.DTO;
using VHS.Services.Farming;

namespace VHS.Client.Services.Farming
{
    public class FloorClientService
    {
        private readonly HttpClient _httpClient;

        public FloorClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<FloorDTO>?> GetAllFloorsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<FloorDTO>>("api/floor");
        }

        public async Task<FloorDTO?> GetFloorByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<FloorDTO>($"api/floor/{id}");
        }

        public async Task<FloorDTO?> CreateFloorAsync(FloorDTO floorDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/floor", floorDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FloorDTO>();
        }

        public async Task UpdateFloorAsync(FloorDTO floorDto)
        {
            await _httpClient.PutAsJsonAsync($"api/floor/{floorDto.Id}", floorDto);
        }

        public async Task DeleteFloorAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/floor/{id}");
        }
    }
}
