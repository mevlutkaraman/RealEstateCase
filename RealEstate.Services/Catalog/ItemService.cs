using RealEstate.Core.Paging;
using RealEstate.Data.Repositories;
using RealEstate.Domain.Catalog.Specifications.Dtos.ItemDetail;
using RealEstate.Domain.Catalog.Specifications.Dtos.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Catalog
{
    public sealed class ItemService : IItemService
    {
        public readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
                _itemRepository = itemRepository;
        }

        public async Task<ItemDetailDto> GetItemDetailAsync(ItemDetailQuery  query)
        {
            var itemDetailSpec = new ItemDetailSpecification(query);
            var item = await _itemRepository.FirstOrDefaultAsync(itemDetailSpec);
            if (item is null)
                throw new NullReferenceException("Item not found.");

            return item;
        }

        public async Task<PagedResults<ItemsDto>> GetItemsAsync(ItemsQuery query)
        {
            var itemsSpec = new ItemsSpecification(query);
            var items = await _itemRepository.ListAsync(itemsSpec);

            var itemsCountSpec= new ItemsCountSpecification(query);
            var count = await _itemRepository.CountAsync(itemsCountSpec);

            var result = await PaginationHelper.CreatePagedResults(items, query, count);
            return result;
        }
    }
}
