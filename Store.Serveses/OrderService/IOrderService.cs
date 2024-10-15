using Store.Serveses.OrderService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.OrderService
{
    public interface IOrderService
    {
        Task<OrderDetailsDTO> CreateOrderAsync(OrderDTO orderDTO);
        Task<IReadOnlyList<OrderDetailsDTO>> GetAllOrdersAsync(string Email);
        Task<OrderDetailsDTO> GetOrderByIdAsync(string Id);
    }
}
