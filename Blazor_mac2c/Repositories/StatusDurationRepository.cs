using Blazor_mac2c.Contracts;
using Blazor_mac2c.Models;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace Blazor_mac2c.Repositories
{

    public class StatusDurationRepository : BaseRepository<StatusDurationModel>, IStatusDurationRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public StatusDurationRepository(HttpClient client,
        ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }
        public async Task<IList<StatusDurationModel>> GetStatusDuration(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<IList<StatusDurationModel>>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
