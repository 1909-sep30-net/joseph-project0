using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Order
    {
        public Location location = new Location();
        public Customer customer = new Customer();
        public DateTime dateOfOrder;

        public List<Product> products;
    }
}
