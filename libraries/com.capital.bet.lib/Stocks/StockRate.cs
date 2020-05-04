using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.capital.bet.lib.Stocks
{
    /// <summary>
    /// Stock Feed Object Data
    /// </summary>
    public class StockRate
    {
        /// <summary>
        /// Currency
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// Rate
        /// </summary>
        [JsonProperty("rate")]
        public decimal Rate { get; set; }
        /// <summary>
        /// Bid
        /// </summary>
        [JsonProperty("bid")]
        public decimal Bid { get; set; }
        /// <summary>
        /// Ask
        /// </summary>
        [JsonProperty("ask")]
        public decimal Ask { get; set; }
        /// <summary>
        /// High
        /// </summary>
        [JsonProperty("high")]
        public decimal High { get; set; }
        /// <summary>
        /// Low
        /// </summary>
        [JsonProperty("low")]
        public decimal Low { get; set; }
        /// <summary>
        /// Open
        /// </summary>
        [JsonProperty("open")]
        public decimal Open { get; set; }
        /// <summary>
        /// Close
        /// </summary>
        [JsonProperty("close")]
        public decimal Close { get; set; }
        /// <summary>
        /// Time Stamp
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

    }
}
