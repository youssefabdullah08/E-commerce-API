using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entites;
using Store.Serveses.ProductServes;
using Store.Serveses.ProductServes.DTOs;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IProductServes serves;

        public StoreController(IProductServes serves)
        {
            this.serves = serves;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetAllProducts()
         => Ok(await serves.GetProductsAsync());


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetAllbrands()
            => Ok(await serves.GetBrandsAsync());

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetAllTyeps()
         => Ok(await serves.GetTypeAsync());

    }
}
