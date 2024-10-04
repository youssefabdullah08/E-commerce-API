using StackExchange;
using StackExchange.Redis;
using Store.Reposatrys.Basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Reposatrys.Basket
{
    public class BasketRepostry : IBasketReposatry
    {
        private readonly IDatabase _DB;
        public BasketRepostry(IConnectionMultiplexer connection)
        {
            _DB = connection.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(Guid id)
       => await _DB.KeyDeleteAsync(id.ToString());

        public async Task<UserBasket> GetBasketAsync(Guid? id)
        {
            var basket = await _DB.StringGetAsync(id.ToString());
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<UserBasket>(basket);
        }

        public async Task<UserBasket> UpdateBasketAsync(UserBasket basket)
        {
            if (basket.id is null)
                basket.id = Guid.NewGuid();

            var IsFound = await _DB.StringSetAsync(basket.id.ToString(), JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if (!IsFound)
                return null;

            return await GetBasketAsync(basket.id);
        }
    }
}
