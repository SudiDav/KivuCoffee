using System;
using System.Collections.Generic;

namespace KivuCoffee.Web.ViewModels
{
    public class InvoiceVM
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CustomerId { get; set; }
        public List<SalesOrderItemVM> LineItems { get; set; }
    }
}