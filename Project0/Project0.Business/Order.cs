using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.Business
{
    public class Order
    {
        private Location _location;
        private Customer _customer;

        private DateTime _timeOfOrder = new DateTime();

        private List<Product> _products = new List<Product>();

        Order(Location location, Customer customer, ICollection<Product> products)
        {
            _location = location;
            _customer = customer;
            _timeOfOrder = DateTime.Now;
            _products = products.ToList();
        }
    }
}
