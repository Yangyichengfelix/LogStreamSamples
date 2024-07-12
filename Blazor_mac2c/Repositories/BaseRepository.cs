using Blazor_mac2c.Contracts;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Blazor_mac2c.Repositories
{
    public class BaseRepository <T> : IBaseRepository<T> where T : class
    {
        protected readonly HttpClient _client;
        protected readonly ILocalStorageService _localStorage;
        public BaseRepository(HttpClient client,
            ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }
#region unused
        public async Task<bool> Create(string url, T obj)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (obj == null)
                return true;

            request.Content = new StringContent(JsonConvert.SerializeObject(obj)
                , Encoding.UTF8, "application/json");

            
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                return true;

            return false;
        }

        public Task<bool> Delete(string url, int id)
        {
            throw new NotImplementedException();
        }

#endregion unused
        public async Task<T> Get(string url, int id)
        {
            _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("bearer", await GetBearerToken());
            var reponse = await _client.GetFromJsonAsync<T>(url + id);

            return reponse;
        }


        public async Task<bool> Update(string url, T obj, int id)
        {
            if (obj == null)
                return false;

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
            var response = await _client.PutAsJsonAsync<T>(url + id, obj);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;

            return false;
        }

        public async Task<IList<T>> GetAll(string url)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());
                var reponse = await _client.GetFromJsonAsync<IList<T>>(url);
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
