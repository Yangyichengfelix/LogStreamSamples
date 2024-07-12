using Blazor_mac2c.Contracts;
using Blazor_mac2c.Models;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Blazor_mac2c.Repositories
{
    public class LogDurationRepository : BaseRepository<LogDurationModel>, ILogDurationRepository
    {
        public LogDurationRepository(HttpClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }

        public async Task<IList<LogDurationModel>> GetLogDuration(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<IList<LogDurationModel>>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IList<LogDurationModel>> GetNokAlert(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<IList<LogDurationModel>>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int?> GetNokNumber(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
 
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());

                HttpResponseMessage response = await _client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<int>(content);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<int?> GetCycleTime(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());

                HttpResponseMessage response = await _client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<int>(content);
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public async Task<IList<LogDurationModel>> GetSkewingAlert(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<IList<LogDurationModel>>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
    

}