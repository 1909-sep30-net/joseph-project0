using System;
using System.Collections.Generic;

namespace Project0.Data.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            ProductOrder = new HashSet<ProductOrder>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalCost { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Locations Location { get; set; }
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }
    }
}
