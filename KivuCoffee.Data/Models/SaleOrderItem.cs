using System;
using System.Collections.Generic;
using System.Text;

namespace KivuCoffee.Data.Models
{
    public class SaleOrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}