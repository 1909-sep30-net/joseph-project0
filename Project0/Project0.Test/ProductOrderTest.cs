using System;
using System.Collections.Generic;
using Xunit;
using Project0.Business;


namespace Project0.Test
{
    public class ProductOrderTest
    {
        private readonly ProductOrder productOrder = new ProductOrder();


        [Fact]
        public void Id_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => productOrder.Id = -1);
        }

        [Fact]
        public void Id_Returns_Correctly()
        {
            int id = 1;
            productOrder.Id = id;

            Assert.Equal(id, productOrder.Id);
        }


        [Fact]
        public void Name_Empty_Throws_ArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => productOrder.Name = string.Empty);
        }

        [Fact]
        public void Name_Property_Returns_Corectly()
        {
            string name = "product 1";
            productOrder.Name = name;

            Assert.Equal(name, productOrder.Name);
        }


        [Fact]
        public void OrderId_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => productOrder.OrderId = -1);
        }

        [Fact]
        public void OrderId_Returns_Correctly()
        {
            int id = 1;
            productOrder.OrderId = id;

            Assert.Equal(id, productOrder.OrderId);
        }


        [Fact]
        public void ProductId_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => productOrder.ProductId = -1);
        }

        [Fact]
        public void ProductId_Returns_Correctly()
        {
            int id = 1;
            productOrder.ProductId = id;

            Assert.Equal(id, productOrder.ProductId);
        }


        [Fact]
        public void Quantity_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => productOrder.Quantity = -1);
        }

        [Fact]
        public void Quantity_Returns_Correctly()
        {
            int quantity = 1;
            productOrder.Quantity = quantity;

            Assert.Equal(quantity, productOrder.Quantity);
        }


        [Fact]
        public void PricePerUnit_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => productOrder.PricePerUnit = -1);
        }

        [Fact]
        public void PricePerUnit_Returns_Correctly()
        {
            int price = 1;
            productOrder.PricePerUnit = price;

            Assert.Equal(price, productOrder.PricePerUnit);
        }
    }
}
