using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Business
{
    public class ProductEntery
    {
        private int _id;
        private string _name;
        private int _locationId;
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

        public int LocationId
        {
            get => _locationId;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id cannot be less than 0", nameof(value));

                _locationId = value;
            }
        }

        public int ProductId
        {
            get => _productId;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id cannot be less than 0", nameof(value));

                _productId = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id cannot be less than 0", nameof(value));

                _quantity = value;
            }
        }

        public decimal PricePerUnit
        {
            get => _pricePerUnit;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id cannot be less than 0", nameof(value));

                _pricePerUnit = value;
            }
        }
    }
}
