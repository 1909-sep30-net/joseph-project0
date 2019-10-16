using System;
using System.Linq;
using System.Collections.Generic;

namespace Project0.Business
{
    /// <summary>
    /// Container for holding location information
    /// </summary>
    public class Location
    {
        private int _id;        // locations ID
        private string _name;   // locations name

        /// <summary>
        /// property of the _id field
        /// throws an ArgumentEception for ids less than 0
        /// </summary>
        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentException("ID cannot be < 0", nameof(value));

                _id = value;
            }
        }

        /// <summary>
        /// property of the _name field
        /// throws an ArgumentEception for names that are empty
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Name cannot be empty.", nameof(value));

                _name = value;
            }
        }

        /// <summary>
        /// list of all products for sale at this location
        /// </summary>
        public List<ProductEntery> Inventory { get; set; } = new List<ProductEntery>();

        /// <summary>
        /// list of all orders placed at this location
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// generated the totol sales made by this location
        /// based on the oders made
        /// </summary>
        public decimal Total
        {
            get
            {
                if (Orders?.Count > 0)
                {
                    return Orders.Sum(p => p.TotalPrice);
                }

                return 0.00M;
            }
        }

        /// <summary>
        /// validates the products befor adding placing it
        /// all products must in an order must be in the inventoy and having enough in stock
        /// </summary>
        /// <param name="order">the order to be verifide</param>
        public void ValidateOrder(Order order)
        {
            foreach (ProductOrder product in order.ProductOrders)
            {
                int index = Inventory.IndexOf(Inventory.Where(p => p.ProductId == product.ProductId).FirstOrDefault());

                if (index < 0)
                    throw new ArgumentException("Inventory does not have product", nameof(product));

                if (Inventory[index].Quantity < product.Quantity)
                    throw new ArgumentException("Inventory does not have enough of product", nameof(product));
            }
        }

        /// <summary>
        /// vilidates the order and places it into the locations history
        /// reduces the inventory quantitys
        /// </summary>
        /// <param name="order">order to be placed at location</param>
        public void PlaceOrder (Order order)
        {
            ValidateOrder(order);

            foreach (ProductOrder product in order.ProductOrders)
            {
                int index = Inventory.IndexOf(Inventory.Where(p => p.ProductId == product.ProductId).FirstOrDefault());

                Inventory[index].Quantity -= product.Quantity;
            }

            order.Time = DateTime.Now;
            Orders.Add(order);
        }

        /// <summary>
        /// adds a product to the locations inventory
        /// </summary>
        /// <param name="product">product to be add to location inventory</param>
        public void AddProduct(ProductEntery product)
        {
            if (Inventory.Contains(product))
            {
                int index = Inventory.IndexOf(product);
                Inventory[index].Quantity += product.Quantity;
            }
            else
            {
                Inventory.Add(product);
            }
        }
    }
}
