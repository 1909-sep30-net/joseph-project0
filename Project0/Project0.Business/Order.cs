using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.Business
{
    /// <summary>
    /// container for holding an order made
    /// </summary>
    public class Order
    {
        private Location _location; // location the order was placed at
        private Customer _customer; // the customer that placed the order
        private DateTime _timeOfOrder = new DateTime(); // the time that the order was made
        private List<Product> _products = new List<Product>(); // the products perchased in the order

        public Location OrderLocation { get => _location; }
        public Customer OrderCustomer { get => _customer; }
        public DateTime OrderTime { get => _timeOfOrder; }
        public List<Product> OrderPoducts { get => _products; }

        /// <summary>
        /// creates a new order
        /// automaticly sets the time of order at creation
        /// </summary>
        /// <param name="location">the location the order was placed at</param>
        /// <param name="customer">the customer that perchased the ordert</param>
        public Order(Location location, Customer customer)
        {
            _location = location;
            _customer = customer;
            _timeOfOrder = DateTime.Now;
        }

        /// <summary>
        /// adds a product to the order
        /// if the product is allready in the order it adds the quantitys together
        /// </summary>
        /// <param name="product">product to add to the order</param>
        public void AddProduct(Product product)
        {
            int index = _products.FindIndex(item => item.Name == product.Name);
            if (index < 0)
            {
                _products.Add(product);
            }
            else
            {
                _products[index].AddQuantity(product.Quantity);
            }
        }
    }
}
