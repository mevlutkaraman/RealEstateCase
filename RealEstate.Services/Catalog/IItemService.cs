using RealEstate.Core.Paging;
using RealEstate.Domain.Catalog.Specifications.Dtos.ItemDetail;
using RealEstate.Domain.Catalog.Specifications.Dtos.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Catalog
{
    public interface IItemService
    {
        Task<ItemDetailDto> GetItemDetailAsync(ItemDetailQuery query);
        Task<PagedResults<ItemsDto>> GetItemsAsync(ItemsQuery query);
    }
}
