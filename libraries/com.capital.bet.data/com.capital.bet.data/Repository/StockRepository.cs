using com.capital.bet.data.Models.Stocks;
using com.capital.bet.data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.capital.bet.data.Repository
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(ApplicationDbContext context) : base(context) { }
    }
}
