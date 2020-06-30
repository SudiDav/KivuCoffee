using System;
using System.Collections.Generic;
using System.Text;

namespace KivuCoffee.Data.Models
{
    public class ProductInventorySnapShot
    {
        public int Id { get; set; }
        public DateTime SnapShotTime { get; set; }
        public int QuantityOnHand { get; set; }
        public Product Product { get; set; }
    }
}