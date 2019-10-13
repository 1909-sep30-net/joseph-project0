using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.Data
{
    public static class Mapper
    {
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

        public static Business.ProductEntery MapProductEnteries(Entities.ProductEntry product)
        {
            return new Business.ProductEntery
            {
                Name = product.Product.Name,
                Id = product.ProductId,
                LocationId = product.LocationId,
                ProductId = product.ProductId,
                Quantity = product.Quantity,
                PricePerUnit = product.Product.CostPerUnit,
            };

        }

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
    }
}