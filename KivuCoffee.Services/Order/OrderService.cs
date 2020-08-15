using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using KivuCoffee.Data;
using KivuCoffee.Data.Models;
using KivuCoffee.Services.Inventory;
using KivuCoffee.Services.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KivuCoffee.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;
        private readonly ILogger<OrderService> _logger;
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;

        public OrderService(AppDbContext db,
            ILogger<OrderService> logger,
            IInventoryService inventoryService,
            IProductService productService)
        {
            _db = db;
            _logger = logger;
            _inventoryService = inventoryService;
            _productService = productService;
        }

        public List<SaleOrder> GetOrders() =>
            _db.SaleOrders
                .Include(so => so.Customer)
                    .ThenInclude(customer => customer.PrimaryAddress)
                .Include(so => so.SaleOrderItems)
                    .ThenInclude(item => item.Product)
                .ToList();

        /// <summary>
        /// Create an open Sale Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public ServiceResponse<bool> GenerateOpenOrder(SaleOrder order)
        {
            var now = DateTime.UtcNow;

            _logger.LogInformation("Generating open oder");

            foreach (var item in order.SaleOrderItems)
            {
                item.Product = _productService
                    .GetProductById(item.Product.Id);
                var inventoryId = _inventoryService
                    .GetProductById(item.Product.Id).Id;
                _inventoryService
                    .UpdateUnitsAvailable(inventoryId, -item.Quantity);
            }

            try
            {
                _db.SaleOrders.Add(order);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    IsSucess = true,
                    Data = true,
                    Message = "Open Order Created",
                    Time = now
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSucess = false,
                    Data = false,
                    Message = $"Failed Order Created - {e.Message}",
                    Time = now
                };
            }
        }

        /// <summary>
        /// Marks an open salesOrder as paid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> MarkFulfilled(int id)
        {
            var now = DateTime.UtcNow;
            var order = _db.SaleOrders.Find(id);
            order.UpdatedOn = now;
            order.IsPaid = true;

            try
            {
                _db.SaleOrders.Update(order);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    IsSucess = true,
                    Data = true,
                    Message = $"Order {order.Id} is Closed: Invoice is fully paid! ",
                    Time = now
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSucess = false,
                    Data = false,
                    Message = e.StackTrace,
                    Time = now
                };
            }
        }
    }
}