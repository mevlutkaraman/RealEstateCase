using RealEstate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Catalog
{
    public sealed class ItemImage : BaseEntity
    {
        public  int ItemId { get; set; }
        public string Url { get; set; } = null!;
        public bool IsDefault { get; set; }
        public Item Item { get; set; } = null!;
    }
}
