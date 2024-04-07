using Microsoft.AspNetCore.Mvc;
using RealEstate.Core.Paging;
using RealEstate.Data.Repositories;
using RealEstate.Domain.Catalog.Specifications.Dtos.ItemAttributeSummaryList;
using RealEstate.Domain.Catalog.Specifications.Dtos.ItemDetail;
using RealEstate.Domain.Catalog.Specifications.Dtos.Items;
using RealEstate.Services.Catalog;

namespace RealEstate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IItemAttributeService _itemAttributeService;

        public CatalogController(IItemService itemService, IItemAttributeService itemAttributeService)
        {
            _itemService = itemService;
            _itemAttributeService = itemAttributeService;
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(ProblemDetails))]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError, type: typeof(ProblemDetails))]
        [HttpGet("item-attribute")]
        public async Task<List<ItemAttributeSummaryListDto>> GetItemAttributeSummaries()
        {
            return await _itemAttributeService.GetSummariesAsync();
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(ProblemDetails))]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError, type: typeof(ProblemDetails))]
        [HttpGet("item-detail")]
        public async Task<ItemDetailDto> GetItemDetail([FromQuery] ItemDetailQuery query)
        {
            return await _itemService.GetItemDetailAsync(query);
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(ProblemDetails))]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError, type: typeof(ProblemDetails))]
        [HttpGet("items")]
        public async Task<PagedResults<ItemsDto>> GetItems([FromQuery]ItemsQuery query)
        {
            return await _itemService.GetItemsAsync(query);
        }
    }
}
