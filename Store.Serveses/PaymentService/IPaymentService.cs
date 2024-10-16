using Store.Reposatrys.Basket.Models;
using Store.Serveses.OrderService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.PaymentService
{
    public interface IPaymentService
    {
        Task<UserBasket> createOrUpdatePaymentIntent(UserBasket userBasket);
        Task<OrderDetailsDTO> updatePaymentIntentSucced(string paymentIntent);
        Task<OrderDetailsDTO> updatePaymentIntentFailed(string paymentIntent);

    }
}
