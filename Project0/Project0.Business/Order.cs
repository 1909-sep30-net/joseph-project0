using System;
using System.Linq;
using System.Collections.Generic;

namespace Project0.Business
{
    /// <summary>
    /// container for holding an order made
    /// </summary>
    public class Order
    {
        private int _id; // order ID
        private int _locationId;
        private int _customerId;
        
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

        public int LocationId
        {
            get => _locationId;
            set
            {
                if (value < 0)
                    throw new ArgumentException("ID cannot be < 0", nameof(value));

                _locationId = value;
            }
        }

        public int CustomerId
        {
            get => _customerId;
            set
            {
                if (value < 0)
                    throw new ArgumentException("ID cannot be < 0", nameof(value));

                _customerId = value;
            }
        }

        public DateTime Time { get; set; }

        public List<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

        public decimal TotalPrice
        {
            get
            {
                if (ProductOrders?.Count > 0)
                {
                    return ProductOrders.Sum(p => p.PricePerUnit);
                }

                return 0.00M;
            }
        }

        public void AddProduct(ProductOrder product)
        {
            int index = ProductOrders.IndexOf(product);
            if (index < 0)
            {
                ProductOrders.Add(product);
            }
            else
            {
                ProductOrders[index].Quantity += product.Quantity;
            }
        }
    }
}
