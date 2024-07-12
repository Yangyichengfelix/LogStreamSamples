using Blazor_mac2c.Contracts;
using Blazor_mac2c.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazor_mac2c.Endpoint;

using System.Text.Json;

namespace Blazor_mac2c.Repositories
{
    public class LogService : ILogService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        public LogService(HttpClient httpClient)
        {
            _httpClient=httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<LogDurationModel>> GetLogDurations()
        {
             var response=   await _httpClient.GetAsync("https://localhost:44321/api/test");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var products = JsonSerializer.Deserialize<List<LogDurationModel>>(content, _options);
            return products;
        }
    }
}
