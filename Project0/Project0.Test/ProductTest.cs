using System;
using System.Collections.Generic;
using Xunit;
using Project0.Business;

namespace Project0.Test
{
    public class ProductTest
    {
        [Fact]
        public void Costructor_Empty_Name_Throws_ArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => new Product(string.Empty, 1, 1.0M));
        }

        [Fact]
        public void Costructor_Quantity_Out_Of_Range_Throws_ArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => new Product("a", -1, 1.0M));
        }

        [Fact]
        public void Name_Property_Returns_Correctly()
        {
            string name = "a";
            int quantity = 1;
            decimal cost = 1.0M;
            Product product = new Product(name, quantity, cost);

            Assert.Equal(name, product.Name);
        }


        [Fact]
        public void Quantity_Property_Returns_Correctly()
        {
            string name = "a";
            int quantity = 1;
            decimal cost = 1.0M;
            Product product = new Product(name, quantity, cost);

            Assert.Equal(quantity, product.Quantity);
        }

        [Theory]
        [InlineData(-1)]
        public void AddQuantity_Quantity_Out_Of_range_Throws_ArgumentException(int a)
        {
            Product product = new Product("a", 1, 1.0M);

            Assert.ThrowsAny<ArgumentException>(() => product.AddQuantity(a));
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 10)]
        public void AddQuantity_Adds_Correctly(int a, int b)
        {
            Product product = new Product("a", a, 1.0M);
            product.AddQuantity(a);

            Assert.Equal(b, product.Quantity);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(5, 0)]
        public void BuyQuantity_Subtracts_Correctly(int a, int b)
        {
            Product product = new Product("a", a, 1.0M);
            product.BuyQuantity(a);

            Assert.Equal(b, product.Quantity);
        }
    }
}
