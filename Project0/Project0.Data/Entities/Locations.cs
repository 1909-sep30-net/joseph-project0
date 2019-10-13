using System;
using System.Collections.Generic;

namespace Project0.Data.Entities
{
    public partial class Locations
    {
        public Locations()
        {
            Orders = new HashSet<Orders>();
            ProductEntry = new HashSet<ProductEntry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalSales { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<ProductEntry> ProductEntry { get; set; }
    }
}
