using RealEstate.Data.Repositories;
using RealEstate.Domain.Catalog.Specifications.Dtos.ItemAttributeSummaryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Catalog
{
    public sealed class ItemAttributeService : IItemAttributeService
    {
        private readonly IItemAttributeRepository _itemAttributeRepository;

        public ItemAttributeService(IItemAttributeRepository itemAttributeRepository)
        {
            _itemAttributeRepository = itemAttributeRepository;
        }

        public async Task<List<ItemAttributeSummaryListDto>> GetSummariesAsync()
        {
            var itemAttributeSpec = new ItemAttributeSummaryListSpecification();
            var itemAttributes = await _itemAttributeRepository.ListAsync(itemAttributeSpec);
            return itemAttributes;
        }
    }
}
