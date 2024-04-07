using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Catalog.Specifications.Dtos.ItemAttributeSummaryList
{
    public sealed class ItemAttributeSummaryListSpecification : Specification<ItemAttribute, ItemAttributeSummaryListDto>
    {
        public ItemAttributeSummaryListSpecification()
        {
            Query.AsNoTracking();

            Query.Select(x => new ItemAttributeSummaryListDto
            {
                Id = x.Id,
                Name = x.Name,
                Values = x.AttributeValues.Select(y => new ItemAttributeValueSummaryDto { Id = y.Id, Name = y.Name }).ToList()
            }
            );
        }
    }
}
