using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VHS.Services.Auth.DTO;

namespace VHS.Client.Services.Auth
{
    public class UserClientService
    {
        private readonly HttpClient _httpClient;

        public UserClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDTO?> CreateUserAsync(UserDTO userDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user/create", userDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserDTO>();
        }

        public async Task<UserDTO?> UpdateUserAsync(UserDTO userDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/user/update", userDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserDTO>();
        }

        public async Task<UserDTO?> GetUserByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<UserDTO>($"api/user/{id}");
        }
    }
}
