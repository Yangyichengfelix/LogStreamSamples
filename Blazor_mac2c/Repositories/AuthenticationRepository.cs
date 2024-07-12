using Blazor_mac2c.Contracts;
using Blazor_mac2c.Models;
using Blazor_mac2c.Endpoint;
using System.Text;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Blazor_mac2c.Provider;

namespace Blazor_mac2c.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public AuthenticationRepository(HttpClient client,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _client = client;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async  Task<bool> ForgotPassword(ForgotPasswordModel user)
        {
            var response = await _client.PostAsJsonAsync(Endpoint.Endpoint.ForgotPasswordEndpoint, user);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Login(LoginModel user)
        {
            var response = await _client.PostAsJsonAsync(Endpoint.Endpoint.LoginEndpoint, user);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            var content = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<TokenResponse>(content);
            //Store Token
            await _localStorage.SetItemAsync("authToken", token.Token);
            //Change auth state of app
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                .LoggedIn();
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", token.Token);
            return true;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                .LoggedOut();
        }

        public async Task<bool> Register(RegisterModel user)
        {
            var response = await _client.PostAsJsonAsync(Endpoint.Endpoint.RegisterEndpoint, user);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> ResetForgottenPassword(ResetForgottenPasswordModel user)
        {
            var response = await _client.PostAsJsonAsync(Endpoint.Endpoint.ResetForgottenPasswordEndpoint, user);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> ResetPassword(ResetPasswordModel user)
        {
            var response = await _client.PostAsJsonAsync(Endpoint.Endpoint.ResetPasswordEndpoint, user);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }
    }
}
