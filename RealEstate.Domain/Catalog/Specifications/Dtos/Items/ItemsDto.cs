using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Catalog.Specifications.Dtos.Items
{
    public sealed class ItemsDto
    {
        public string Title { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
