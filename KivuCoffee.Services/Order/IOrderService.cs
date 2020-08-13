using System.Collections.Generic;
using KivuCoffee.Data.Models;

namespace KivuCoffee.Services.Order
{
    public interface IOrderService
    {
        List<SaleOrder> GetOrders();

        ServiceResponse<bool> GenerateInvoiceForOrder(SaleOrder order);

        ServiceResponse<bool> MarkFulfilled(int id);
    }
}