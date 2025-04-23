using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VHS.Services.Auth.DTO;

namespace VHS.Client.Services.Auth
{
    public class UserSettingClientService
    {
        private readonly HttpClient _httpClient;

        public UserSettingClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserSettingDTO?> GetUserSettingsByUserIdAsync(Guid userId)
        {
            return await _httpClient.GetFromJsonAsync<UserSettingDTO>($"api/user/settings/{userId}");
        }

        public async Task<UserSettingDTO?> UpdateUserSettingsAsync(UserSettingDTO settingsDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/user/settings/update", settingsDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserSettingDTO>();
        }
    }
}
