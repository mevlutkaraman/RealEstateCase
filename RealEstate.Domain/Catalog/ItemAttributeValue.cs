using RealEstate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Catalog
{
    public sealed class ItemAttributeValue : BaseEntity
    {
        public int ItemAttributeId { get; set; }
        public string Name { get; set; } = null!;
        public ItemAttribute ItemAttribute { get; set; } = null!;
    }
}
