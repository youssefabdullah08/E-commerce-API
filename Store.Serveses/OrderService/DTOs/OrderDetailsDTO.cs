using Store.Data.Entites;
using Store.Data.Entites.OrderEntityies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.OrderService.DTOs
{
    public class OrderDetailsDTO
    {
        public string BuyerEmail { get; set; }
        public DateTimeOffset date { get; set; } = DateTimeOffset.Now;
        public ShepingAdress shepingAdress { get; set; }
        public string dlivaryMethodName { get; set; }

        public PaymentStatus paymentStatus { get; set; } = PaymentStatus.pending;
        public IReadOnlyList<OrderItem> orderItems { get; set; }
        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }
        public decimal ShippingPrice { get; set; }
        public string? PaymentIntentId { get; set; }


    }
}
