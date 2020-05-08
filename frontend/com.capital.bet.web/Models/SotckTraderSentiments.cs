using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.capital.bet.web.Models
{
    /// <summary>
    /// stock Sentiment Data
    /// </summary>
    public class SotckTraderSentiments
    {
        /// <summary>
        /// Object Key
        /// </summary>
        public Guid SentimentId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// User Account 
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Currency
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// Is Going High
        /// </summary>
        public bool IsHigh { get; set; }
        /// <summary>
        /// amount bet
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Expiry Time
        /// </summary>
        public DateTime Expires { get; set; }

    }
}
