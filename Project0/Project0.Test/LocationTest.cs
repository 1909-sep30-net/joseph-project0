using System;
using System.Collections.Generic;
using Xunit;
using Project0.Business;

namespace Project0.Test
{
    public class LocationTest
    {
        private readonly Location location = new Location();
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

        private readonly List<Order> orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                LocationId = 1,
                CustomerId = 1,
                Time = DateTime.Now,
                ProductOrders = new List<ProductOrder>()
                {
                    new ProductOrder()
                    {
                        Name = "p1",
                        Id = 1,
                        OrderId = 1,
                        ProductId = 1,
                        Quantity = 1,
                        PricePerUnit = 1,
                    }
                }
            }
        };


        [Fact]
        public void Id_Less_Than_0_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => location.Id = -1);
        }

        [Fact]
        public void Id_Returns_Correctly()
        {
            int id = 1;
            location.Id = id;

            Assert.Equal(id, location.Id);
        }

        [Fact]
        public void Name_Empty_Throws_ArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => location.Name = string.Empty);
        }

        [Fact]
        public void LocationName_Returns_Correctly()
        {
            string name = "store name";
            location.Name = name;

            Assert.Equal(name, location.Name);
        }

        [Fact]
        public void Invintory_Property_Returns_Added_Products_Correctly()
        {
            location.Inventory = inventory;

            Assert.Equal(inventory, location.Inventory);
        }

        [Fact]
        public void ValidateOrder_Invalid_Order_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => location.ValidateOrder(orders[0]));
        }

        [Fact]
        public void ValidateOrder_Valid_Order_returns_Correctly()
        {
            location.Orders = orders;
            Assert.Throws<ArgumentException>(() => location.ValidateOrder(orders[0]));
        }

        [Fact]
        public void PlaceOrder_Invalid_Order_Throws_ArgumentException()
        {

            Assert.Throws<ArgumentException>(() => location.PlaceOrder(orders[0]));
        }

        [Fact]
        public void PlaceOrder_Valid_Order_Places_Order()
        {
            location.AddProduct(inventory[0]);
            location.PlaceOrder(orders[0]);

            Assert.Equal(orders, location.Orders);
        }
    }
}
