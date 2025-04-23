using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using VHS.Services.Produce.DTO;

namespace VHS.Client.Services.Produce
{
    public class RecipeLightScheduleClientService
    {
        private readonly HttpClient _httpClient;

        public RecipeLightScheduleClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RecipeLightScheduleDTO>?> GetAllRecipeLightSchedulesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<RecipeLightScheduleDTO>>("api/recipelightschedule");
        }

        public async Task<RecipeLightScheduleDTO?> GetRecipeLightScheduleByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<RecipeLightScheduleDTO>($"api/recipelightschedule/{id}");
        }

        public async Task<RecipeLightScheduleDTO?> CreateRecipeLightScheduleAsync(RecipeLightScheduleDTO scheduleDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/recipelightschedule", scheduleDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<RecipeLightScheduleDTO>();
        }

        public async Task UpdateRecipeLightScheduleAsync(RecipeLightScheduleDTO scheduleDto)
        {
            await _httpClient.PutAsJsonAsync($"api/recipelightschedule/{scheduleDto.Id}", scheduleDto);
        }

        public async Task DeleteRecipeLightScheduleAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/recipelightschedule/{id}");
        }
    }
}
