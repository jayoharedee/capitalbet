using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace com.capital.bet.data.Models.Users
{
    /// <summary>
    /// Application User Role
    /// </summary>
    public class ApplicationRole : IdentityRole, IAuditableEntity
    {
        public ApplicationRole() { }

        public ApplicationRole(string roleName) : base(roleName)
        {

        }

        public ApplicationRole(string roleName, string description) : base(roleName)
        {
            Description = description;
        }


        public string Description { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Navigation property for the users in this role.
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<IdentityUserRole<string>> Users { get; set; }

        /// <summary>
        /// Navigation property for claims in this role.
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<IdentityRoleClaim<string>> Claims { get; set; }
    }
}
