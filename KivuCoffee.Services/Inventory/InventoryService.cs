using System;
using System.Collections.Generic;
using System.Text;
using KivuCoffee.Data.Models;

namespace KivuCoffee.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        public List<ProductInventory> GetCurrentInventory()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment)
        {
            throw new NotImplementedException();
        }

        public ProductInventory GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public void CreateSnapshot()
        {
            throw new NotImplementedException();
        }

        public List<ProductInventorySnapShot> GetSnapShotHistory()
        {
            throw new NotImplementedException();
        }
    }
}