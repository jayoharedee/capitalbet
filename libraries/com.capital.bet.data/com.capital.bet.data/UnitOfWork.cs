using com.capital.bet.data.Repository;
using com.capital.bet.data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.capital.bet.data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        IOptionRepository _options;
        IOptionTranactionRepository _optionTranactions;
        IStockRepository _stocks;
        IStockTickRepository _stockTicks;
        ITransactionTypeRepository _transactionTypes;
        IUserAccountRepository _userAccounts;
        IWalletTranactionRepository _walletTranactions;
        IAccountTypeRepository _accountTypes;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Account Types 
        /// </summary>
        public IAccountTypeRepository AccountTypes 
        {
            get
            {
                if (_accountTypes == null)
                    _accountTypes = new AccountTypeRepository(_context);
                return _accountTypes;
            }
        }
        /// <summary>
        /// User Options
        /// </summary>
        public IOptionRepository Options
        {
            get
            {
                if (_options == null)
                    _options = new  OptionRepository(_context);
                return _options;
            }
        }
        /// <summary>
        /// Option Transactions
        /// </summary>
        public IOptionTranactionRepository OptionTranactions
        {
            get
            {
                if (_optionTranactions == null)
                    _optionTranactions = new OptionTranactionRepository(_context);
                return _optionTranactions;
            }
        }
        /// <summary>
        /// Supported Stocks
        /// </summary>
        public IStockRepository Stocks
        {
            get
            {
                if (_stocks == null)
                    _stocks = new StockRepository(_context);
                return _stocks;
            }
        }
        /// <summary>
        /// Stock Tick History
        /// </summary>
        public IStockTickRepository StockTicks
        {
            get
            {
                if (_stockTicks == null)
                    _stockTicks = new StockTickRepository(_context);
                return _stockTicks;
            }
        }
        /// <summary>
        /// Transaction Types
        /// </summary>
        public ITransactionTypeRepository TransactionTypes
        {
            get
            {
                if (_transactionTypes == null)
                    _transactionTypes = new TransactionTypeRepository(_context);
                return _transactionTypes;
            }
        }
        /// <summary>
        /// User Accounts
        /// </summary>
        public IUserAccountRepository UserAccounts
        {
            get
            {
                if (_userAccounts == null)
                    _userAccounts = new UserAccountRepository(_context);
                return _userAccounts;
            }
        }
        /// <summary>
        /// Wallet Transactions
        /// </summary>
        public IWalletTranactionRepository WalletTranactions
        {
            get
            {
                if (_walletTranactions == null)
                    _walletTranactions = new WalletTransactionRepository(_context);
                return _walletTranactions;
            }
        }



        public int SaveChanges()
        {
            return _context.SaveChanges();
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
