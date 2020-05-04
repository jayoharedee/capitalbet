using com.capital.bet.data.Models.Stocks;
using com.capital.bet.data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.capital.bet.data.Repository
{
    public class StockTickRepository : Repository<StockTick>, IStockTickRepository
    {
        public StockTickRepository(ApplicationDbContext context) : base(context) { }
    }
}
