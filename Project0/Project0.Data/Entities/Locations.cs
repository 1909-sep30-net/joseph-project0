using System;
using System.Collections.Generic;

namespace Project0.Data.Entities
{
    public partial class Locations
    {
        public Locations()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
