using Store.Data.Entites;
using Store.Serveses.ProductServes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Store.Data.Entites.Type;

namespace Store.Serveses.ProductServes
{
    public interface IProductServes
    {
        Task<ProductDTO> GetProductAsync(int id);
        Task<IReadOnlyList<ProductDTO>> GetProductsAsync();
        Task<IReadOnlyList<Brand>> GetBrandsAsync();
        Task<IReadOnlyList<Type>> GetTypeAsync();
    }
}
