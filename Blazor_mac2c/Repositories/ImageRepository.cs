using Blazor_mac2c.Contracts;
using Blazor_mac2c.Models;
using Blazored.LocalStorage;

namespace Blazor_mac2c.Repositories
{
    public class ImageRepository : BaseRepository<ImageModel>, IImageRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public ImageRepository(HttpClient client,
        ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<ImageModel> GetByLastLog()
        {
            try
            {
                var response = await _client.GetFromJsonAsync<ImageModel>(Endpoint.Endpoint.LastLogImageEndpoint);
                return response;
            }
            catch (Exception)
            {

                return null;

            }
        }

        public async Task<ImageModel> GetLast()
        {
            try
            {
                var response = await _client.GetFromJsonAsync<ImageModel>(Endpoint.Endpoint.LastImageEndpoint);
                return response;
            }
            catch (Exception)
            {

                return null;

            }

        }
    }
}
