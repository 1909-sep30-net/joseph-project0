using System;
using Xunit;
using Project0.Business;

namespace Project0.Test
{
    public class CustomerTest
    {
        [Fact]
        public void First_Name_Empty_Throws_ArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => new Customer(string.Empty, "Mohrbacher"));
        }

        [Fact]
        public void Last_Name_Empty_Throws_ArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => new Customer("Joseph", string.Empty));
        }

        [Fact]
        public void First_Name_Returns_Corectly()
        {
            string firstName = "Joseph";
            string lastName = "Mohrbacher";
            var customer = new Customer(firstName, lastName);

            Assert.Equal(firstName, customer.FirstName);
        }

        [Fact]
        public void Last_Name_Returns_Corectly()
        {
            string firstName = "Joseph";
            string lastName = "Mohrbacher";
            var customer = new Customer(firstName, lastName);

            Assert.Equal(lastName, customer.LastName);
        }
    }
}
