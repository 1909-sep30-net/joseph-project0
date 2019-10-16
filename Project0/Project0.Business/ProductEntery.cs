using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Business
{
    /// <summary>
    /// productEntery controls the logic of product entries in location inventory
    /// </summary>
    public class ProductEntery
    {
        private int _id;                // id of the product entry
        private string _name;           // the name of the product
        private int _locationId;        // the id of the location this product belongs to
        private int _productId;         // the id of the product
        private int _quantity;          // the quantity of this product in inventory
        private decimal _pricePerUnit;  // price for one unit of this product

        /// <summary>
        /// property of the _name field
        /// throws ArgumentException when name is empty
        /// </summary>
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

        /// <summary>
        /// property of the _id field
        /// throws ArgumentException when name is empty
        /// </summary>
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

        /// <summary>
        /// property of the _locationId
        /// throws ArgumentException for ids less than 0
        /// </summary>
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

        /// <summary>
        /// property for the _productId
        /// throws ArgumentException for product ids less than 0
        /// </summary>
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

        /// <summary>
        /// property for the _quantity field
        /// throws ArgumentException for quantities less than 0
        /// </summary>
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

        /// <summary>
        /// property for the _pricePerUnite field
        /// throws ArgumentException for prices less than 0
        /// </summary>
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
