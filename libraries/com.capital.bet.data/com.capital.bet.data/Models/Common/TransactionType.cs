using com.capital.bet.data.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace com.capital.bet.data.Models.Common
{
    /// <summary>
    /// Transaction Types
    /// </summary>
    public class TransactionType
    {
        /// <summary>
        /// Type Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Deacription { get; set; }
        /// <summary>
        /// User Wallet Transaction Navigation Property
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<WalletTransaction> WalletTransactions { get; set; }

    }
}
