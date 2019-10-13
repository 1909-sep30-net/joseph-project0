using System;
using System.Collections.Generic;

namespace Project0.Data.Entities
{
    public partial class Products
    {
        public Products()
        {
            ProductEntry = new HashSet<ProductEntry>();
            ProductOrder = new HashSet<ProductOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPerUnit { get; set; }

        public virtual ICollection<ProductEntry> ProductEntry { get; set; }
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }
    }
}
