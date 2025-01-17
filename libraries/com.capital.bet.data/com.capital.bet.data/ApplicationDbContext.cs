﻿using com.capital.bet.data.Models;
using com.capital.bet.data.Models.Accounts;
using com.capital.bet.data.Models.Common;
using com.capital.bet.data.Models.Stocks;
using com.capital.bet.data.Models.Tranactions;
using com.capital.bet.data.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace com.capital.bet.data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


        public DbSet<UserAccount> UserAccounts { get; set; }

        public DbSet<WalletTransaction> WalletTransactions { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<StockTick> StockTicks { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<OptionTransaction> OptionTransactions { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }


        public string CurrentUserId { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            const string priceDecimalType = "decimal(18,2)";
            const string stockDecimalType = "decimal(17,3)";

            //builder.Entity<UserAccount>()
            //    .HasOne<AccountType>(m => m.AccountType)
            //    .WithMany(m => m.UserAccounts)
            //    .HasForeignKey(m => m.AcountId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<ApplicationUser>()
            //    .HasOne<UserAccount>(m => m.Account)
            //    .WithOne(m => m.User)
            //    .HasForeignKey<ApplicationUser>(m=>m.AccountId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WalletTransaction>()
                .HasOne<UserAccount>(m => m.Account)
                .WithMany(m => m.WalletTransactions)
                .HasForeignKey(m => m.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WalletTransaction>()
                .HasOne<TransactionType>(m => m.Type)
                .WithMany(m => m.WalletTransactions)
                .HasForeignKey(m => m.TypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<StockTick>()
                .HasOne<Stock>(m => m.Stock)
                .WithMany(m => m.StockTicks)
                .HasForeignKey(m => m.StockId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<OptionTransaction>()
                .HasOne<Option>(m => m.Option)
                .WithOne(m => m.Transaction)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Option>()
                .HasOne<Stock>(m => m.Stock)
                .WithMany(m => m.Options)
                .HasForeignKey(m => m.StockId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<StockTick>()
                .HasOne<Stock>(m => m.Stock)
                .WithMany(m => m.StockTicks)
                .HasForeignKey(m => m.StockId)
                .OnDelete(DeleteBehavior.NoAction);



            builder.Entity<StockTick>().Property(p => p.Ask).HasColumnType(stockDecimalType);
            builder.Entity<StockTick>().Property(p => p.Bid).HasColumnType(stockDecimalType);
            builder.Entity<StockTick>().Property(p => p.Rate).HasColumnType(stockDecimalType);
            builder.Entity<StockTick>().Property(p => p.High).HasColumnType(stockDecimalType);
            builder.Entity<StockTick>().Property(p => p.Low).HasColumnType(stockDecimalType);
            builder.Entity<StockTick>().Property(p => p.Open).HasColumnType(stockDecimalType);
            builder.Entity<StockTick>().Property(p => p.Close).HasColumnType(stockDecimalType);
            builder.Entity<OptionTransaction>().Property(p => p.OpenRate).HasColumnType(stockDecimalType);
            builder.Entity<OptionTransaction>().Property(p => p.CloseRate).HasColumnType(stockDecimalType);
            builder.Entity<OptionTransaction>().Property(p => p.Amount).HasColumnType(priceDecimalType);
            builder.Entity<Stock>().Property(p => p.PayOutRate).HasColumnType(priceDecimalType);
            builder.Entity<UserAccount>().Property(p => p.Balance).HasColumnType(priceDecimalType);
            builder.Entity<WalletTransaction>().Property(p => p.Amount).HasColumnType(priceDecimalType);
            builder.Entity<Option>().Property(p => p.Amount).HasColumnType(priceDecimalType);
            builder.Entity<Option>().Property(p => p.PayOutAmount).HasColumnType(priceDecimalType);



            builder.Entity<AccountType>().HasData(new AccountType()
            {
                DailyTradeLimit = 10,
                MinimumDeposit = 100,
                MaxTradeLimit = 100,
                MinTradeLimit = 1,
                Bouns = 0,
                Features = "Free Account",
                Name = "Free Account",
                TypeId = Guid.Parse("094FFAB4-DACA-4D25-8DD3-DC9F70056CDB"),
                WithdrawWaitTime = 604800000
            },
            new AccountType()
            {
                DailyTradeLimit = 10,
                MinimumDeposit = 1000,
                MaxTradeLimit = 100,
                MinTradeLimit = 1,
                Bouns = (decimal)0.1,
                Features = "Beginner Account",
                Name = "Beginner Account",
                TypeId = Guid.Parse("5D8E21FD-5193-41E6-BAD6-0FB6DDD3907A"),
                WithdrawWaitTime = 172800000
            },
            new AccountType()
            {
                DailyTradeLimit = 10,
                MinimumDeposit = 3000,
                MaxTradeLimit = 100,
                MinTradeLimit = 1,
                Bouns = (decimal)0.3,
                Features = "Standard Account",
                Name = "Standard Account",
                TypeId = Guid.Parse("56F920EF-D83D-4C5F-A1F5-15507D0541D8"),
                WithdrawWaitTime = 86400000
            }, new AccountType()
            {
                DailyTradeLimit = -1,
                MinimumDeposit = 5000,
                MaxTradeLimit = 1000,
                MinTradeLimit = 1,
                Bouns = (decimal)0.5,
                Features = "Professional Account",
                Name = "Professional Account",
                TypeId = Guid.Parse("A705B56D-2467-47F6-843E-9D6D9537D228"),
                WithdrawWaitTime = 86400000
            });


            // Add Roles
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole()
            {
                Id = Guid.Parse("CB210F02-C9DF-4BF3-8EA4-351852DDC432").ToString(),
                Name = "administrator",
                NormalizedName = "ADMINISTRATOR",
                Description = "Administrative role used to run the system",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            }, new ApplicationRole()
            {
                Id = Guid.Parse("974BE833-B074-4778-9B74-CA83E601DBBF").ToString(),
                Name = "trade_moderator",
                NormalizedName = "TRADE_MODERATOR",
                Description = "System Moderator role for users running projects",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            }, new ApplicationRole()
            {
                Id = Guid.Parse("818352CA-D178-407B-B8F4-48AC2EE6F3AC").ToString(),
                Name = "tradder",
                NormalizedName = "TRADDER",
                Description = "General user Account with minimal permissions.",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });


            // add Default stocks
            builder.Entity<Stock>().HasData(new Stock()
            {
                Description= "EUR/USD",
                StockId= "EUR_USD",
                Enabled=true,
                Name= "EUR/USD",
                PayOutRate=new decimal(0.6)
            },
            new Stock()
            {
                Description = "GBP/USD",
                StockId = "GBP_USD",
                Enabled = true,
                Name = "GBP/USD",
                PayOutRate = new decimal(0.6)
            },
            new Stock()
            {
                Description = "EUR/JPY",
                StockId = "EUR_JPY",
                Enabled = true,
                Name = "EUR/JPY",
                PayOutRate = new decimal(0.6)
            },
            new Stock()
            {
                Description = "USD/JPY",
                StockId = "USD_JPY",
                Enabled = true,
                Name = "USD/JPY",
                PayOutRate = new decimal(0.6)
            },
            new Stock()
            {
                Description = "AUD/USD",
                StockId = "AUD_USD",
                Enabled = true,
                Name = "AUD/USD",
                PayOutRate = new decimal(0.6)
            },
            new Stock()
            {
                Description = "USD/CAD",
                StockId = "USD_CAD",
                Enabled = true,
                Name = "USD/CAD",
                PayOutRate = new decimal(0.6)
            },
            new Stock()
            {
                Description = "EUR/GBP",
                StockId = "EUR_GBP",
                Enabled = true,
                Name = "EUR/GBP",
                PayOutRate = new decimal(0.6)
            },
            new Stock()
            {
                Description = "BTC/USD",
                StockId = "BTC_USD",
                Enabled = true,
                Name = "BTC/USD",
                PayOutRate = new decimal(0.6)
            },
            new Stock()
            {
                Description = "BTC/EUR",
                StockId = "BTC_EUR",
                Enabled = true,
                Name = "BTC/EUR",
                PayOutRate = new decimal(0.6)
            },
            new Stock()
            {
                Description = "EUR/AUD",
                StockId = "EUR_AUD",
                Enabled = true,
                Name = "EUR/AUD",
                PayOutRate = new decimal(0.6)
            },
            new Stock()
            {
                Description = "CAD/JPY",
                StockId = "CAD_JPY",
                Enabled = true,
                Name = "CAD/JPY",
                PayOutRate = new decimal(0.6)
            },
            new Stock()
            {
                Description = "GBP/JPY",
                StockId = "GBP_JPY",
                Enabled = true,
                Name = "GBP/JPY",
                PayOutRate = new decimal(0.6)
            },
            new Stock()
            {
                Description = "AUD/CAD",
                StockId = "AUD_CAD",
                Enabled = true,
                Name = "AUD/CAD",
                PayOutRate = new decimal(0.6)
            },
            new Stock()
            {
                Description = "AUD/JPY",
                StockId = "AUD_JPY",
                Enabled = true,
                Name = "AUD/JPY",
                PayOutRate = new decimal(0.6)
            },
            new Stock()
            {
                Description = "EUR/CAD",
                StockId = "EUR_CAD",
                Enabled = true,
                Name = "EUR/CAD",
                PayOutRate = new decimal(0.6)
            });

            builder.Entity<TransactionType>().HasData(
                new TransactionType()
                {
                    TypeId=1,
                    Name="Deposit Funds",
                    Deacription="The user deposited funds into their account."
                },
                new TransactionType()
                {
                    TypeId = 2,
                    Name = "Trade Loss",
                    Deacription = "The user has had funds removed from a failed trade."
                },
                new TransactionType()
                {
                    TypeId = 3,
                    Name = "Trade Gain",
                    Deacription = "The user has gained funds in their account from a successful trade."
                },
                new TransactionType()
                {
                    TypeId = 4,
                    Name = "Withdraw Funds",
                    Deacription = "The user has withdrawn funds from their account."
                }
                );

        }


        #region Overrides / Audit

        public override int SaveChanges()
        {
            UpdateAuitFields();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateAuitFields();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuitFields();
            return base.SaveChangesAsync(cancellationToken);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuitFields();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateAuitFields()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));


            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                DateTime now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = CurrentUserId;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = CurrentUserId;
            }
        }


        #endregion Overrides / Audit
    }
}
