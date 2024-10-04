using Store.Reposatrys.Basket;
using Store.Reposatrys.Basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.BasketService
{
    public class BasketService : IBasketService
    {
        private readonly IBasketReposatry reposatry;

        public BasketService(IBasketReposatry reposatry)
        {
            this.reposatry = reposatry;
        }
        public async Task<bool> DeleteBasketAsync(Guid id)
        => await reposatry.DeleteBasketAsync(id);

        public async Task<UserBasket> GetBasketAsync(Guid id)
        {
            var basket = await reposatry.GetBasketAsync(id);
            if (basket == null)
                return new UserBasket();

            return basket;
        }

        public async Task<UserBasket> UpdateBasketAsync(UserBasket basket)
        {
            var updatedbasket = await reposatry.UpdateBasketAsync(basket);
            return updatedbasket;
        }
    }
}
