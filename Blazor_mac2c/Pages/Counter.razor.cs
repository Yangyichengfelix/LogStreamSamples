using Blazor_mac2c.Contracts;
using Blazor_mac2c.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Blazor_mac2c.Pages
{
    public partial class Counter : IDisposable
    {
        private HubConnection _hubConnection;
        public List<SensorUniqueModel> Data = new List<SensorUniqueModel>();
        public List<SensorUniqueModel> ExchangedData = new List<SensorUniqueModel>();
        [Inject]
        public ISensorUniqueRepository Repo { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await StartHubConnection();
            await Repo.CallEndpoint("https://localhost:44321/sensors1hub", Endpoint.Endpoint.SensorTestEnpoint);
            AddTransferChartDataListener();
            AddExchangeDataListener();
        }
        private async Task StartHubConnection()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44321/sensors1hub")
                .Build();
            await _hubConnection.StartAsync();
            if (_hubConnection.State == HubConnectionState.Connected)
                Console.WriteLine("connection started");
        }
        private void AddTransferChartDataListener()
        {
            _hubConnection.On<List<SensorUniqueModel>>("TransferChartData", (data) =>
            {
                foreach (var item in data)
                {
                    Console.WriteLine($"Label: {item.Date_Heure}, Value: {item.Value}");
                }
                Data = data;
                StateHasChanged();
            });
        }
    public async Task SendToAcceptChartDataMethod() =>
     await _hubConnection.SendAsync("AcceptChartData", Data);
        private void AddExchangeDataListener()
        {
            _hubConnection.On<List<SensorUniqueModel>>("ExchangeChartData", (data) =>
            {
                ExchangedData = data;
                StateHasChanged();
            });
        }
        public void Dispose()
        {
            _hubConnection.DisposeAsync();
        }
    }
}
