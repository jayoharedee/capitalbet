using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.capital.bet.web.Models
{
    /// <summary>
    /// Stock Trade Request
    /// </summary>
    public class StockTradeRequest
    {
        /// <summary>
        /// Request Date
        /// </summary>
        public DateTime RequestDate { get; set; }
        /// <summary>
        /// Period in minutes
        /// </summary>
        public int Period { get; set; }
        /// <summary>
        /// Amount Of Trade
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Is Going High
        /// </summary>
        public bool IsHigh { get; set; }
        /// <summary>
        /// Currency
        /// </summary>
        public string Currency { get; set; }

    }
}
