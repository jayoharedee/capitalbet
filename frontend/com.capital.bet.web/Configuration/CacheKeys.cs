using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.capital.bet.web.Configuration
{
    /// <summary>
    /// Memory Cache Keys 
    /// </summary>
    public class CacheKeys
    {
        /// <summary>
        /// Current Stock Trades cache
        /// </summary>
        public static readonly string STOCK_CURRENT_TRADES = "com.capital.bet.trades.current";
        /// <summary>
        /// Current Trader Sentiments
        /// </summary>
        public static readonly string STOCK_TRADERS_SENTIMENT = "com.capital.bet.trades.senitment";
        /// <summary>
        /// Current Currency Sentiment
        /// </summary>
        public static readonly string STOCK_CURRENCY_SENTIMENT = "com.capital.bet.currency.senitment";

    }
}
