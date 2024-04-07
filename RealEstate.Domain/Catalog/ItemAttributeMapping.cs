using RealEstate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Catalog
{
    public sealed class ItemAttributeMapping : BaseEntity
    {
        public int ItemId { get; set; }
        public int ItemAttributeValueId { get; set; }

        public Item Item { get; set; } = null!;
        public ItemAttributeValue ItemAttributeValue { get; set; } = null!;
    }
}
