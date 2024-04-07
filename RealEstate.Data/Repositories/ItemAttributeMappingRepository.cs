using RealEstate.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Repositories
{
    public sealed class ItemAttributeMappingRepository : EFRepository<ItemAttributeMapping>, IItemAttributeMappingRepository
    {
        public ItemAttributeMappingRepository(RealEstateDbContext context) : base(context)
        {

        }
    }
}
