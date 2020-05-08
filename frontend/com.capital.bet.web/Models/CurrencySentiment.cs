using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.capital.bet.web.Models
{
    /// <summary>
    /// Currency Sentiment For Currency
    /// </summary>
    public class CurrencySentiment
    {
        /// <summary>
        /// Currency
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// High Bids Count
        /// </summary>
        public int HighBids { get; set; }
        /// <summary>
        /// Low Bids Count
        /// </summary>
        public int LowBids { get; set; }
        /// <summary>
        /// Amount Traded in High 
        /// </summary>
        public decimal VolumeHigh { get; set; }
        /// <summary>
        /// Amount Traded in Low
        /// </summary>
        public decimal VolumeLow { get; set; }

    }
}
