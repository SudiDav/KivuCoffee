using KivuCoffee.Services.Customer;
using KivuCoffee.Services.Order;
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
            return Ok();
        }
    }
}