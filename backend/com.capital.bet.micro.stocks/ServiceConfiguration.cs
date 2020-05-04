using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.capital.bet.micro.stocks
{
    public interface IServiceConfiguration
    {
        bool SaveToDb { get; set; }
    }

    public class ServiceConfiguration : IServiceConfiguration
    {
        public bool SaveToDb { get; set; }
    }
}
