using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.Business
{
    /// <summary>
    /// Container for holding location information
    /// </summary>
    public class Location
    {
        private string _name; // locations name
        private List<Product> _inventory = new List<Product>(); // locations list of produts to sell
        private List<Order> _orders = new List<Order>(); // orders bought from this location

        public string LocationName { get => _name; }
        public List<Product> Inventory { get => _inventory; }
        public List<Order> Orders { get => _orders; }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }
        /// <summary>
        /// Location must hoave a valid name
        /// Trows ArumentException if name is empty
        /// </summary>
        /// <param name="name">locations name must not be empty</param>
        public Location(string name)
        {
            if (name.Length == 0)
            {
                throw new ArgumentException("Name must not be empty.", nameof(name));
            }

            _name = name;
        }

        /// <summary>
        /// Adds a new product to the locations inventory
        /// </summary>
        /// <param name="product">the product to add to locations inventory</param>
        public void AddProduct(Product product)
        {
            if (_inventory.Contains(product))
            {
                int index = _inventory.IndexOf(product);
                _inventory[index].AddQuantity(product.Quantity);
            }
            else
            {
                _inventory.Add(product);
            }
        }

        /// <summary>
        /// process a product to be perchased
        /// throws ArgumentException for products not in the current locations invintory
        /// or quantities larger than the inventories product quantity
        /// </summary>
        /// <param name="product">the product to buy from this location</param>
        public void BuyProduct(Product product)
        {
            int index = _inventory.FindIndex(item => item.Name == product.Name);
            if (index < 0)
                throw new ArgumentException("Product does not exsits in inventory", nameof(product));

            if (_inventory[index].Quantity < product.Quantity)
                throw new ArgumentException("Product quantity is greater than in inventory", nameof(product));

            _inventory[index].BuyQuantity(product.Quantity);
        }
    }
}
