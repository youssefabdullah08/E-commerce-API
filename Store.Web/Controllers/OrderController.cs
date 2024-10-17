using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Serveses.HandelResponse;
using Store.Serveses.OrderService;
using Store.Serveses.OrderService.DTOs;
using Store.Serveses.PaymentService;
using System.Security.Claims;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;


        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;

        }
        [HttpPost]
        public async Task<ActionResult<OrderDetailsDTO>> CreateOrderAsync(OrderDTO order)
        {
            var Order = await orderService.CreateOrderAsync(order);
            if (Order == null)
                return BadRequest(new Response(400));

            return Ok(Order);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDetailsDTO>>> AllOrders()
        {
            var email = User.FindFirstValue(claimType: ClaimTypes.Email);

            var orders = await orderService.GetAllOrdersAsync(email);
            if (orders == null)
                return NotFound(new Exception("user do not have any orders"));
            return Ok(orders);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDetailsDTO>>> OrderById(Guid id)
        {


            var order = await orderService.GetOrderByIdAsync(id.ToString());

            if (order == null)
                return NotFound(new Exception($"user does not have any order with id :{id}"));

            return Ok(order);
        }
    }
}
