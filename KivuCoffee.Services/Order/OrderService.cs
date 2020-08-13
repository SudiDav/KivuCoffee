using System;
using System.Collections.Generic;
using System.Text;
using KivuCoffee.Data.Models;

namespace KivuCoffee.Services.Order
{
    public class OrderService : IOrderService
    {
        public List<SaleOrder> GetOrders()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> GenerateInvoiceForOrder(SaleOrder order)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> MarkFulfilled(int id)
        {
            throw new NotImplementedException();
        }
    }
}