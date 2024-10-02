using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys.Spceficitions.ProductSpecs
{
    public class ProductSpecfictions
    {

        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public int pageIndex { get; set; } = 1;
        private const int MAXPAGESIZE = 50;
        private int pageSize = 6;
        public int PageSize
        {
            get => pageSize;
            set => pageSize = (value > MAXPAGESIZE) ? int.MaxValue : value;
        }
    }
}
