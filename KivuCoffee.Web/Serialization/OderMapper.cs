using KivuCoffee.Data.Models;
using KivuCoffee.Web.ViewModels;

namespace KivuCoffee.Web.Serialization
{
    /// <summary>
    /// Handles mapping Order data models to and from related View models
    /// </summary>
    public static class OderMapper
    {
        public static SalesOrder SerializeInvoiceOrder(InvoiceVM invoiceVm)
        {
            return new SalesOrder
            {
            };
        }
    }
}