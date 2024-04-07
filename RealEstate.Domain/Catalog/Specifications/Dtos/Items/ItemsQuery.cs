using RealEstate.Core.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Catalog.Specifications.Dtos.Items
{
    public sealed class ItemsQuery : BaseFilter
    {
        public string? SearchText { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public List<int>? AttributeValues { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set;}
    }
}
