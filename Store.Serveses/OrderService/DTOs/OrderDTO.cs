using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.OrderService.DTOs
{
    public class OrderDTO
    {
        public string? BasketId { get; set; }
        public string BuyerEmail { get; set; }
        public int? dlivaryMethodid { get; set; }
        public ShepingAdressDTO shepingAdress { get; set; }
    }
}
