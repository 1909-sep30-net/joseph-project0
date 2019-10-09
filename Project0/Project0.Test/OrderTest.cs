using System;
using System.Collections.Generic;
using Xunit;
using Project0.Business;

namespace Project0.Test
{
    public class OrderTest
    {
        [Fact]
        public void OrderLocation_Returns_Correctly()
        {
            Location location = new Location("location");
            Customer customer = new Customer("firstName", "lastName");
            Order order = new Order(location, customer);

            Assert.Equal(location, order.OrderLocation);
        }

        [Fact]
        public void OrderCustomer_Returns_Correctly()
        {
            Location location = new Location("location");
            Customer customer = new Customer("firstName", "lastName");
            Order order = new Order(location, customer);

            Assert.Equal(customer, order.OrderCustomer);
        }

        [Fact]
        public void AddProduct_Returns_Correctly()
        {
            Location location = new Location("location");
            Customer customer = new Customer("firstName", "lastName");
            Order order = new Order(location, customer);
            List<Product> products = new List<Product>()
            { new Product("a", 10),
              new Product("b", 20)
            };

            foreach (Product p in products)
                order.AddProduct(p);

            Assert.Equal(products, order.OrderPoducts);
        }

        [Fact]
        public void AddProduct_Properly_Adds_To_Products_Correctly()
        {
            Location location = new Location("location");
            Customer customer = new Customer("firstName", "lastName");
            Order order = new Order(location, customer);

            List<Product> products = new List<Product>()
            { new Product("a", 30),
            };

            Product product = new Product("a", 10);
            order.AddProduct(product);
            order.AddProduct(product);
            order.AddProduct(product);

            Assert.Equal(products, order.OrderPoducts);
        }
    }
}
