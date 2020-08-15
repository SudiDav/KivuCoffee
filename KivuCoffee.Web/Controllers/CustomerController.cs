using System;
using System.Linq;
using KivuCoffee.Services.Customer;
using KivuCoffee.Web.Serialization;
using KivuCoffee.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KivuCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpPost("/api/customer")]
        public ActionResult CreateCustomer([FromBody] CustomerVM customer)
        {
            _logger.LogInformation("Creating a Customer");
            var now = DateTime.UtcNow;
            customer.CreatedOn = now;
            customer.UpdatedOn = now;
            var customerData = CustomerMapper.SerializeCustomer(customer);
            var newCustomer = _customerService.CreateCustomer(customerData);
            return Ok(newCustomer);
        }

        [HttpGet("/api/customer")]
        public ActionResult GetCustomers()
        {
            _logger.LogInformation("Getting Customers");
            var customers = _customerService.GetAllCustomers();
            var customerVm = customers.Select(customer =>
                new CustomerVM
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PrimaryAddress = CustomerMapper
                        .MapCustomerAddress(customer.PrimaryAddress),
                    CreatedOn = customer.CreatedOn,
                    UpdatedOn = customer.UpdatedOn
                }).OrderByDescending(customer => customer.CreatedOn)
                .ToList();
            return Ok(customerVm);
        }

        [HttpDelete("/api/customer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _logger.LogInformation("Deleting a Customer");
            var response = _customerService.DeleteCustomer(id);
            return Ok(response);
        }
    }
}