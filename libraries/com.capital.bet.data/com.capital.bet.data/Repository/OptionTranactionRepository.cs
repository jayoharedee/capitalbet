using com.capital.bet.data.Models.Tranactions;
using com.capital.bet.data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.capital.bet.data.Repository
{
    public class OptionTranactionRepository :Repository<OptionTransaction>, IOptionTranactionRepository
    {
        public OptionTranactionRepository(ApplicationDbContext context) : base(context) { }
    }
}
