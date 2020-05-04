using com.capital.bet.data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace com.capital.bet.data.Models.Accounts
{

    /// <summary>
    /// User Account Wallet Transaction
    /// </summary>
    public class WalletTransaction : AuditableEntity
    {
        /// <summary>
        /// Transaction Id
        /// </summary>
        [Key]
        public Guid TransationId { get; set; }
        /// <summary>
        /// Account Id
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }
        [JsonIgnore]
        public virtual UserAccount Account { get; set; }
        /// <summary>
        /// Transaction Type
        /// </summary>
        [Required]
        public int TypeId { get; set; }
        [JsonIgnore]
        public virtual TransactionType Type { get; set; }
        /// <summary>
        /// Amount
        /// </summary>
        [Required]
        public decimal Amount { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        [StringLength(1000)]
        public string Note { get; set; }
    }
}
