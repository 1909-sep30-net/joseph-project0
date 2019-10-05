using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Business
{
    public class Location
    {
        private string _name;
        private List<Product> _inventory;

        public string LocationName
        {
            get => _name;
        }

        Location(string name)
        {
            if (name.Length == 0)
            {
                throw new ArgumentException("Name must not be empty.", nameof(name));
            }

            _name = name;
        }
    }
}
