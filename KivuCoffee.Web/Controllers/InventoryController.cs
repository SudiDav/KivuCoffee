using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KivuCoffee.Services.Inventory;
using KivuCoffee.Web.Serialization;
using KivuCoffee.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KivuCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IInventoryService _inventoryService;

        public InventoryController(ILogger<InventoryController> logger,
            IInventoryService inventoryService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }

        [HttpGet("/api/inventory")]
        public ActionResult GetCurrentInventory()
        {
            _logger.LogInformation("Getting te current inventory!");
            var inventory = _inventoryService.GetCurrentInventory()
                .Select(pi => new ProductInventoryVM
                {
                    Id = pi.Id,
                    QuantityOnHand = pi.QuantityOnHand,
                    IdealQuantity = pi.IdealQuantity,
                    Product = ProductMapper.SerializeProductVM(pi.Product)
                })
                .OrderBy(env => env.Product.Name)
                .ToList();

            return Ok(inventory);
        }

        [HttpPatch("/api/inventory")]
        public ActionResult UpdateInventory([FromBody] ShipmentVM shipmentVm)
        {
            _logger.LogInformation($"Updating Inventory " +
                                   $"for " + $"{shipmentVm.ProductId} - " +
                                   $"adjustment " + $"{shipmentVm.Adjustment}");
            var id = shipmentVm.ProductId;
            var adjustment = shipmentVm.Adjustment;

            var inventoryToUpdate =
                    _inventoryService.UpdateUnitsAvailable(id, adjustment);

            return Ok(inventoryToUpdate);
        }
    }
}