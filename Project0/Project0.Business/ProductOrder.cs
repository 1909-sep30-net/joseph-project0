using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Business
{
    public class ProductOrder
    {
        private string _name;
        private int _id;
        private int _orderId;
        private int _productId;
        private int _quantity;
        private decimal _pricePerUnit;

        public string Name
        {
            get => _name;
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Name cannot be empty", nameof(value));

                _name = value;
            }
        }

        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id cannot be less than 0", nameof(value));

                _id = value;
            }
        }

        public int OrderId
        {
            get => _orderId;
            set
            {
                if (value < 0)
                    throw new ArgumentException("OrderId cannot be less than 0", nameof(value));

                _orderId = value;
            }
        }

        public int ProductId
        {
            get => _productId;
            set
            {
                if (value < 0)
                    throw new ArgumentException("ProductId cannot be less than 0", nameof(value));

                _productId = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Quantity cannot be less than 0", nameof(value));

                _quantity = value;
            }
        }

        public decimal PricePerUnit
        {
            get => _pricePerUnit;
            set
            {
                if (value < 0)
                    throw new ArgumentException("PricePerUnit cannot be less than 0", nameof(value));

                _pricePerUnit = value;
            }
        }
    }
}
