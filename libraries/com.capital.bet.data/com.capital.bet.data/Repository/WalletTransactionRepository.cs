using com.capital.bet.data.Models.Accounts;
using com.capital.bet.data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.capital.bet.data.Repository
{
    public class WalletTransactionRepository : Repository<WalletTransaction>, IWalletTranactionRepository
    {
        public WalletTransactionRepository(ApplicationDbContext context) : base(context) { }
    }
}
