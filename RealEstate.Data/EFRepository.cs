using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class EFRepository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly RealEstateDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public EFRepository(RealEstateDbContext context) : base(context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().Add(entity);

            return await Task.FromResult<TEntity>(entity);
        }

        public override async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Task.FromResult(_context.Entry(entity).State = EntityState.Modified);
        }

        public override async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Task.FromResult(_context.Set<TEntity>().Remove(entity));
        }

        public override async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
