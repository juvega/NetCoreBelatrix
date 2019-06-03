﻿using System.Collections.Generic;

namespace Belatrix.WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Supplier Supplier { get; set; }
    }
}
