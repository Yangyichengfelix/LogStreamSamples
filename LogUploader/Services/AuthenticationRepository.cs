
using LogUploader.Contracts;
using LogUploader.Data;
using LogUploader.Statics;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LogUploader.Services
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly HttpClient _client;


        public AuthenticationRepository(HttpClient client)
        {
            _client = client;      
        }
        public async Task<bool> Login(LoginModel user)
        {
            var response = await _client.PostAsJsonAsync(RaspberryEndpoint.LoginEndpoint, user);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            var content = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<TokenResponse>(content);
            ////store token
            //await _localstorage.setitemasync("authtoken", token.token);
            ////change auth state of app
            //await((apiauthenticationstateprovider)_authenticationstateprovider)
            //    .loggedin();
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", token.Token);
            return true;
        }
    }
}
