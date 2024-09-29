using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.Helper
{
    public class PagentionDTO<T>
    {
        public PagentionDTO(int index, int size, int count, IReadOnlyList<T> data)
        {
            pageIndex = index;
            pageSize = size;
            totalCount = count;
            Data = data;
        }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
