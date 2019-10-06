using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Business
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get => _firstName;
        }

        public string LastName
        {
            get => _lastName;
        }

        public Customer(string firstName, string lastName)
        {
            if (firstName.Length == 0)
                throw new ArgumentException("First name cannot be empty.", nameof(firstName));

            _firstName = firstName;

            if (lastName.Length == 0)
                throw new ArgumentException("Last name cannot be empty.", nameof(lastName));

            _lastName = lastName;
        }
    }
}
