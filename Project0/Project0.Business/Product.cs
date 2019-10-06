using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Business
{
    public class Product
    {
        private string _name;
        private int _amount;

        public string Name
        {
            get => _name;
        }

        public int Amount
        {
            get => _amount;

            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Amount must be grater than 0", nameof(value));

                _amount = value;
            }
        }

        public Product(string name, int amount)
        {
            if (name.Length == 0)
                throw new ArgumentException("Name must not be empty.", nameof(name));

            _name = name;

            if (amount <= 0)
                throw new ArgumentException("Amount must be grater than 0", nameof(amount));

            _amount = amount;
        }
    }
}
