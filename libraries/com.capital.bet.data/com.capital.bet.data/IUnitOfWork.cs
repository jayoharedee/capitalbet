using com.capital.bet.data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.capital.bet.data
{
    /// <summary>
    /// Db Unit Of Work Pattern
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// User Options
        /// </summary>
        IOptionRepository Options { get; }
        /// <summary>
        /// Option Transactions
        /// </summary>
        IOptionTranactionRepository OptionTranactions { get; }
        /// <summary>
        /// Supported Stocks
        /// </summary>
        IStockRepository Stocks { get; }
        /// <summary>
        /// Stock Tick History
        /// </summary>
        IStockTickRepository StockTicks { get; }
        /// <summary>
        /// Transaction Types
        /// </summary>
        ITransactionTypeRepository TransactionTypes { get; }
        /// <summary>
        /// User Accounts
        /// </summary>
        IUserAccountRepository UserAccounts { get; }
        /// <summary>
        /// Wallet Transactions
        /// </summary>
        IWalletTranactionRepository WalletTranactions { get; }
        /// <summary>
        /// Account Types
        /// </summary>
        IAccountTypeRepository AccountTypes { get; }

        /// <summary>
        /// Save Changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
        /// <summary>
        /// Save Changes Async
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}
