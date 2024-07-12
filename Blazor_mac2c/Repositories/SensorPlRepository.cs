using Blazor_mac2c.Contracts;
using Blazor_mac2c.Models;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace Blazor_mac2c.Repositories
{
    public class SensorPlRepository:ISensorPlRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public SensorPlRepository(HttpClient client,
        ILocalStorageService localStorage) 
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<SensorBaseModel> GetPlRealTime(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<SensorBaseModel>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected async Task<string> GetBearerToken()
        {
            return await _localStorage.GetItemAsync<string>("authToken");
        }
    }
}
