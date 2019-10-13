using System;
using System.Collections.Generic;
using Xunit;
using Project0.Business;

namespace Project0.Test
{
    public class CustomerTest
    {
        private readonly Customer customer = new Customer();
        private readonly List<Order> orders = new List<Order>
        {
            new Order()
        };

        [Fact]
        public void Id_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => customer.Id = -1);
        }

        [Fact]
        public void Id_Returns_Correctly()
        {
            int id = 1;
            customer.Id = id;

            Assert.Equal(id, customer.Id);
        }

        [Fact]
        public void First_Name_Empty_Throws_ArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => customer.FirstName = string.Empty);
        }

        [Fact]
        public void First_Name_Property_Returns_Corectly()
        {
            string firstName = "Joseph";
            customer.FirstName = firstName;

            Assert.Equal(firstName, customer.FirstName);
        }

        [Fact]
        public void Last_Name_Empty_Throws_ArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => customer.LastName = string.Empty);
        }

        [Fact]
        public void Last_Name_Property_Returns_Corectly()
        {
            string lastName = "Mohrbacher";
            customer.LastName = lastName;

            Assert.Equal(lastName, customer.LastName);
        }

        [Fact]
        public void Orders_set_Correctly()
        {
            customer.Orders = orders;

            Assert.Equal(orders, customer.Orders);
        }
    }
}
