using System.Collections.Generic;
using KivuCoffee.Data.Models;

namespace KivuCoffee.Services.Inventory
{
    public interface IInventoryService
    {
        public List<Data.Models.ProductInventory> GetCurrentInventory();

        public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment);

        public ProductInventory GetProductById(int productId);

        public List<ProductInventorySnapShot> GetSnapShotHistory();
    }
}