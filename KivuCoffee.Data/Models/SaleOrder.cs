﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KivuCoffee.Data.Models
{
    public class SaleOrder
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Customer Customer { get; set; }
        public List<SaleOrderItem> SaleOrderItems { get; set; }
        public bool IsPaid { get; set; }
    }
}