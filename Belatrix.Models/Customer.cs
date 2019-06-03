﻿using System.Collections.Generic;

namespace Belatrix.WebApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public List<Order> Orders { get; set; }
    }
}
