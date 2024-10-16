using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Data.Entites;
using Store.Data.Entites.OrderEntityies;
using Store.Reposatrys.Basket.Models;
using Store.Reposatrys.Interfaces;
using Store.Reposatrys.Spceficitions.OrderSpecs;
using Store.Serveses.BasketService;
using Store.Serveses.OrderService.DTOs;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork unit;
        private readonly IBasketService basketService;
        private readonly IMapper mapper;

        public PaymentService(IConfiguration configuration
            , IUnitOfWork unit
            , IBasketService basketService
            , IMapper mapper)
        {
            this.configuration = configuration;
            this.unit = unit;
            this.basketService = basketService;
            this.mapper = mapper;
        }
        public async Task<UserBasket> createOrUpdatePaymentIntent(UserBasket userBasket)
        {
            StripeConfiguration.ApiKey = configuration["Stripe:Secretkey"];

            if (userBasket is null)
                throw new Exception("no basket found ");

            var delverymethod = await unit.reposatry<DlivaryMethod>().Getbyid(userBasket.DlivryMethod.Value);

            if (delverymethod is null)
                throw new Exception("not provided ");

            decimal SheppingPrice = delverymethod.Price;

            foreach (var item in userBasket.basketItems)
            {
                var product = await unit.reposatry<Product>().Getbyid(item.productId);
                if (item.Price != product.Price)
                {
                    item.Price = product.Price;
                }

            }
            var service = new PaymentIntentService();
            PaymentIntent PaymentIntent;

            if (string.IsNullOrEmpty(userBasket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)userBasket.basketItems.Sum(x => x.count * (x.Price * 100)) + (long)(SheppingPrice * 100),
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                PaymentIntent = await service.CreateAsync(options);
                userBasket.PaymentIntentId = PaymentIntent.Id;
                userBasket.ClientSecret = PaymentIntent.ClientSecret;

            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long)userBasket.basketItems.Sum(x => x.count * (x.Price * 100)) + (long)(SheppingPrice * 100),

                };
                await service.UpdateAsync(userBasket.PaymentIntentId, options);
            }
            await basketService.UpdateBasketAsync(userBasket);
            return userBasket;

        }

        public async Task<OrderDetailsDTO> updatePaymentIntentFailed(string paymentIntent)
        {
            var specs = new PaymentSpecs(paymentIntent);
            var order = await unit.reposatry<Order>().GetbyidWithSpecs(specs);
            if (order is null)
                throw new Exception("order not exist");

            order.paymentStatus = PaymentStatus.failed;

            unit.reposatry<Order>().Update(order);

            await unit.ComplteAsync();

            var mapedOrder = mapper.Map<OrderDetailsDTO>(order);

            return mapedOrder;

        }

        public async Task<OrderDetailsDTO> updatePaymentIntentSucced(string paymentIntent)
        {
            var specs = new PaymentSpecs(paymentIntent);
            var order = await unit.reposatry<Order>().GetbyidWithSpecs(specs);
            if (order is null)
                throw new Exception("order not exist");

            order.paymentStatus = PaymentStatus.Success;

            unit.reposatry<Order>().Update(order);

            await unit.ComplteAsync();

            await basketService.DeleteBasketAsync(Guid.Parse(order.Basketid));

            var mapedOrder = mapper.Map<OrderDetailsDTO>(order);

            return mapedOrder;
        }
    }
}
