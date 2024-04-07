using RealEstate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Catalog
{
    public sealed class Item : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public  ICollection<ItemImage> Images { get; set; } = null!;
        public  ICollection<ItemAttributeMapping> Attributes { get; set; } = null!;
    }
}
