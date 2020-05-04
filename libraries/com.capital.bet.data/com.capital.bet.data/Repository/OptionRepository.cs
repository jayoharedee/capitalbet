using com.capital.bet.data.Models.Tranactions;
using com.capital.bet.data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.capital.bet.data.Repository
{
    public class OptionRepository : Repository<Option>, IOptionRepository
    {
        public OptionRepository(ApplicationDbContext context) : base(context) { }
    }
}
