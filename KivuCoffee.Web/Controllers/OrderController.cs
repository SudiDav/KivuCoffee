using KivuCoffee.Services.Customer;
using KivuCoffee.Services.Order;
using KivuCoffee.Web.Serialization;
using KivuCoffee.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KivuCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrderController(ILogger<OrderController> logger,
            IOrderService orderService,
            ICustomerService customerService)
        {
            _logger = logger;
            _orderService = orderService;
            _customerService = customerService;
        }

        [HttpPost("api/invoice")]
        public ActionResult GenerateNewOrder([FromBody] InvoiceVM invoiceVm)
        {
            _logger.LogInformation("Generating Invoice");
            var order = OrderMapper.SerializeInvoiceOrder(invoiceVm);
            order.Customer = _customerService.GetCustomerById(invoiceVm.CustomerId);
            _orderService.GenerateOpenOrder(order);
            return Ok();
        }

        [HttpGet("/api/order")]
        public ActionResult GetOrders()
        {
            var orders = _orderService.GetOrders();
            var orderVm = OrderMapper.SerializeOrdersToViewModels(orders);
            return Ok(orderVm);
        }

        [HttpPatch("/api/order/complete/{id}")]
        public ActionResult GetOrders(int id)
        {
            _logger.LogInformation($"Marking order {id} complete!");
            _orderService.MarkFulfilled(id);
            return Ok();
        }
    }
}