using Blazor_mac2c.Contracts;
using Blazor_mac2c.Models;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;
namespace Blazor_mac2c.Repositories
{
    public class StatusGroupDurationRepository : BaseRepository<StatusGroupDurationModel>, IStatusGroupDurationRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public StatusGroupDurationRepository(HttpClient client,
        ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }
        public async Task<IList<StatusGroupDurationModel>> GetStatusGroupDuration(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<IList<StatusGroupDurationModel>>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
