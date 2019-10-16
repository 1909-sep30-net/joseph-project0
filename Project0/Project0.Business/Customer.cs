using System;
using System.Linq;
using System.Collections.Generic;

namespace Project0.Business
{
    /// <summary>
    /// Container for holding customer information
    /// </summary>
    public class Customer
    {
        private int _id;            // customers ID
        private string _firstName;  // customers first name
        private string _lastName;   // custumers last name

        /// <summary>
        /// property of the _id field
        /// throws an ArgumentException if id is less than 0
        /// </summary>
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

        /// <summary>
        /// property of the _firstName field
        /// throws an ArgumentException if the name is empty
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("First name cannot be empty", nameof(value));

                _firstName = value;
            }
        }

        /// <summary>
        /// propert of the _lastName field
        /// throws an ArgumentException if the name is empty 
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Last name cannot be empty", nameof(value));

                _lastName = value;
            }
        }

        /// <summary>
        /// list of all orders made by this customer
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// generates the total puchases made by this customer
        /// </summary>
        public decimal TotalPurchases
        {
            get
            {
                if (Orders?.Count > 0)
                {
                    return Orders.Sum(p => p.TotalPrice);
                }

                return 0.00M;
            }
        }
    }
}
