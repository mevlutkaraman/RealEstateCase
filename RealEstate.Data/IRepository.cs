using Ardalis.Specification;
using RealEstate.Core;

namespace RealEstate.Data
{
    public interface IRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
