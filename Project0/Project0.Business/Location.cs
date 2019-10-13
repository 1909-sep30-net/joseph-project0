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
        private int _id; // locations ID
        private string _name; // locations name

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
        public List<ProductEntery> Inventory { get; set; } = new List<ProductEntery>();

        public List<Order> Orders { get; set; } = new List<Order>();

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

        public void PlaceOrder (Order order)
        {
            ValidateOrder(order);

            foreach (ProductOrder product in order.ProductOrders)
            {
                int index = Inventory.IndexOf(Inventory.Where(p => p.ProductId == product.ProductId).FirstOrDefault());

                Inventory[index].Quantity -= product.Quantity;
            }

            Orders.Add(order);
        }

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
