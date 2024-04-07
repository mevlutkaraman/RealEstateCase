using RealEstate.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Repositories
{
    public sealed class ItemAttributeRepository :EFRepository<ItemAttribute>, IItemAttributeRepository
    {
        public ItemAttributeRepository(RealEstateDbContext context) : base(context)
        {

        }
    }
}
