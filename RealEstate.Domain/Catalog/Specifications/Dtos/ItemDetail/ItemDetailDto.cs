using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Catalog.Specifications.Dtos.ItemDetail
{
    public sealed class ItemDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Price { get; set; } = null!;

        public List<ItemDetailImageDto> Images { get; set; } = null!;
        public List<ItemDetailAttributeDto> Attributes { get; set; } = null!;
    }

    public sealed class ItemDetailAttributeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ValueId { get; set; }
        public string ValueName { get; set; } = null!;
    }

    public sealed class ItemDetailImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = null!;
        public bool IsDefault { get; set; }
    }
}
