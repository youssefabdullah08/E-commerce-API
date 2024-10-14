using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entites.OrderEntityies
{
    public class Order : BaseEntity<Guid>
    {
        public string BuyerEmail { get; set; }
        public DateTimeOffset date { get; set; } = DateTimeOffset.Now;
        public ShepingAdress shepingAdress { get; set; }
        public DlivaryMethod dlivaryMethod { get; set; }
        public int? dlivaryMethodid { get; set; }
        public PaymentStatus paymentStatus { get; set; } = PaymentStatus.pending;
        public IReadOnlyList<OrderItem> orderItems { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GetTotal()
            => SubTotal + dlivaryMethod.Price;
        public string Basketid { get; set; }

    }
}
