using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.Business
{
    public interface IDataBase : IDisposable
    {
        // <summary>
        /// save all changes made to the database
        /// </summary>
        public void Save();

        /// <summary>
        /// adds a new Customer to the data base
        /// </summary>
        /// <param name="customer">Customer object to add to the database</param>
        public void AddCustomer(Customer customer);

        /// <summary>
        /// adds a new location to the database
        /// </summary>
        /// <param name="location">Location object to add to the database</param>
        public void AddLocation(Location location);

        /// <summary>
        /// adds a new product to the database
        /// </summary>
        /// <param name="product">product object to add to the database</param>
        public void AddProduct(Product product);

        public void AddProductEntery(ProductEntery product);

        /// <summary>
        /// adds a new order and productOrders to the database
        /// </summary>
        /// <param name="order">order object to add to the database</param>
        public void AddOrder(Order order);

        /// <summary>
        /// updates a productOrder in th database
        /// </summary>
        /// <param name="productOrder">product order to update</param>
        public void AddProductOrder(Business.ProductOrder productOrder);

        /// <summary>
        /// gets a list of all customers in the database
        /// includes order history
        /// can be used to search by cusotmer first name, last name, and id
        /// </summary>
        /// <param name="firstName">first name of customer to search for</param>
        /// <param name="lastName">last name of customer to search for</param>
        /// <param name="id">id of the customer to search for</param>
        /// <returns>a list of all Cusotmer objects found</returns>
        public IEnumerable<Customer> GetAllCustomers(string firstName = null, string lastName = null, int? id = null);

        /// <summary>
        /// gets a list of all locations in the database
        /// each location includes invintory and order history
        /// can be used to search by location name and id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Location> GetAllLocations(string name = null, int? id = null);

        /// <summary>
        /// gets all the products in the database
        /// can be used to search by product name and id
        /// </summary>
        /// <param name="name">name of the product to search for</param>
        /// <param name="id">id of the product to search for</param>
        /// <returns>list of products</returns>
        public IEnumerable<Product> GetAllProducts(string name = null, int? id = null);

        /// <summary>
        /// updates a customer and order history in the database
        /// </summary>
        /// <param name="customer">customer object to update the database with</param>
        public void UpdateCustomer(Business.Customer customer);

        /// <summary>
        /// updates a customer, inventory, and order history in the database
        /// </summary>
        /// <param name="location">location object to update the database with</param>
        public void UpdateLocation(Business.Location location);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productEntery"></param>
        public void UpdateProductEntry(ProductEntery productEntery);

        /// <summary>
        /// delete a customer from the database
        /// </summary>
        /// <param name="customer">customer to be deleted</param>
        public void DeleteCustomer(Customer customer);

        /// <summary>
        /// delete a location from the database
        /// </summary>
        /// <param name="location">location to be deleted</param>
        public void DeleteLocation(Location location);

        /// <summary>
        /// delete a product entry in the database
        /// </summary>
        /// <param name="locationId">product order to be deleted</param>
        public void DeleteProductEntries(int locationId);

        /// <summary>
        /// delete an order from the database
        /// </summary>
        /// <param name="orders">order to be deleted</param>
        public void DeleteOrders(IQueryable<Order> orders);

        /// <summary>
        /// delete a product order from the database
        /// </summary>
        /// <param name="orderId">id of the product order to delete</param>
        public void DeletProductOrders(int orderId);
    }
}
