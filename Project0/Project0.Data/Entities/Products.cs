using System;
using System.Collections.Generic;

namespace Project0.Data.Entities
{
    public partial class Products
    {
        public Products()
        {
            Inventory = new HashSet<Inventory>();
            OrderedProducts = new HashSet<OrderedProducts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderedProducts> OrderedProducts { get; set; }
    }
}
