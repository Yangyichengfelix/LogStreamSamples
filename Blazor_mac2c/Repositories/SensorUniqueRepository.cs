using Blazor_mac2c.Contracts;
using Blazor_mac2c.Models;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Blazor_mac2c.Repositories
{
    public class SensorUniqueRepository : BaseRepository<SensorUniqueModel>, ISensorUniqueRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public SensorUniqueRepository(HttpClient client,
        ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<IList<SensorUniqueModel>> CallEndpoint(string HubUrl, string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                await _client.GetAsync(HubUrl);
                var reponse = await _client.GetFromJsonAsync<IList<SensorUniqueModel>>(url);
                return reponse;

            }
            catch (Exception)
            {
                return null;

            }
        }

        public async Task CallS1RealtimeEndpoint(string HubUrl)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
               var result =await _client.GetAsync(HubUrl);
                if (!result.IsSuccessStatusCode)
                    Console.WriteLine("Something went wrong with the response");
            }
            catch (Exception)
            {
            }
        }

        public Task<bool> Create(string url, SensorBaseModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<SensorBaseModel> GetPlRealTime(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<SensorUniqueModel>> GetRealTimeValues(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());

                var reponse = await _client.GetFromJsonAsync<IList<SensorUniqueModel>>(url);
                return reponse;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SensorUniqueModel> GetS1RealTime(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<SensorUniqueModel>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SensorUniqueModel> GetS2RealTime(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<SensorUniqueModel>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SensorUniqueModel> GetS3RealTime(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<SensorUniqueModel>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SensorUniqueModel> GetS4RealTime(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<SensorUniqueModel>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SensorUniqueModel> GetS5RealTime(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<SensorUniqueModel>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IList<SensorUniqueModel>> GetValues(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<IList<SensorUniqueModel>>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<bool> Update(string url, SensorBaseModel obj, int id)
        {
            throw new NotImplementedException();
        }


    }
}
