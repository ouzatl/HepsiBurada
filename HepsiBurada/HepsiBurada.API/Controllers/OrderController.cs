using System.Threading.Tasks;
using HepsiBurada.Common.Logging;
using HepsiBurada.Contract.Contracts.Order;
using HepsiBurada.Service.Services.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace HepsiBurada.API.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICompositeLogger _logger;
        public OrderController(
            IOrderService orderService,
            ICompositeLogger logger
            )
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpPost("create_order")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderContract order)
        {
            if (order == null || string.IsNullOrEmpty(order.ProductCode) || order.Quantity <= 0)
                return BadRequest();

            var result = await _orderService.CreateOrder(order);

            if (result)
                return Ok($"Order created; product {order.ProductCode}, quantity {order.Quantity}");
            else
                return NoContent();
        }
    }
}