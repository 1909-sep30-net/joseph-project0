
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project0.Data.Entities;
using Project0.Business;

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
            _context.SaveChanges();
        }

        public void AddCustomer(Customer customer)
        {
            Customers entity = Mapper.MapCustomerToOrders(customer);
            _context.Add(entity);
        }

        public void AddLocation(Location location)
        {
            Locations entity = Mapper.MapLocationsToInvetoryToOrders(location);
            _context.Add(entity);
        }

        public List<Customer> getCustomers(string firstName = null, string lastName = null, int? id = null)
        {
            IQueryable<Customers> items = _context.Customers
                .Include(r => r.Orders).AsNoTracking();

            if (firstName != null)
                items = items.Where(c => c.FirstName == firstName);
            if (lastName != null)
                items = items.Where(c => c.LastName == lastName);
            if (id != null)
                items = items.Where(c => c.Id == id);

            return items.Select(Mapper.MapCustomerToOrders).ToList();
        }

        public List<Location> getLocations(string name = null, int? id = null)
        {
            IQueryable<Locations> items = _context.Locations
                .Include(r => r.ProductEntry).Include(r => r.Orders).AsNoTracking();

            if (name != null)
                items = items.Where(n => n.Name == name);
            if (id != null)
                items = items.Where(i => i.Id == id);

            return items.Select(Mapper.MapLocationsToInvetoryToOrders).ToList();
        }

        public
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