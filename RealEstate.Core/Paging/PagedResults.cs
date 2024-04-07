using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Paging
{
    public class PagedResults<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int CurrentCount { get; set; }
        public int TotalPage { get; set; }
        public int TotalCount { get; set; }
        public List<T> Results { get; set; } = null!;
    }
}
