using Blazored.LocalStorage;
using System.Threading.Tasks;

namespace VHS.Client.Common
{
    public class LocalStorage
    {
        private readonly ILocalStorageService _localStorage;

        public LocalStorage(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task SaveStateAsync(string key, string value)
        {
            await _localStorage.SetItemAsync(key, value);
        }

        public async Task<string?> GetStateAsync(string key)
        {
            return await _localStorage.GetItemAsync<string>(key);
        }

        public async Task RemoveStateAsync(string key)
        {
            await _localStorage.RemoveItemAsync(key);
        }
    }
}
