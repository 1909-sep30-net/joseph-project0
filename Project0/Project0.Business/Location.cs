using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.Business
{
    public class Location
    {
        private string _name;
        private List<Product> _inventory;

        public string LocationName
        {
            get => _name;
        }

        public List<Product> Invintory
        {
            get => _inventory;

        }

        Location(string name)
        {
            if (name.Length == 0)
            {
                throw new ArgumentException("Name must not be empty.", nameof(name));
            }

            _name = name;
        }

        public void AddProduct(Product product, int amount)
        {
            if (_inventory.Contains(product))
                throw new ArgumentException($"Product {product.Name} allready exists");

            _inventory.Add(product);
        }

        public void RemoveProduct(Product product)
        {

        }

        public void BuyProduct(Product product, int amount)
        {
            int index = _inventory.IndexOf(product);

            if (index != -1)
            {
                if (_inventory[index].Amount - amount < 0)
                    throw new ArgumentOutOfRangeException($"The amount of {amount} for {product.Name} exceeds inventory amount");

                _inventory[index].Amount -= amount;
            }
            else
            {
                throw new ArgumentException($"Location does not have product {product.Name}");
            }
        }
    }
}
