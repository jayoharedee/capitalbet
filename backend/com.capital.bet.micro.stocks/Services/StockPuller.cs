using com.capital.bet.data.Models.Stocks;
using com.capital.bet.lib.Stocks;
using IdentityModel.Client;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace com.capital.bet.micro.stocks.Services
{
    /// <summary>
    /// Provides the Socket Server to the Stock rates 
    /// </summary>
    public class StockPuller : IHostedService, IDisposable
    {
        private List<StockRate> stockRatesSimulated = new List<StockRate>();

        private List<StockRate> AUD_CAD = new List<StockRate>();
        private List<StockRate> AUD_JPY = new List<StockRate>();
        private List<StockRate> AUD_USD = new List<StockRate>();
        private List<StockRate> BTC_EUR = new List<StockRate>();
        private List<StockRate> BTC_USD = new List<StockRate>();
        private List<StockRate> CAD_JPY = new List<StockRate>();
        private List<StockRate> EUR_AUD = new List<StockRate>();
        private List<StockRate> EUR_CAD = new List<StockRate>();
        private List<StockRate> EUR_GBP = new List<StockRate>();
        private List<StockRate> EUR_JPY = new List<StockRate>();
        private List<StockRate> EUR_USD = new List<StockRate>();
        private List<StockRate> GBP_JPY = new List<StockRate>();
        private List<StockRate> GBP_USD = new List<StockRate>();
        private List<StockRate> USD_CAD = new List<StockRate>();
        private List<StockRate> USD_JPY = new List<StockRate>();


        private  int currentIndex = 0;

        private readonly ILogger _logger;
        private IOptions<ServiceConfiguration> _serviceConfiguration;
        private readonly IServiceProvider _services;
        private HubConnection connection;
        private Timer _timer;
        private Timer _batchTimer;
        private int executionCount = 0;
        private string Token { get; set; }

        private string stockTickers = "EUR_USD,GBP_USD,GBP_HUF,EUR_JPY,NZD_USD,USD_JPY,EUR_CHF,USD_CHF,AUD_USD,USD_CAD,EUR_GBP,BTC_USD,BTC_JPY," +
                "BTC_EUR,EUR_AUD,USD_CNY,CAD_JPY,GBP_CHF,GBP_JPY,AUD_NZD,AUD_CAD,AUD_CHF,AUD_JPY,EUR_NZD,CHF_JPY,EUR_CAD,CAD_CHF," +
                "NZD_JPY,USD_SGD,NZD_CAD,GBP_CAD";

        private Queue<List<StockRate>> rateQueue = new Queue<List<StockRate>>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger DI</param>
        /// <param name="services">DI Container</param>
        public StockPuller(ILogger<StockPuller> logger, IServiceProvider services, IOptions<ServiceConfiguration> serviceConfiguration)
        {
            _logger = logger;
            _services = services;
            _serviceConfiguration = serviceConfiguration;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _services.CreateScope())
            {
                _logger.LogInformation("Capital Bet Stock Puller Started ...");
                await GetAccessToken();
                await Task.Delay(100);
                LoadSupportedList();
                // set up the signlar
                connection = new HubConnectionBuilder()
                    .WithUrl("http://localhost:5000/stocks")
                    .Build();
                // re-connect on closed connection
                connection.Closed += async (error) =>
                {
                    await Task.Delay(new Random().Next(0, 5) * 1000);
                    await connection.StartAsync();
                };
                await connection.StartAsync();
                _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
                if (_serviceConfiguration.Value.SaveToDb)
                    _batchTimer = new Timer(SaveBatch, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
                return;
            }
        }



        private async void SaveBatch(object state)
        {
            for(int i = 0; i < 30; i++)
            {
                if (rateQueue.Count == 0)
                    break;

                List<StockRate> rates = rateQueue.Dequeue();
                string ratesString = Newtonsoft.Json.JsonConvert.SerializeObject(rates);
                var client = new HttpClient();
                var content = new StringContent("{\"stocks\":"+ratesString+"}", Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.Token}");
                var response = await client.PostAsync("http://localhost:5000/api/Stocks/stocks/add", content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("failed to save the requested data to the server ...");
                }
            }
        }

        private async void DoWork(object state)
        {
            var count = Interlocked.Increment(ref executionCount);

            if (!this._serviceConfiguration.Value.SimulateData)
            {
                // grab the quotes
                HttpClient client = new HttpClient();
                var result = await client.GetAsync($"https://www.live-rates.com/api/price?rate={stockTickers}&key=730aa45ccc");
                if (result.IsSuccessStatusCode)
                {
                    string data = await result.Content.ReadAsStringAsync();
                    List<StockRate> rates = Newtonsoft.Json.JsonConvert.DeserializeObject<List<StockRate>>(data);
                    rateQueue.Enqueue(rates);
                    _logger.LogInformation(Newtonsoft.Json.JsonConvert.SerializeObject(rates));
                    if (connection.State == HubConnectionState.Connected)
                        await connection.SendAsync("SendNewStocks", rates);
                }
                else
                {
                    string error = $"Stock Feed Returned: {result.StatusCode} with {await result.Content.ReadAsStringAsync()}";
                    _logger.LogError(error);
                }
            }
            else
            {
                // load the data and set the local cache
                if (stockRatesSimulated.Count == 0)
                    await LoadSimulatedData();


                List<StockRate> db = new List<StockRate>();
                if(this.currentIndex < AUD_CAD.Count)
                    db.Add(AUD_CAD[this.currentIndex]);
                if (this.currentIndex < AUD_JPY.Count)
                    db.Add(AUD_JPY[this.currentIndex]);
                if (this.currentIndex < AUD_USD.Count)
                    db.Add(AUD_USD[this.currentIndex]);
                if (this.currentIndex < BTC_EUR.Count)
                    db.Add(BTC_EUR[this.currentIndex]);
                if (this.currentIndex < BTC_USD.Count)
                    db.Add(BTC_USD[this.currentIndex]);
                if (this.currentIndex < CAD_JPY.Count)
                    db.Add(CAD_JPY[this.currentIndex]);
                if (this.currentIndex < EUR_AUD.Count)
                    db.Add(EUR_AUD[this.currentIndex]);
                if (this.currentIndex < EUR_CAD.Count)
                    db.Add(EUR_CAD[this.currentIndex]);
                if (this.currentIndex < EUR_GBP.Count)
                    db.Add(EUR_GBP[this.currentIndex]);
                if (this.currentIndex < EUR_JPY.Count)
                    db.Add(EUR_JPY[this.currentIndex]);
                if (this.currentIndex < EUR_USD.Count)
                    db.Add(EUR_USD[this.currentIndex]);
                if (this.currentIndex < GBP_JPY.Count)
                    db.Add(GBP_JPY[this.currentIndex]);
                if (this.currentIndex < GBP_USD.Count)
                    db.Add(GBP_USD[this.currentIndex]);
                if (this.currentIndex < USD_CAD.Count)
                    db.Add(USD_CAD[this.currentIndex]);
                if (this.currentIndex < USD_JPY.Count)
                    db.Add(USD_JPY[this.currentIndex]);

                this.currentIndex ++;
                if (this.currentIndex > this.AUD_CAD.Count)
                    this.currentIndex = 0;

                if (connection.State == HubConnectionState.Connected)
                    await connection.SendAsync("SendNewStocks", db);

            }
        }

        private async Task LoadSimulatedData()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.Token}");
            var response = await client.GetAsync("http://localhost:5000/api/Stocks/simulated");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                stockRatesSimulated = Newtonsoft.Json.JsonConvert.DeserializeObject<List<StockRate>>(data);
                AUD_CAD = stockRatesSimulated.Where(m => m.Currency == "AUD_CAD").OrderBy(m => m.Timestamp).ToList();
                AUD_JPY = stockRatesSimulated.Where(m => m.Currency == "AUD_JPY").OrderBy(m => m.Timestamp).ToList();
                AUD_USD = stockRatesSimulated.Where(m => m.Currency == "AUD_USD").OrderBy(m => m.Timestamp).ToList();
                BTC_EUR = stockRatesSimulated.Where(m => m.Currency == "BTC_EUR").OrderBy(m => m.Timestamp).ToList();
                BTC_USD = stockRatesSimulated.Where(m => m.Currency == "BTC_USD").OrderBy(m => m.Timestamp).ToList();
                CAD_JPY = stockRatesSimulated.Where(m => m.Currency == "CAD_JPY").OrderBy(m => m.Timestamp).ToList();
                EUR_AUD = stockRatesSimulated.Where(m => m.Currency == "EUR_AUD").OrderBy(m => m.Timestamp).ToList();
                EUR_CAD = stockRatesSimulated.Where(m => m.Currency == "EUR_CAD").OrderBy(m => m.Timestamp).ToList();
                EUR_GBP = stockRatesSimulated.Where(m => m.Currency == "EUR_GBP").OrderBy(m => m.Timestamp).ToList();
                EUR_JPY = stockRatesSimulated.Where(m => m.Currency == "EUR_JPY").OrderBy(m => m.Timestamp).ToList();
                EUR_USD = stockRatesSimulated.Where(m => m.Currency == "EUR_USD").OrderBy(m => m.Timestamp).ToList();
                GBP_JPY = stockRatesSimulated.Where(m => m.Currency == "GBP_JPY").OrderBy(m => m.Timestamp).ToList();
                GBP_USD = stockRatesSimulated.Where(m => m.Currency == "GBP_USD").OrderBy(m => m.Timestamp).ToList();
                USD_CAD = stockRatesSimulated.Where(m => m.Currency == "USD_CAD").OrderBy(m => m.Timestamp).ToList();
                USD_JPY = stockRatesSimulated.Where(m => m.Currency == "USD_JPY").OrderBy(m => m.Timestamp).ToList();
            }
            else
            {
                _logger.LogError($"Failed to get stock prices ... {await response.Content.ReadAsStringAsync()}");
                stockRatesSimulated = new List<StockRate>();
            }

        }


        private async void LoadSupportedList()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.Token}");
            var response = await client.GetAsync("http://localhost:5000/api/Stocks/types");
            if (response.IsSuccessStatusCode)
            {
                stockTickers = "";
                string data = await response.Content.ReadAsStringAsync();
                List<Stock> stocks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Stock>>(data);
                foreach(var itm in stocks)
                {
                    stockTickers += itm.StockId+",";
                }

                stockTickers = stockTickers.Remove(stockTickers.Length - 1, 1);
                _logger.LogInformation($"Currency Pairs => {stockTickers}");
            }
        }



        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Capital Bet Stock Puller Stopped ...");
            _timer?.Change(Timeout.Infinite, 0);
            _batchTimer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _timer?.Dispose();
                    _batchTimer?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        ~StockPuller()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }


        #endregion



        private async Task<string> GetAccessToken()
        {
            var client = new HttpClient();
            DiscoveryDocumentResponse disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");

            var tokenEndPoint = new HttpClient();
            TokenResponse response = await tokenEndPoint.RequestTokenAsync(new TokenRequest
            {
                Address = disco.TokenEndpoint,
                GrantType = "client_credentials",
                ClientId = "com.capital.bet.micro.stocks",
                ClientSecret = "731F408D-4C77-41F6-878E-06599B7C218B",
                Parameters =
                {
                    {"scope", "capitalbet_api" }
                }
            });

            if (!response.IsError)
            {
                Token = response.AccessToken;
                return Token;
            }
            return null;

        }

    }
}
