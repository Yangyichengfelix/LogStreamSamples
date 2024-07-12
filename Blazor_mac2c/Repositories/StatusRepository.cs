using Blazor_mac2c.Contracts;
using Blazor_mac2c.Models;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace Blazor_mac2c.Repositories
{
    public class StatusRepository : BaseRepository<StatusSimpleModel>, IStatusRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public StatusRepository(HttpClient client,
        ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<IList<StatusSimpleModel>> GetStatusList(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<IList<StatusSimpleModel>>(url);
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
