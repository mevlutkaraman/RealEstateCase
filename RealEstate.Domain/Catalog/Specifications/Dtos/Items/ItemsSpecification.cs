using Ardalis.Specification;
using RealEstate.Core.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Catalog.Specifications.Dtos.Items
{
    public sealed class ItemsSpecification : Specification<Item,ItemsDto>
    {
        public ItemsSpecification(ItemsQuery query)
        {
            if(!string.IsNullOrEmpty(query.SearchText))
            {
                var searchText = query.SearchText.Trim().ToLower();
                Query.Where(x => x.Title.Trim().ToLower().Contains(searchText) ||
                            x.ShortDescription.Trim().ToLower().Contains(searchText) ||
                            x.Description.Trim().ToLower().Contains(searchText));
            }

            if (!string.IsNullOrEmpty(query.Title))
            {
                var title = query.Title.Trim().ToLower();
                Query.Where(x => x.Title.Trim().ToLower().Contains(title));
            }

            if (!string.IsNullOrEmpty(query.ShortDescription))
            {
                var shortDescription = query.ShortDescription.Trim().ToLower();
                Query.Where(x => x.ShortDescription.Trim().ToLower().Contains(shortDescription));
            }

            if (!string.IsNullOrEmpty(query.Description))
            {
                var description = query.Description.Trim().ToLower();
                Query.Where(x => x.Description.Trim().ToLower().Contains(description));
            }

            if (query.AttributeValues is not null && query.AttributeValues.Any())
                Query.Where(x => x.Attributes.Any(y => query.AttributeValues.Contains(y.ItemAttributeValueId)));

            if (query.MinPrice.HasValue && query.MinPrice.Value > 0)
                Query.Where(x => x.Price >= query.MinPrice);

            if (query.MaxPrice.HasValue && query.MaxPrice.Value > 0)
                Query.Where(x => x.Price <= query.MaxPrice);

            Query.AsNoTracking();

            Query.Skip(PaginationHelper.CalculateSkip(query))
                .Take(PaginationHelper.CalculateTake(query));

            Query.Select(x => new ItemsDto 
            {
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Price = x.Price.ToString(),
                Title = x.Title,
                ImageUrl= x.Images.Any() ? x.Images.First().Url : string.Empty
            });
        }
    }
}
