using System;
using System.Collections.Generic;
using Xunit;
using Project0.Business;

namespace Project0.Test
{
    public class LocationTest
    {

        List<Product> products = new List<Product>() { new Product("a", 1, 1.0M), new Product("b", 2, 2.0M) };


        [Fact]
        public void Constructor_Empty_Nmae_Throws_ArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => new Location(string.Empty));
        }

        [Fact]
        public void LocationName_Property_Returns_Correctly()
        {
            string locationName = "store name";
            Location location = new Location(locationName);

            Assert.Equal(locationName, location.LocationName);
        }

        [Fact]
        public void Invintory_Property_Returns_Added_Products_Correctly()
        {
            Location location = new Location("Joseph");
            foreach (Product p in products)
                location.AddProduct(p);

            Assert.Equal(products, location.Inventory);
        }

        [Fact]
        public void Buy_Product_Does_Not_Contain_Product_Throws_ArgumentException()
        {
            Location location = new Location("aba");

            Assert.Throws<ArgumentException>(() => location.BuyProduct(products[0]));
        }


        [Fact]
        public void Buy_Product_To_Large_Quantity_Throws_ArgumentException()
        {
            Location location = new Location("aba");
            Product product1 = new Product("a", 1, 1.0M);
            Product product2 = new Product("a", 2, 1.0M);
            location.AddProduct(product1);
            Assert.Throws<ArgumentException>(() => location.BuyProduct(product2));
        }
    }
}
