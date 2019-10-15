
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project0.Data.Entities;
using Project0.Business;
using Serilog;

namespace Project0.Data
{
    public class DataBase : IDisposable
    {
        private readonly Project0Context _context;

        public DataBase(Project0Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Save()
        {
            Log.Information("Saving changes to database");
            _context.SaveChanges();
        }

        public void AddCustomer(Customer customer)
        {
            if (customer.Id != 0)
            {
                Log.Warning("Customer allready exist in database allreay exists", customer.Id);
                throw new ArgumentException("Customer allready exists in database");
            }
            else
            {
                Customers entity = Mapper.MapCustomerToOrders(customer);
                _context.Add(entity);

                Log.Information("Added {FirstName} {LastName} to database", customer.FirstName, customer.LastName);
            }
        }

        public void AddLocation(Location location)
        {
            if (location.Id != 0)
            {
                Log.Information("Added {Name} to database allreay exists", location.Name);
                throw new ArgumentException("Location allready exists in database");
            }

            Locations entity = Mapper.MapLocationsToInvetoryToOrders(location);
            _context.Add(entity);
        }

        public void AddProduct(Product product)
        {
            if (product.Id != 0)
            {
                Log.Information("Added {Name} to database allreay exists", product.Name);
                throw new ArgumentException("Location allready exists in database");
            }

            Products entity = Mapper.MapProduct(product);
            _context.Add(entity);
        }



        public IEnumerable<Customer> GetAllCustomers(string firstName = null, string lastName = null, int? id = null)
        {
            IQueryable<Customers> items = _context.Customers
                .Include(r => r.Orders);

            if (firstName != null)
                items = items.Where(c => c.FirstName == firstName);
            if (lastName != null)
                items = items.Where(c => c.LastName == lastName);
            if (id != null)
                items = items.Where(c => c.Id == id);

            return items.Select(Mapper.MapCustomerToOrders);
        }

        public IEnumerable<Location> GetAllLocations(string name = null, int? id = null)
        {
            IQueryable<Locations> items = _context.Locations
                .Include(r => r.ProductEntry).Include(r => r.Orders);

            if (name != null)
                items = items.Where(n => n.Name == name);
            if (id != null)
                items = items.Where(i => i.Id == id);

            return items.Select(Mapper.MapLocationsToInvetoryToOrders);
        }

        public IEnumerable<Product> GetAllProducts(string name = null, int? id = null)
        {
            IQueryable<Products> items = _context.Products.Include(r => r);

            if (name != null)
                items = items.Where(p => p.Name == name);
            if (id != null)
                items = items.Where(p => p.Id == id);

            return items.Select(Mapper.MapProduct);
        }

        public void UpdateCustomer(Business.Customer customer)
        {
            Customers currentEntity = _context.Customers.Find(customer.Id);
            Customers newEntity = Mapper.MapCustomerToOrders(customer);

            _context.Entry(currentEntity).CurrentValues.SetValues(newEntity);
        }

        public void UpdateLocation(Business.Location location)
        {
            Locations currentEntity = _context.Locations.Find(location.Id);
            Locations newEntity = Mapper.MapLocationsToInvetoryToOrders(location);

            _context.Entry(currentEntity).CurrentValues.SetValues(newEntity);
        }
        
        public void DeleteCustomer(Customer customer)
        {
            Log.Information("Removing customer with id {Id}", customer.Id);

            Customers entity = _context.Customers.Find(customer.Id);
            IQueryable<Orders> orders = _context.Orders.Where(p => p.CustomerId == customer.Id);

            DeleteOrders(orders);

            _context.Remove(entity);
        }

        public void DeleteLocation(Location location)
        {
            Log.Information("Removing location with id {Id}", location.Id);

            Locations entity = _context.Locations.Find(location.Id);
            IQueryable<Orders> orders = _context.Orders.Where(p => p.LocationId == location.Id);

            DeleteProductEntries(location.Id);
            DeleteOrders(orders);
            _context.Remove(entity);
        }

        public void DeleteProductEntries(int locationId)
        {
            Log.Information("Removing all ProductEntry's with location Id {Id}", locationId);

            IQueryable<ProductEntry> productEntry = _context.ProductEntry
                .Where(p => p.LocationId == locationId).AsNoTracking();

            _context.RemoveRange(productEntry);
        }

        public void DeleteOrders(IQueryable<Orders> orders)
        {
            Log.Information("Removing all Orders");

            foreach (Orders o in orders)
                DeletProductOrders(o.Id);

            _context.RemoveRange(orders);
        }

        public void DeletProductOrders(int orderId)
        {
            Log.Information("Removing all ProductOrders with order Id {Id}", orderId);

            IQueryable<Entities.ProductOrder> productOrders = _context.ProductOrder
                .Where(p => p.OrderId == orderId).AsNoTracking();

            _context.RemoveRange(productOrders);
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}