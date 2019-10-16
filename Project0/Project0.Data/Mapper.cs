using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.Data
{
    /// <summary>
    /// static class that contains all the mapper methods
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// convert an entity customer to an object customer
        /// </summary>
        /// <param name="customer">customer object to be converted</param>
        /// <returns>cusotmer object</returns>
        public static Business.Customer MapCustomerToOrders(Entities.Customers customer)
        {
            return new Business.Customer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Orders = customer.Orders.Select(MapOrder).ToList(),
            };
        }

        /// <summary>
        /// convert an object customer to an entity customer
        /// </summary>
        /// <param name="customer">customer object to be converted</param>
        /// <returns>customer entity</returns>
        public static Entities.Customers MapCustomerToOrders(Business.Customer customer)
        {
            return new Entities.Customers
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                TotalPurchases = customer.TotalPurchases,
                Orders = customer.Orders.Select(MapOrder).ToList(),
            };
        }

        /// <summary>
        /// converts an entity location to an object location
        /// adds in the locations inventory and order history
        /// </summary>
        /// <param name="location">location entity to be converted</param>
        /// <returns>location object</returns>
        public static Business.Location MapLocationsToInvetoryToOrders(Entities.Locations location)
        {
            return new Business.Location
            {
                Id = location.Id,
                Name = location.Name,
                Inventory = location.ProductEntry.Select(MapProductEnteries).ToList(),
                Orders = location.Orders.Select(MapOrder).ToList(),
            };

        }

        /// <summary>
        /// converts a location object to a location entity
        /// </summary>
        /// <param name="location">location object to be converted</param>
        /// <returns>location entity</returns>
        public static Entities.Locations MapLocationsToInvetoryToOrders(Business.Location location)
        {
            return new Entities.Locations
            {
                Id = location.Id,
                Name = location.Name,
                TotalSales = location.Total,
                ProductEntry = location.Inventory.Select(MapProductEnteries).ToList(),
                Orders = location.Orders.Select(MapOrder).ToList(),
            };
        }

        /// <summary>
        /// converts a production entery into a production object
        /// </summary>
        /// <param name="product">production entery to be converted</param>
        /// <returns>production object</returns>
        public static Business.ProductEntery MapProductEnteries(Entities.ProductEntry product)
        {
            return new Business.ProductEntery
            {
                Name = product.Product.Name,
                Id = product.Id,
                LocationId = product.LocationId,
                ProductId = product.ProductId,
                Quantity = product.Quantity,
                PricePerUnit = product.Product.CostPerUnit,
            };
        }

        /// <summary>
        /// converts a production entry object into a production entry entity
        /// </summary>
        /// <param name="product">production entry object to be converted</param>
        /// <returns>protuction entry entity</returns>
        public static Entities.ProductEntry MapProductEnteries(Business.ProductEntery product)
        {
            return new Entities.ProductEntry
            {
                Id = product.Id,
                LocationId = product.LocationId,
                ProductId = product.ProductId,
                Quantity = product.Quantity,
            };

        }

        /// <summary>
        /// converts an order entity into an order object
        /// </summary>
        /// <param name="order">oder entity to be converted</param>
        /// <returns>order object</returns>
        public static Business.Order MapOrder(Entities.Orders order)
        {
            return new Business.Order
            {
                Id = order.Id,
                LocationId = order.LocationId,
                CustomerId = order.CustomerId,
                Time = order.OrderDate,
                ProductOrders = order.ProductOrder.Select(MapProductOrder).ToList(),
            };
        }

        /// <summary>
        /// converts an order object into a order entity
        /// </summary>
        /// <param name="order">order object to be converted</param>
        /// <returns>oder entity</returns>
        public static Entities.Orders MapOrder(Business.Order order)
        {
            return new Entities.Orders
            {
                Id = order.Id,
                LocationId = order.LocationId,
                CustomerId = order.CustomerId,
                OrderDate = order.Time,
                TotalCost = order.TotalPrice,
                ProductOrder = order.ProductOrders.Select(MapProductOrder).ToList(),
            };
        }

        /// <summary>
        /// converts a prodution order entity into a production order object
        /// </summary>
        /// <param name="product">production order entity to be converted</param>
        /// <returns>production order object</returns>
        public static Business.ProductOrder MapProductOrder(Entities.ProductOrder product)
        {
            return new Business.ProductOrder
            {
                Name = product.Product.Name,
                Id = product.Id,
                OrderId = product.OrderId,
                ProductId = product.ProductId,
                Quantity = product.Quantity,
                PricePerUnit = product.Product.CostPerUnit,
            };
        }

        /// <summary>
        /// converts a production order object into a production order entity
        /// </summary>
        /// <param name="order">product order to be converted</param>
        /// <returns>production order entity</returns>
        public static Entities.ProductOrder MapProductOrder(Business.ProductOrder order)
        {
            return new Entities.ProductOrder
            {
                Id = order.Id,
                OrderId = order.OrderId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                
            };
        }

        /// <summary>
        /// converts a product entity into a product object
        /// </summary>
        /// <param name="product">product entity to be converted</param>
        /// <returns>product object</returns>
        public static Business.Product MapProduct(Entities.Products product)
        {
            return new Business.Product
            {
                Id = product.Id,
                Name = product.Name,
                CostPerUnit = product.CostPerUnit,
            };
        }

        /// <summary>
        /// converts a product object into a product entity
        /// </summary>
        /// <param name="product">product object to be converted</param>
        /// <returns>product entity</returns>
        public static Entities.Products MapProduct(Business.Product product)
        {
            return new Entities.Products
            {
                Id = product.Id,
                Name = product.Name,
                CostPerUnit = product.CostPerUnit,
            };
        }
    }
}