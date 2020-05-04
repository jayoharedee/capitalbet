using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace com.capital.bet.data.Models.Stocks
{
    /// <summary>
    /// Historical Stock Tick Data
    /// </summary>
    public class StockTick
    {
        /// <summary>
        /// Tick Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TickId { get; set; }
        /// <summary>
        /// Stock
        /// </summary>
        [Required]
        public string StockId { get; set; }
        public virtual Stock Stock { get; set; }
        /// <summary>
        /// Rate
        /// </summary>
        [Required]
        public decimal Rate { get; set; }
        /// <summary>
        /// Bid
        /// </summary>
        [Required]
        public decimal Bid { get; set; }
        /// <summary>
        /// Ask
        /// </summary>
        [Required]
        public decimal Ask { get; set; }
        /// <summary>
        /// High
        /// </summary>
        [Required]
        public decimal High { get; set; }
        /// <summary>
        /// Low
        /// </summary>
        [Required]
        public decimal Low { get; set; }
        /// <summary>
        /// Open
        /// </summary>
        [Required]
        public decimal Open { get; set; }
        /// <summary>
        /// Close
        /// </summary>
        [Required]
        public decimal Close { get; set; }
        /// <summary>
        /// Record Time
        /// </summary>
        [Required]
        public DateTime TimeStamp { get; set; }

    }
}
