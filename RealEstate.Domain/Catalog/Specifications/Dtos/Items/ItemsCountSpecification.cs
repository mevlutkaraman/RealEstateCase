using Ardalis.Specification;

namespace RealEstate.Domain.Catalog.Specifications.Dtos.Items
{
    public sealed class ItemsCountSpecification: Specification<Item,ItemsCountDto>
    {
        public ItemsCountSpecification(ItemsQuery query)
        {
            if (!string.IsNullOrEmpty(query.SearchText))
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

            Query.Select(x => new ItemsCountDto { Id = x.Id });
        }
    }
}
