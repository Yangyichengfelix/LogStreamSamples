using Blazor_mac2c.Contracts;
using Blazor_mac2c.Models;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace Blazor_mac2c.Repositories
{
    public class ActivityReportRepository:BaseRepository<ActivityReportModel>, IActivityReportRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public ActivityReportRepository(HttpClient client,
        ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<IList<ActivityReportModel>> GetActivityReport(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<IList<ActivityReportModel>>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
