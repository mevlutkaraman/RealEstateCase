using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RealEstate.Data.EntityConfigurations.Catalog;
using RealEstate.Data.Extensions;
using RealEstate.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public sealed class RealEstateDbContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _currentTransaction;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options)
        {
            
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            int result = await base.SaveChangesAsync(cancellationToken);
            return true;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) 
                throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                int result = await SaveChangesAsync();

                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemAttributeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ItemAttributeMappingEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ItemAttributeValueEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ItemImageEntityConfiguration());


            modelBuilder.HasData();

            base.OnModelCreating(modelBuilder);
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
