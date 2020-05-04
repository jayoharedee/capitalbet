using com.capital.bet.data.Models.Common;
using com.capital.bet.data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.capital.bet.data.Repository
{
    public class TransactionTypeRepository : Repository<TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(ApplicationDbContext context): base(context) { }
    }
}
