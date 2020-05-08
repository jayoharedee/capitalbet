using com.capital.bet.data;
using com.capital.bet.data.Models.Tranactions;
using com.capital.bet.data.Models.Users;
using com.capital.bet.lib.Stocks;
using com.capital.bet.web.Configuration;
using com.capital.bet.web.Migrations;
using com.capital.bet.web.Models;
using IdentityModel.Client;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace com.capital.bet.web.Hubs
{

    /// <summary>
    /// Stock Hub for pub/sub
    /// </summary>
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class StockHub : Hub
    {
        /// <summary>
        /// Stock rate observable
        /// </summary>
        private Subject<List<StockRate>> StockUpdateSubject = new Subject<List<StockRate>>();

        private IDisposable stockUpdateSub;
        private readonly IUnitOfWork _dbContext;
        private readonly ILogger _logger;
        private readonly IMemoryCache _memoryCache;

        public StockHub(ILogger<StockHub> logger,
            IMemoryCache memoryCache,
            IUnitOfWork dbContext)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
            _logger = logger;
            stockUpdateSub = StockUpdateSubject.Subscribe((result) =>
           {
               Clients.All.SendAsync("stocks", result);
           });

        }

        /// <summary>
        /// Handle Errors
        /// </summary>
        /// <param name="es">Error</param>
        private void HandleError(Exception es)
        {
            _logger.LogError(es, "Stock Hub has received an error  ...");
            Clients.All.SendAsync("stock_error", new HubError(es.HResult, es.Message));
        }

        public override Task OnConnectedAsync()
        {
            _logger.LogInformation("Stock Client Connected ...");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _logger.LogInformation("Stock Client Disconnected ...");
            return base.OnDisconnectedAsync(exception);
        }

        ~StockHub()
        {
            if (stockUpdateSub != null)
                stockUpdateSub.Dispose();
        }

        /// <summary>
        /// Send New Stock Results
        /// </summary>
        /// <param name="stocks">Stocks list</param>
        public void SendNewStocks(List<StockRate> stocks)
        {
            StockUpdateSubject.OnNext(stocks);
        }


        #region Stock Sentiments
        /// <summary>
        /// Add Stock Trade
        /// </summary>
        /// <param name="trade">Trade request</param>
        public void AddStockTrade(StockTradeRequest trade)
        {
            _logger.LogInformation($"Trade Requested {Newtonsoft.Json.JsonConvert.SerializeObject(trade)}");

            // get the current data from cache
            List<SotckTraderSentiments> stockTraderSentiments;
            List<CurrencySentiment> currencySentiments;

            #region Get Cache
            if (!_memoryCache.TryGetValue(CacheKeys.STOCK_TRADERS_SENTIMENT, out stockTraderSentiments))
            {
                stockTraderSentiments = new List<SotckTraderSentiments>();
                _memoryCache.Set(CacheKeys.STOCK_TRADERS_SENTIMENT, stockTraderSentiments, new DateTimeOffset().AddDays(30));
            }

            if (!_memoryCache.TryGetValue(CacheKeys.STOCK_CURRENCY_SENTIMENT, out currencySentiments))
            {
                currencySentiments = new List<CurrencySentiment>();
                _memoryCache.Set(CacheKeys.STOCK_CURRENCY_SENTIMENT, currencySentiments, new DateTimeOffset().AddDays(30));
            }
            #endregion Get Cache


            _logger.LogInformation($"{Newtonsoft.Json.JsonConvert.SerializeObject(stockTraderSentiments)}");

            // make sure this is not an active trade
            if(stockTraderSentiments.Where(m=>m.User == Context.User.Identity.Name &&
                                              m.Currency == trade.Currency).Any())
            {
                _logger.LogInformation($"An Attempt to make a second trade detected by user : {Context.User.Identity.Name}");
                Clients.Caller.SendAsync("stock_error",
                    new HubError(500, "You currently have a trade for this currency on going please wait for the trade to complete to continue."));
                return;
            }


            // create the trader sentiment
            SotckTraderSentiments stockTrader = new SotckTraderSentiments()
            {
                Amount=trade.Amount,
                Currency=trade.Currency,
                Expires=trade.RequestDate.AddMinutes(trade.Period),
                IsHigh=trade.IsHigh,
                User = Context.User.Identity.Name,
                SentimentId = Guid.NewGuid()
            };
            stockTraderSentiments.Add(stockTrader);
            SaveTraderSetimentCache(stockTraderSentiments);

            _logger.LogInformation($"{Newtonsoft.Json.JsonConvert.SerializeObject(stockTraderSentiments)}");

            foreach (var grp in stockTraderSentiments.GroupBy(m => m.Currency))
            {
                CurrencySentiment c = new CurrencySentiment()
                {
                    Currency = grp.Key,
                    VolumeHigh = stockTraderSentiments.Where(m=>m.Currency==grp.Key && m.IsHigh).Sum(m=>m.Amount),
                    VolumeLow = stockTraderSentiments.Where(m => m.Currency == grp.Key && !m.IsHigh).Sum(m => m.Amount),
                    HighBids = stockTraderSentiments.Where(m=>m.Currency == grp.Key && m.IsHigh).Count(),
                    LowBids = stockTraderSentiments.Where(m => m.Currency == grp.Key && !m.IsHigh).Count()
                };
                currencySentiments.Add(c);
            }
            SaveCurrencySentiments(currencySentiments);
            // send to clients
            Clients.All.SendAsync("sentiments", currencySentiments);

        }

        private void SaveTraderSetimentCache(List<SotckTraderSentiments> value)
        {
            _memoryCache.Set(CacheKeys.STOCK_TRADERS_SENTIMENT, value, new DateTimeOffset().AddDays(30));
        }

        private void SaveCurrencySentiments(List<CurrencySentiment> value)
        {
            _memoryCache.Set(CacheKeys.STOCK_CURRENCY_SENTIMENT, value, new DateTimeOffset().AddDays(30));
        }


        #endregion Stock Sentiments

    }
}
