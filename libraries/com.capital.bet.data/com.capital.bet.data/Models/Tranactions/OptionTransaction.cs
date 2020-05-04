using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace com.capital.bet.data.Models.Tranactions
{
    /// <summary>
    /// Option Transaction Tracking
    /// </summary>
    public class OptionTransaction : AuditableEntity
    {
        /// <summary>
        /// Transaction Id
        /// </summary>
        [Key]
        public Guid TransactionId { get; set; }
        /// <summary>
        /// Option
        /// </summary>
        [Required]
        public Guid OptionId { get; set; }
        [JsonIgnore]
        public virtual Option Option { get; set; }
        /// <summary>
        /// Opening Rate
        /// </summary>
        [Required]
        public decimal OpenRate { get; set; }
        /// <summary>
        /// Closing Rate
        /// </summary>
        [Required]
        public decimal CloseRate { get; set; }
        /// <summary>
        /// Amount
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

    }
}
