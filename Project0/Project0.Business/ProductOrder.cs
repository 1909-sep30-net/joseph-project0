using System;

namespace Project0.Business
{
    /// <summary>
    /// handles all the logic for a production order
    /// </summary>
    public class ProductOrder
    {
        private int _id;                // id of the product order
        private string _name;           // the name of the product
        private int _orderId;           // the id of the oder this product belongs to
        private int _productId;         // the id of the product
        private int _quantity;          // the quantity of this product ordered
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
        /// property of the _orderId
        /// throws ArgumentException for ids less than 0
        /// </summary>
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
                    throw new ArgumentException("ProductId cannot be less than 0", nameof(value));

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
                    throw new ArgumentException("Quantity cannot be less than 0", nameof(value));

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
                    throw new ArgumentException("PricePerUnit cannot be less than 0", nameof(value));

                _pricePerUnit = value;
            }
        }
    }
}
