using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Paging
{
    public class PaginationHelper
    {
        public static int DefaultPage => 1;
        public static int DefaultPageSize => 10;

        public static int CalculateTake(int? pageSize)
        {
            pageSize = pageSize is null or <= 0 ? DefaultPageSize : pageSize;
            return (int)pageSize;
        }

        public static int CalculateTake(BaseFilter baseFilter)
        {
            var pageSize = baseFilter.PageSize is null or <= 0 ? DefaultPageSize : baseFilter.PageSize;
            return (int)pageSize;
        }

        public static int CalculateSkip(int? pageSize, int? page)
        {
            page = page is null or <= 0 ? DefaultPage : page;
            pageSize = pageSize is null or <= 0 ? DefaultPageSize : pageSize;
            return (int)(pageSize * (page - 1));
        }

        public static int CalculateSkip(BaseFilter baseFilter)
        {
            return CalculateSkip(baseFilter.PageSize, baseFilter.PageIndex);
        }

        public static async Task<PagedResults<T>> CreatePagedResults<T>(List<T> results, int page, int pageSize,
            int totalNumberOfRecords)
        {
            var mod = totalNumberOfRecords % pageSize;
            var totalPageCount = (totalNumberOfRecords / pageSize) + (mod == 0 ? 0 : 1);

            return await Task.FromResult(new PagedResults<T>
            {
                Results = results,
                PageIndex = page,
                PageSize = pageSize,
                TotalPage = totalPageCount,
                TotalCount = totalNumberOfRecords
            });
        }

        public static async Task<PagedResults<T>> CreatePagedResults<T>(List<T> results, BaseFilter baseFilter,
            int totalNumberOfRecords)
        {
            baseFilter.PageIndex ??= DefaultPage;
            baseFilter.PageSize ??= DefaultPageSize;

            var mod = totalNumberOfRecords % baseFilter.PageSize;
            var totalPageCount = ((totalNumberOfRecords / baseFilter.PageSize) + (mod == 0 ? 0 : 1)).Value;

            return await Task.FromResult(new PagedResults<T>
            {
                Results = results,
                PageIndex = baseFilter.PageIndex.Value,
                PageSize = baseFilter.PageSize.Value,
                CurrentCount = results.Count,
                TotalPage = totalPageCount,
                TotalCount = totalNumberOfRecords
            });
        }
    }
}
