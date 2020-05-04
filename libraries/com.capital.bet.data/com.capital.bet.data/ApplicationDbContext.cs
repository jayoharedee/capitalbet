using com.capital.bet.data.Models;
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


            builder.Entity<ApplicationUser>()
                .HasOne<UserAccount>(m => m.Account)
                .WithOne(m => m.User)
                .HasForeignKey<ApplicationUser>(m=>m.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

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
                .HasOne<ApplicationUser>(m => m.User)
                .WithMany(m => m.Options)
                .HasForeignKey(m => m.UserId)
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
