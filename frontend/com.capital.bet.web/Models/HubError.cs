using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.capital.bet.web.Models
{
    /// <summary>
    /// Hub Error Message
    /// </summary>
    public class HubError
    {
        /// <summary>
        /// Error Id
        /// </summary>
        public int ErrorId { get; set; }
        /// <summary>
        /// Error Message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public HubError() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Error Id</param>
        /// <param name="messgge">Error Message</param>
        public HubError(int id, string messgge) 
        {
            this.ErrorId = id;
            this.ErrorMessage = messgge;  
        }

    }
}
