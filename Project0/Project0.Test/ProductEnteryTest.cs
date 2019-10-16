using System;
using System.Collections.Generic;
using Xunit;
using Project0.Business;

namespace Project0.Test
{
    public class ProductEnteryTest
    {
        private readonly ProductEntery productEntery = new ProductEntery();


        [Fact]
        public void Id_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => productEntery.Id = -1);
        }

        [Fact]
        public void Id_Returns_Correctly()
        {
            int id = 1;
            productEntery.Id = id;

            Assert.Equal(id, productEntery.Id);
        }


        [Fact]
        public void Name_Empty_Throws_ArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => productEntery.Name = string.Empty);
        }

        [Fact]
        public void Name_Property_Returns_Corectly()
        {
            string name = "product 1";
            productEntery.Name = name;

            Assert.Equal(name, productEntery.Name);
        }


        [Fact]
        public void LocationId_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => productEntery.LocationId = -1);
        }

        [Fact]
        public void LocationId_Returns_Correctly()
        {
            int id = 1;
            productEntery.LocationId = id;

            Assert.Equal(id, productEntery.LocationId);
        }


        [Fact]
        public void ProductId_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => productEntery.ProductId = -1);
        }

        [Fact]
        public void ProductId_Returns_Correctly()
        {
            int id = 1;
            productEntery.ProductId = id;

            Assert.Equal(id, productEntery.ProductId);
        }


        [Fact]
        public void Quantity_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => productEntery.Quantity = -1);
        }

        [Fact]
        public void Quantity_Returns_Correctly()
        {
            int quantity = 1;
            productEntery.Quantity = quantity;

            Assert.Equal(quantity, productEntery.Quantity);
        }


        [Fact]
        public void PricePerUnit_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => productEntery.PricePerUnit = -1);
        }

        [Fact]
        public void PricePerUnit_Returns_Correctly()
        {
            int price = 1;
            productEntery.PricePerUnit = price;

            Assert.Equal(price, productEntery.PricePerUnit);
        }
    }
}
