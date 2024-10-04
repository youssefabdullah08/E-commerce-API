using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys.Basket.Models
{
    public class UserBasket
    {
        public Guid? id { get; set; }
        public int? DlivryMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        public List<BasketItem> basketItems { get; set; } = new List<BasketItem>();
    }
}
