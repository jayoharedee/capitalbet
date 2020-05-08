using com.capital.bet.data.Models.Stocks;
using com.capital.bet.data.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace com.capital.bet.data.Models.Tranactions
{
    /// <summary>
    /// User Options
    /// </summary>
    public class Option : AuditableEntity
    {
        /// <summary>
        /// Option Id
        /// </summary>
        [Key]
        public Guid OptionId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Transaction Tacking Record
        /// </summary>
        public Guid TranactionId { get; set; }
        [JsonIgnore]
        public virtual OptionTransaction Transaction { get; set; }
        /// <summary>
        /// User Account
        /// </summary>
        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string Username { get; set; }
        /// <summary>
        /// Stock Id
        /// </summary>
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string StockId { get; set; }
        [JsonIgnore]
        public virtual Stock Stock { get; set; }
        /// <summary>
        /// Option State (higher/lower) <see cref="com.capital.bet.data.Models.Tranactions.OptionState"/>
        /// </summary>
        [Required]
        public int OptionState { get; set; }
        /// <summary>
        /// Amount
        /// </summary>
        [Required]
        public decimal Amount { get; set; }
        /// <summary>
        /// Close Time
        /// </summary>
        [Required]
        public DateTime CloseTime { get; set; }
        /// <summary>
        /// Payout Amount
        /// </summary>
        public decimal PayOutAmount { get; set; }

    }
}
