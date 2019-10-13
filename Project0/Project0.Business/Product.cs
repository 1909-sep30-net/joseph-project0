using System;

namespace Project0.Business
{
    /// <summary>
    /// the container for holding product information
    /// </summary>
    public class Product
    {
        private int _id; // product ID
        private string _name; // name of the product
        private decimal _costPerUnit;

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

        public decimal CostPerUnit
        {
            get => _costPerUnit;
            set
            {
                if (value < 0.0M)
                    throw new ArgumentException("CostPerUnit cannot be less than 0", nameof(value));

                _costPerUnit = value;
            }
        }
    }
}
