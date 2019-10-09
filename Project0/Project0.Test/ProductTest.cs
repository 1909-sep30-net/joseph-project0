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
            Assert.ThrowsAny<ArgumentException>(() => new Product(string.Empty, 1));
        }

        [Fact]
        public void Costructor_Quantity_Out_Of_Range_Throws_ArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => new Product("a", -1));
        }

        [Fact]
        public void Name_Property_Returns_Correctly()
        {
            string name = "a";
            int quantity = 1;
            Product product = new Product(name, quantity);

            Assert.Equal(name, product.Name);
        }


        [Fact]
        public void Quantity_Property_Returns_Correctly()
        {
            string name = "a";
            int quantity = 1;
            Product product = new Product(name, quantity);

            Assert.Equal(quantity, product.Quantity);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void AddQuantity_Quantity_Out_Of_range_Throws_ArgumentException(int a)
        {
            Product product = new Product("a", 1);

            Assert.ThrowsAny<ArgumentException>(() => product.AddQuantity(a));
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 10)]
        public void AddQuantity_Adds_Correctly(int a, int b)
        {
            Product product = new Product("a", a);
            product.AddQuantity(a);

            Assert.Equal(b, product.Quantity);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(5, 0)]
        public void BuyQuantity_Subtracts_Correctly(int a, int b)
        {
            Product product = new Product("a", a);
            product.AddQuantity(a);
            product.BuyQuantity(a);

            Assert.Equal(b, product.Quantity);
        }
    }
}
