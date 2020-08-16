using System;
using System.Collections.Generic;
using System.Linq;
using KivuCoffee.Data;
using KivuCoffee.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KivuCoffee.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext _db;
        private readonly ILogger<InventoryService> _logger;

        public InventoryService(AppDbContext db, ILogger<InventoryService> logger)
        {
            _db = db;
            _logger = logger;
        }

        /// <summary>
        /// Get All inventories from the db
        /// </summary>
        /// <returns>List<ProductInventory></returns>
        public List<ProductInventory> GetCurrentInventory()
        {
            return _db.ProductInventories
                .Include(pi => pi.Product)
                .Where(pi => !pi.Product.IsArchive)
                .ToList();
        }

        /// <summary>
        /// Updates the number of unites available of the provided productId
        /// </summary>
        /// <param name="id">productId</param>
        /// <param name="adjustment">number of unit to add/remove from the inventory</param>
        /// <returns>ServiceResponse<ProductInventory></returns>
        public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment)
        {
            var now = DateTime.UtcNow;
            try
            {
                var inventory = _db.ProductInventories
                    .Include(inv => inv.Product)
                    .First(inv => inv.Product.Id == id);

                inventory.QuantityOnHand += adjustment;

                try
                {
                    CreateSnapshot(inventory);
                }
                catch (Exception e)
                {
                    _logger.LogError("Error occured while Creating inventory snapshot.");
                    _logger.LogError(e.StackTrace);
                }

                _db.SaveChanges();

                return new ServiceResponse<ProductInventory>
                {
                    IsSucess = true,
                    Time = now,
                    Message = "Product Updated Successfully",
                    Data = inventory
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<ProductInventory>
                {
                    IsSucess = false,
                    Time = now,
                    Message = $"Error Updating ProductInventory QuantityOnHand with ID : {id} - {e.StackTrace} ",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Get a ProductInventory instance by ProductId
        /// </summary>
        /// <param name="productId">productId</param>
        /// <returns></returns>
        public ProductInventory GetProductById(int productId)
        {
            return _db.ProductInventories
                .Include(pi => pi.Product)
                .FirstOrDefault(pi => pi.Product.Id == productId);
        }

        /// <summary>
        /// Return Snapshot history for the previous 6 hours
        /// </summary>
        /// <returns></returns>
        public List<ProductInventorySnapShot> GetSnapShotHistory()
        {
            var earliest = DateTime.UtcNow - TimeSpan.FromHours(6);

            return _db.ProductInventorySnapShots
                .Include(snap => snap.Product)
                .Where(snap => snap.SnapShotTime > earliest
                          && !snap.Product.IsArchive)
                .ToList();
        }

        /// <summary>
        /// Create a Snapshot record using the provided ProductInventory instance
        /// </summary>
        /// <param name="inventory">inventory</param>
        private void CreateSnapshot(ProductInventory inventory)
        {
            var now = DateTime.UtcNow;

            var snapshot = new ProductInventorySnapShot
            {
                SnapShotTime = now,
                Product = inventory.Product,
                QuantityOnHand = inventory.QuantityOnHand
            };
            _db.Add(snapshot);
        }
    }
}