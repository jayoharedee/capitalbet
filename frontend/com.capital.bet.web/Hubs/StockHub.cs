using com.capital.bet.lib.Stocks;
using IdentityModel.Client;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace com.capital.bet.web.Hubs
{
    /// <summary>
    /// Stock Hub for pub/sub
    /// </summary>
    public class StockHub : Hub
    {
        /// <summary>
        /// Stock rate observable
        /// </summary>
        private Subject<List<StockRate>> StockUpdateSubject = new Subject<List<StockRate>>();
        


        private IDisposable stockUpdateSub;


        public StockHub()
        {
            stockUpdateSub = StockUpdateSubject.Subscribe((result) =>
           {
               Clients.All.SendAsync("stocks", result);
           });
        }


        ~StockHub()
        {
            if (stockUpdateSub != null)
                stockUpdateSub.Dispose();
        }


        public void SendNewStocks(List<StockRate> stocks)
        {
            StockUpdateSubject.OnNext(stocks);
        }

    }
}
