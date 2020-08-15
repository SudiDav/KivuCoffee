using System.Collections.Generic;
using KivuCoffee.Data.Models;

namespace KivuCoffee.Services.Order
{
    public interface IOrderService
    {
        List<SalesOrder> GetOrders();

        ServiceResponse<bool> GenerateOpenOrder(SalesOrder order);

        ServiceResponse<bool> MarkFulfilled(int id);
    }
}