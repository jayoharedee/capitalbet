using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace com.capital.bet.data.Models.Accounts
{
    /// <summary>
    /// Account Type
    /// </summary>
    public class AccountType : AuditableEntity
    {
        /// <summary>
        /// Type Id
        /// </summary>
        [Key]
        public Guid TypeId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string Name { get; set; }
        /// <summary>
        /// Features
        /// </summary>
        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string Features { get; set; }
        /// <summary>
        /// Withdrawal time Limit
        /// </summary>
        [Required]
        public long WithdrawWaitTime { get; set; }
        /// <summary>
        /// Minimum Trade Limit
        /// </summary>
        [Required]
        public decimal MinTradeLimit { get; set; }
        /// <summary>
        /// Max trade Limit
        /// </summary>
        [Required]
        public decimal MaxTradeLimit { get; set; }
        /// <summary>
        /// Minimum Deposit
        /// </summary>
        [Required]
        public decimal MinimumDeposit { get; set; }
        /// <summary>
        /// Daily Trade Cap
        /// </summary>
        [Required]
        public int DailyTradeLimit { get; set; } = -1;
        /// <summary>
        /// Bonus Cash
        /// </summary>
        [Required]
        public decimal Bouns { get; set; }
        /// <summary>
        /// User account navigation
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<UserAccount> UserAccounts { get; set; }

    }
}
