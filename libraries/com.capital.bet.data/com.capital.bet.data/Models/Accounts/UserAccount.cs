using com.capital.bet.data.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace com.capital.bet.data.Models.Accounts
{
    /// <summary>
    /// User Account Information
    /// </summary>
    public class UserAccount : AuditableEntity
    {
        /// <summary>
        /// Account Id
        /// </summary>
        [Key]
        public Guid AcountId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// User 
        /// </summary>
        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        /// <summary>
        /// User Account Balance
        /// </summary>
        [Required]
        public decimal Balance { get; set; } = 0;
        /// <summary>
        /// Wallet Transaction Navigation Property
        /// </summary>
        public virtual ICollection<WalletTransaction> WalletTransactions { get; set; }


    }
}
