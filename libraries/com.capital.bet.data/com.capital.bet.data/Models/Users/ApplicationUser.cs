using com.capital.bet.data.Models.Accounts;
using com.capital.bet.data.Models.Tranactions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace com.capital.bet.data.Models.Users
{
    /// <summary>
    /// Application User Accounts
    /// </summary>
    public class ApplicationUser : IdentityUser, IAuditableEntity
    {
        /// <summary>
        /// Is Enabled
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        /// <summary>
        /// User Account Information
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }
        [JsonIgnore]
        public virtual UserAccount Account { get; set; }
        /// <summary>
        /// Created By
        /// </summary>
        [MaxLength(256)]
        public string CreatedBy { get; set; }
        /// <summary>
        /// Updated By
        /// </summary>
        [MaxLength(256)]
        public string UpdatedBy { get; set; }
        /// <summary>
        /// Updated Date
        /// </summary>
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Create Date
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        /// <summary>
        /// First Name
        /// </summary>
        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string LastName { get; set; }
        /// <summary>
        /// Mobile Phone
        /// </summary>
        [StringLength(25)]
        public string MobileNumber { get; set; }
        /// <summary>
        /// Profile Image Url
        /// </summary>
        [DataType(DataType.ImageUrl)]
        [StringLength(256)]
        public string ProfileImage { get; set; }
        /// <summary>
        /// User Options Navigation Property
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Option> Options { get; set; }

    }
}
