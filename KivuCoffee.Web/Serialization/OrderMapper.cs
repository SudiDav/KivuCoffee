using System;
using System.Collections.Generic;
using System.Linq;
using KivuCoffee.Data.Models;
using KivuCoffee.Web.ViewModels;

namespace KivuCoffee.Web.Serialization
{
    /// <summary>
    /// Handles mapping Order data models to and from related View models
    /// </summary>
    public static class OrderMapper
    {
        /// <summary>
        /// Maps on Invoice View Model to the SalesOrder data Model
        /// </summary>
        /// <param name="invoiceVm"></param>
        /// <returns>Invoice view model</returns>
        public static SalesOrder SerializeInvoiceOrder(InvoiceVM invoiceVm)
        {
            var salesOrderItems = invoiceVm.LineItems
                .Select(item => new SalesOrderItem
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Product = ProductMapper.SerializeProductVM(item.Product)
                }).ToList();

            return new SalesOrder
            {
                SaleOrderItems = salesOrderItems,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
            };
        }

        /// <summary>
        /// Maps a collection of SalesOrder data to Order View models
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public static List<OrderVM> SerializeOrdersToViewModels(IEnumerable<SalesOrder> orders)
        {
            return orders.Select(order => new OrderVM
            {
                Id = order.Id,
                CreatedOn = order.CreatedOn,
                UpdatedOn = order.UpdatedOn,
                SaleOrderItems = SerializeSalesOrderItems(order.SaleOrderItems),
                Customer = CustomerMapper.SerializeCustomer(order.Customer),
                IsPaid = order.IsPaid
            }).ToList();
        }

        /// <summary>
        /// Maps a collection of SalesOrderItems data to SalesOrderItemsViewModels
        /// </summary>
        /// <param name="orderItems"></param>
        /// <returns></returns>
        private static List<SalesOrderItemVM> SerializeSalesOrderItems(IEnumerable<SalesOrderItem> orderItems)
        {
            return orderItems.Select(item => new SalesOrderItemVM
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Product = ProductMapper.SerializeProductVM(item.Product)
            }).ToList();
        }
    }
}