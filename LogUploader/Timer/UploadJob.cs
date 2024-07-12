using LogUploader.Services;
using LogUploader.Data;
using LogUploader.Statics;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using LogUploader.LoggerUtil;

namespace LogUploader.Timer
{
    public class UploadJob: IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            string contentType = "application/json";
            string GetUrl = RaspberryEndpoint.GetLogsEndpoint;
            string LoginUrl = RaspberryEndpoint.LoginEndpoint;
            DateTime end = DateTime.Now;
            DateTime start = end.AddMinutes(-1);
            string startString = "start=" + start.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            string endString = "end=" + end.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            string PostUrl = ServerEndpoint.CreateLogsEndpoint;
            string username = "user@ermo-tech.com";
            string password = "P@ssword1";
                    //var content = new StringContent(JsonConvert.SerializeObject(logModel), Encoding.UTF8, contentType);
            var logResult = GetMac2sLog(GetUrl,start,end,LoginUrl, username, password).Result;
            if (logResult.Count()>0)
            {
                Console.WriteLine($"*** {logResult.Count()} logs from {start} to {end} received");
                var logCreateDtos=logResult.ToList();
                foreach (var i in logCreateDtos)
                {
                    i.Date_Heure= i.Date_Heure.ToUniversalTime();
                    //i.Part_Pr.ToString();
                }
                LogsPostBody postBody = new(username, password,"mac2s15",logCreateDtos);

                Console.WriteLine(
                    postBody.UserName + " "
                    + postBody.DbName + " "
                    + postBody.Password+ " " 
                    + postBody.LogCreateDtos.Count());

                HttpClient _client = new HttpClient();
                LoginModel loginlodel = new LoginModel(username, password);
                var loginContent = new StringContent(JsonConvert.SerializeObject(loginlodel), Encoding.UTF8, contentType);
                var loginResponse = _client.PostAsync(LoginUrl, loginContent).Result;

                var content = await loginResponse.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<TokenResponse>(content);
                //_client.DefaultRequestHeaders.Authorization =
                //    new AuthenticationHeaderValue("bearer", token.Token);
                var bodyContent = new StringContent(JsonConvert.SerializeObject(postBody), Encoding.UTF8, contentType);
                //Console.WriteLine(bodyContent.ReadAsStringAsync().Result);
                try
                {
                    var reponse = _client.PostAsync(PostUrl, bodyContent).Result;
                    Console.WriteLine(reponse.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" exception: {ex}" );
                }
            }
            else
            {
                Console.WriteLine($"****** GET {GetUrl}?{startString}&{endString}, failed");
            }
        }
        //private async Task<HttpResponseMessage> CreateLogs(string url, string username, string password, LogsPostBody postBody)
        //{
        //    try
        //    {

               
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Out.WriteLine(ex);
        //        return null;
        //    }
        //}
        private async Task<IList<Mac2s_log>> GetMac2sLog(string getUrl, DateTime start, DateTime end, string loginUrl, string username, string password)
        {
            try
            {
                HttpClient _client = new HttpClient();
                LoginModel loginlodel = new LoginModel(username, password);
                var loginResponse =  _client.PostAsJsonAsync(loginUrl, loginlodel).Result;
                if (!loginResponse.IsSuccessStatusCode)
                {
                    return null;
                }
                var content = await loginResponse.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<TokenResponse>(content);
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("bearer", token.Token);
                string startString = "start=" + start.ToString("yyyy-MM-dd HH:mm:ss");
                string endString = "end=" + end.ToString("yyyy-MM-dd HH:mm:ss");
                var reponse =  _client.GetFromJsonAsync<IList<Mac2s_log>>($"{getUrl}?{startString}&{endString}").Result;
                return reponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
