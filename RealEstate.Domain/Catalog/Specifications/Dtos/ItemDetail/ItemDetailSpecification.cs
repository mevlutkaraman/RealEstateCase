using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Catalog.Specifications.Dtos.ItemDetail
{
    public sealed class ItemDetailSpecification : Specification<Item,ItemDetailDto>
    {
        public ItemDetailSpecification(ItemDetailQuery query)
        {
            Query.Where(x=>x.Id == query.Id);

            Query.Select(x => new ItemDetailDto
            {
                Id = x.Id,
                Description = x.Description,
                Price = x.Price.ToString(),
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                Images = x.Images.Select(y => new ItemDetailImageDto
                {
                    Id = y.Id,
                    IsDefault = y.IsDefault,
                    Url = y.Url
                }).ToList(),
                Attributes = x.Attributes.Select(y => new ItemDetailAttributeDto
                {
                    Id = y.Id,
                    Name = y.ItemAttributeValue.ItemAttribute.Name,
                    ValueId = y.ItemAttributeValueId,
                    ValueName = y.ItemAttributeValue.Name
                }).ToList()
            });
        }
    }
}
