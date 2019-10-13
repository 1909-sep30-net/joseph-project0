using System;
using System.Collections.Generic;
using Xunit;
using Project0.Business;

namespace Project0.Test
{
    public class ProductTest
    {
        readonly Product product = new Product();

        [Fact]
        public void Name_Empty_Throws_ArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => product.Name = string.Empty);
        }

        [Fact]
        public void Name_Returns_Correctly()
        {
            string name = "name";
            product.Name = name;

            Assert.Equal(name, product.Name);
        }

        [Fact]
        public void CostPerUnit_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => product.CostPerUnit = -1M);
        }

        [Fact]
        public void CostPerUnit_Returns_Correctly()
        {
            decimal cost = 1M;
            product.CostPerUnit = cost;

            Assert.Equal(cost, product.CostPerUnit);
        }
    }
}
