using LogUploader.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogUploader.Services
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly HttpClient _client;
        protected readonly IAuthenticationRepository _authenticationRepository;

        public BaseRepository(HttpClient client, IAuthenticationRepository authRepo)
        {
            _client = client;
            _authenticationRepository = authRepo;
        }

        public Task<bool> Create(string url, T obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<T>> GetAll(string url)
        {
           throw new NotImplementedException();
        }


    }
}
