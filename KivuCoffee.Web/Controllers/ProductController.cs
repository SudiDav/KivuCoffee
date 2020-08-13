using System.Linq;
using KivuCoffee.Services.Product;
using KivuCoffee.Web.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KivuCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("/api/product")]
        public ActionResult GetProduct()
        {
            _logger.LogInformation("Getting all Products!");
            var product = _productService.GetAllProducts();

            var productVM = product.Select(ProductMapper.SerializeProductVM);
            return Ok(productVM);
        }
    }
}