using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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