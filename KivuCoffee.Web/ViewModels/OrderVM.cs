using System;
using System.Collections.Generic;

namespace KivuCoffee.Web.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public CustomerVM Customer { get; set; }
        public List<SalesOrderItemVM> SaleOrderItems { get; set; }
        public bool IsPaid { get; set; }
    }
}