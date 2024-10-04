using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Reposatrys.Basket.Models;
using Store.Serveses.BasketService;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService service;

        public BasketController(IBasketService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult<UserBasket>> GetUserBasketAsync(Guid id)
            => await service.GetBasketAsync(id);

        [HttpPost]
        public async Task<ActionResult<UserBasket>> UpdateUserBasketAsync(UserBasket basket)
           => await service.UpdateBasketAsync(basket);

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUserBasketAsync(Guid id)
           => await service.DeleteBasketAsync(id);

    }
}
