using RealEstate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Catalog
{
    public sealed class ItemAttribute : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<ItemAttributeValue> AttributeValues { get; set; } = null!;
    }
}
