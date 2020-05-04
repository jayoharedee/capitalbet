using System;
using System.Collections.Generic;
using System.Text;

namespace com.capital.bet.data.Models
{
    /// <summary>
    /// Change Tracking Interface
    /// </summary>
    public interface IAuditableEntity
    {
        /// <summary>
        /// Created By User
        /// </summary>
        string CreatedBy { get; set; }
        /// <summary>
        /// Updated By User
        /// </summary>
        string UpdatedBy { get; set; }
        /// <summary>
        /// Date Created
        /// </summary>
        DateTime CreatedDate { get; set; }
        /// <summary>
        /// Date Updated
        /// </summary>
        DateTime UpdatedDate { get; set; }


    }
}
