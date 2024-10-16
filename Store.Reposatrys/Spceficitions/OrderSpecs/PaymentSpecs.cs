using Store.Data.Entites.OrderEntityies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys.Spceficitions.OrderSpecs
{
    public class PaymentSpecs : BaseSpceifictions<Order>
    {
        public PaymentSpecs(string? paymentIntent)
            : base(order => order.PaymentIntentId == paymentIntent)
        {
        }
    }
}
