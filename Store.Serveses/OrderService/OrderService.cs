using AutoMapper;
using Store.Data.Entites;
using Store.Data.Entites.OrderEntityies;
using Store.Reposatrys.Interfaces;
using Store.Reposatrys.Spceficitions;
using Store.Reposatrys.Spceficitions.OrderSpecs;
using Store.Serveses.BasketService;
using Store.Serveses.OrderService;
using Store.Serveses.OrderService.DTOs;
using Store.Serveses.ProductServes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IBasketService _basket;
        private readonly IProductServes _product;
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public OrderService(IBasketService basket, IProductServes product, IUnitOfWork unit, IMapper mapper)
        {

            _basket = basket;
            _product = product;
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<OrderDetailsDTO> CreateOrderAsync(OrderDTO orderDTO)
        {
            var basket = await _basket.GetBasketAsync(Guid.Parse(orderDTO.BasketId));
            if (basket is null)
                throw new Exception("basket not exist");
            #region 1
            var orderItems = new List<OrderItem>();
            foreach (var item in basket.basketItems)
            {
                var productitem = await _product.GetProductAsync(item.productId);
                if (productitem is null)
                    throw new Exception($"product with id {item.productId} not exsit");

                var orderitem = new OrderItem
                {
                    Price = productitem.Price,
                    Quntity = item.count,
                    PictureUrl = productitem.PictureUrl,
                    ProductId = productitem.Id,
                    ProductName = productitem.Name,
                };
                orderItems.Add(orderitem);
            }
            #endregion

            #region 2
            var delveryMethod = await _unit.reposatry<DlivaryMethod>().Getbyid(orderDTO.dlivaryMethodid);
            if (delveryMethod is null)
                throw new Exception("Delverymethod not exist");

            #endregion

            #region 3
            var subtotal = orderItems.Sum(x => x.Price * x.Quntity);

            var mapedShippingasdress = _mapper.Map<ShepingAdress>(orderDTO.shepingAdress);

            var order = new Order
            {
                shepingAdress = mapedShippingasdress,
                dlivaryMethodid = orderDTO.dlivaryMethodid,
                Basketid = orderDTO.BasketId,
                SubTotal = subtotal,
                orderItems = orderItems,
                BuyerEmail = orderDTO.BuyerEmail,
            };

            await _unit.reposatry<Order>().Add(order);
            await _unit.ComplteAsync();

            var mapedorder = _mapper.Map<OrderDetailsDTO>(order);

            return mapedorder;

            #endregion

        }

        public async Task<IReadOnlyList<OrderDetailsDTO>> GetAllOrdersAsync(string Email)
        {
            var specs = new OrderWithSpecs(Email);

            var orders = await _unit.reposatry<Order>().GetAll(specs);

            if (orders.Count >= 0)
                throw new Exception("no orders yet");

            var mapedorders = _mapper.Map<IReadOnlyList<OrderDetailsDTO>>(orders);

            return mapedorders;
        }

        public async Task<OrderDetailsDTO> GetOrderByIdAsync(string Id)
        {
            var specs = new OrderWithSpecs(Guid.Parse(Id));

            var order = await _unit.reposatry<Order>().GetbyidWithSpecs(specs);

            if (order is null)
                throw new Exception("no orders yet");

            var mapedorders = _mapper.Map<OrderDetailsDTO>(order);

            return mapedorders;
        }
    }
}
