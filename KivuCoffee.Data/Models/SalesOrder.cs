using System;
using System.Collections.Generic;
using System.Text;

namespace KivuCoffee.Data.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Customer Customer { get; set; }
        public List<SalesOrderItem> SaleOrderItems { get; set; }
        public bool IsPaid { get; set; }
    }
}