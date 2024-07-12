using LogUploader.Contracts;
using LogUploader.Data;
using LogUploader.Statics;
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
    public class Mac2s_logRepository : IMac2s_logRepository
    {

        private readonly HttpClient _client;
        private readonly IAuthenticationRepository _authRepo;
        public Mac2s_logRepository(HttpClient client, IAuthenticationRepository authRepo)
        {
            _client = client;   
            _authRepo = authRepo;
        }

        public async Task<IList<Mac2s_log>> GetMac2sLog(string getUrl, DateTime start, DateTime end,string loginUrl, string username, string password)
        {
            try
            {
                LoginModel loginlodel= new LoginModel(username, password);
                var response = await _client.PostAsJsonAsync(loginUrl, loginlodel);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
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
                string startString= "start=" + start.ToString("yyyy-MM-dd HH:mm:ss");
                string endString= "end=" + end.ToString("yyyy-MM-dd HH:mm:ss");
                var reponse = await _client.GetFromJsonAsync<IList<Mac2s_log>>($"{getUrl}?{startString}&{endString}");
                return reponse;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> CreateLog(string url, string username, string password, Mac2s_log log)
        {
            try
            {
                LoginModel loginlodel = new LoginModel(username, password);
                var response = await _client.PostAsJsonAsync(url, loginlodel);
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                var content = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<TokenResponse>(content);
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("bearer", token.Token);

                var reponse = await _client.PostAsJsonAsync(url, log);
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CreateLogs(string url, string username, string password, LogsPostBody postBody)
        {
            try
            {
                LoginModel loginlodel = new LoginModel(username, password);
                var response = await _client.PostAsJsonAsync(url, loginlodel);
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                var content = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<TokenResponse>(content);
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("bearer", token.Token);

                var reponse = await _client.PostAsJsonAsync(url, postBody);
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
