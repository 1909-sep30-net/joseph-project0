using System;
using System.Collections.Generic;

namespace Project0.Data.Entities
{
    public partial class ProductEntry
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Locations Location { get; set; }
        public virtual Products Product { get; set; }
    }
}
