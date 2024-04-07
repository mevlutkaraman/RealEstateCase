using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Catalog.Specifications.Dtos.ItemAttributeSummaryList
{
    public sealed class ItemAttributeSummaryListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<ItemAttributeValueSummaryDto> Values { get; set; } = null!;
    }

    public sealed class ItemAttributeValueSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
