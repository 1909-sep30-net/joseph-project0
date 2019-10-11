using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Business
{
    /// <summary>
    /// the container for holding product information
    /// </summary>
    public class Product
    {
        private string _name; // name of the product
        private int _quantity; // the quantity of the product

        public string Name { get => _name; }
        public int Quantity { get => _quantity; }

        /// <summary>
        /// creates a product with the given name and quantity
        /// throws ArgumentException for empty name valuesand out of range quantities
        /// </summary>
        /// <param name="name">name of the product</param>
        /// <param name="quantity">the quantity of the product</param>
        public Product(string name, int quantity)
        {
            if (name.Length == 0)
                throw new ArgumentException("Name must not be empty.", nameof(name));

            _name = name;

            if (quantity < 0)
                throw new ArgumentException("Amount must be grater than 0", nameof(quantity));

            _quantity = quantity;
        }

        /// <summary>
        /// add the amount to the product
        /// throws ArgumentException if quantity is out of range
        /// </summary>
        /// <param name="quantity">non negative quantity to add to product</param>
        public void AddQuantity(int quantity)
        {
            if (quantity < 0)
                throw new ArgumentException($"Quantity {quantity} can not be less than 0");

            _quantity += quantity;
        }
        public void BuyQuantity(int quantity)
        {
            if (quantity < 0 || quantity > _quantity)
                throw new ArgumentException($"Quantity of {quantity} product is out of range");

            _quantity -= quantity;
        }
    }
}
