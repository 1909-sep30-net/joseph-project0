﻿using System;
using System.Collections.Generic;

namespace Project0.Data.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TotalPurchases { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
