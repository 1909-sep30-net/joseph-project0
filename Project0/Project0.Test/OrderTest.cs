using System;
using System.Collections.Generic;
using Xunit;
using Project0.Business;

namespace Project0.Test
{
    public class OrderTest
    {
        private readonly List<ProductEntery> inventory = new List<ProductEntery>()
        {
            new ProductEntery()
            {
                Id = 1,
                LocationId = 1,
                ProductId = 1,
                Quantity = 1,
                PricePerUnit = 1,
            }
        };

        private readonly Order order = new Order();

        [Fact]
        public void Id_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => order.Id = -1);
        }

        [Fact]
        public void Id_Returns_Correctly()
        {
            int id = 1;
            order.Id = id;

            Assert.Equal(id, order.Id);
        }

        [Fact]
        public void LocationId_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => order.LocationId = -1);
        }

        [Fact]
        public void LocationId_Returns_Correctly()
        {
            int id = 1;
            order.LocationId = id;

            Assert.Equal(id, order.LocationId);
        }

        [Fact]
        public void CustomerId_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => order.CustomerId = -1);
        }

        [Fact]
        public void CustomerId_Returns_Correctly()
        {
            int id = 1;
            order.CustomerId = id;

            Assert.Equal(id, order.CustomerId);
        }
    }
}
