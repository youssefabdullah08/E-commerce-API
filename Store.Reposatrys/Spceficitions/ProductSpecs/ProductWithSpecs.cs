using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys.Spceficitions.ProductSpecs
{
    public class ProductWithSpecs : BaseSpceifictions<Product>
    {
        public ProductWithSpecs(ProductSpecfictions specfictions)
            : base(product => (!specfictions.BrandId.HasValue || product.BrandId == specfictions.BrandId.Value) &&
                 (!specfictions.TypeId.HasValue || product.TypeId == specfictions.TypeId.Value)
            )
        {
            AddIncludes(x => x.Brand);
            AddIncludes(x => x.Type);
        }
    }
}
