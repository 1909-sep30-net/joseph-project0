using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Business
{
    /// <summary>
    /// Container for holding customer information
    /// </summary>
    public class Customer
    {
        private string _firstName; // customers first name
        private string _lastName; // custumers last name
        private List<Order> _orders = new List<Order>(); // orders made by this customer

        public string FirstName { get => _firstName; }
        public string LastName { get => _lastName; }
        public List<Order> Orders { get => _orders; }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        /// <summary>
        /// each customer object must contain a non empty first and last name.
        /// throws an ArgumentExcetion if either is an emtpy string.
        /// </summary>
        /// <param name="firstName">customers first name</param>
        /// <param name="lastName">customers last name</param>
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
