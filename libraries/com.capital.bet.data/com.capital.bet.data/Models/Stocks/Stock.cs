using com.capital.bet.data.Models.Tranactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace com.capital.bet.data.Models.Stocks
{
    /// <summary>
    /// Models the available stock options offered by the system and their meta data
    /// </summary>
    public class Stock : AuditableEntity
    {
        /// <summary>
        /// Stock Unique Id
        /// </summary>
        [Key]
        [StringLength(25, MinimumLength = 3)]
        public string StockId { get; set; }
        /// <summary>
        /// Stock Name
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
        /// <summary>
        /// Stock Description
        /// </summary>
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Description { get; set; }
        /// <summary>
        /// Enabled in System
        /// </summary>
        [Required]
        public bool Enabled { get; set; }
        /// <summary>
        /// PayOut Rate
        /// </summary>
        [Required]
        public decimal PayOutRate { get; set; } = decimal.Parse("0.5");

        /// <summary>
        /// Stock Tick navigation property
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<StockTick> StockTicks { get; set; }

        /// <summary>
        /// Options Navigation Property
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Option> Options { get; set; }
    }
}
