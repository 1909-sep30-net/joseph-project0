using System;
using System.Linq;
using System.Collections.Generic;
using Project0.Business;
using Project0.Data;
using Microsoft.EntityFrameworkCore;
using Project0.Data.Entities;

namespace Project0.UserInterface
{
    class Program
    {
        public static void PrintCustomers(List<Customer> customers)
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("There are no customers");
            }
            else
            {
                foreach (Customer c in customers)
                    Console.WriteLine($"Id = {c.Id} - Name = {c.FirstName} {c.LastName}");
            }

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        public static void PrintLocations(List<Location> locations)
        {
            if (locations.Count == 0)
            {
                Console.WriteLine("There are no locations");
            }
            else
            {
                foreach (Location l in locations)
                    Console.WriteLine($"Id = {l.Id} - Name = {l.Name}");
            }

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        public static void PrintInventory(Location location)
        {
            foreach (ProductEntery p in location.Inventory)
                Console.WriteLine($"Id = {p.ProductId} - Name = {p.Name} - Quantity = {p.Quantity}");
        }

        public static void PrintOrder(Order order)
        {
            Console.WriteLine($"Order Id = {order.Id} - Location Id = {order.LocationId} - Customer Id = {order.CustomerId} - Total = {order.TotalPrice}");

            foreach (Business.ProductOrder p in order.ProductOrders)
                Console.WriteLine($"{p.Id} - {p.Name} = {p.Quantity}");
        }

        public static void PlaceOrder(DataBase data)
        {
            
        }

        public static void AddCustomer(DataBase data)
        {
            Customer newCustomer = new Customer();

            Console.WriteLine("Enter the first name of the customer: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name of the customer: ");
            string lastName = Console.ReadLine();

            List<Customer> customers = data.getCustomers(firstName: firstName, lastName: lastName);

            if (customers.Count == 0)
            {
                try
                {
                    newCustomer.Id = 0;
                    newCustomer.FirstName = firstName;
                    newCustomer.LastName = lastName;

                    Console.WriteLine($"AddCustomer still needs to be implimented");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error in creating new customer: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Customer allready exist");
            }

            Console.Write("Press enter to continue: ");
            Console.ReadLine();
        }

        public static void AddLocation(DataBase data)
        {
            Console.WriteLine("AddLocation not implimented");
        }

        public static void FindCustomer(DataBase data)
        {
            Console.Clear();
            Console.WriteLine("[1] - get all customers with first name");
            Console.WriteLine("[2] - get all customers with last name");
            Console.WriteLine("[3] - get customers by full name");
            Console.WriteLine("[4] - get customers by Id");
            Console.WriteLine("[5] - return to main menu");
            Console.Write("Enter an option from the list: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter first name: ");
                    string firstName = Console.ReadLine();
                    PrintCustomers(data.getCustomers(firstName: firstName));
                    break;
                case "2":
                    Console.Write("Enter last name: ");
                    string lastName = Console.ReadLine();
                    PrintCustomers(data.getCustomers(lastName: lastName));
                    break;
                case "3":
                    Console.Write("Enter first name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Enter last name: ");
                    lastName = Console.ReadLine();
                    PrintCustomers(data.getCustomers(firstName: firstName, lastName: lastName));
                    break;
                case "4":
                    Console.Write("Enter the customer id: ");
                    string stringId = Console.ReadLine();

                    int id;
                    if (int.TryParse(stringId, out id))
                    {
                        PrintCustomers(data.getCustomers(id: id));
                    }
                    else
                    {
                        Console.WriteLine("Id entered was invalid: Press enter to continue");
                        Console.ReadLine();
                    }
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("The option entered was invalid: Press enter to continue");
                    Console.ReadLine();
                    break;
            }
        }

        public static void FindLocation(DataBase data)
        {
            Console.Clear();
            Console.WriteLine("[1] - get location by name");
            Console.WriteLine("[2] - get location by Id");
            Console.WriteLine("[3] - return to main menu");
            Console.Write("Enter an option from the list: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter a location name: ");
                    PrintLocations(data.getLocations(name: Console.ReadLine()));

                    break;
                case "2":
                    Console.Write("Enter a location Id: ");

                    int id;
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        PrintLocations(data.getLocations(id: id));
                    }
                    else
                    {
                        Console.WriteLine($"The Id is invalid");
                    }

                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("The option entered was invalid: Press enter to continue");

                    break;
            }

            Console.WriteLine("Press enter to continue: ");
            Console.ReadLine();
        }

        public static void PrintLocationOrders(DataBase data)
        {
            List<Location> locations = data.getLocations();

            PrintLocations(locations);
            Console.Write("Enter the location Id to see orders: ");

            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                int index = locations.FindIndex(i => i.Id == id);
                if (index != -1)
                {
                    foreach (Order o in locations[index].Orders)
                        PrintOrder(o);
                }
                else
                {
                    Console.WriteLine($"No locations with Id = {id} exist");
                }
                Console.Write("Press enter to continue: ");
                Console.ReadLine();
            }
        }

        public static void PrintCustomerOrders(DataBase data)
        {
            List<Customer> customers = data.getCustomers();
            PrintCustomers(customers);

            Console.WriteLine("Enter a customer Id to see all orders");

            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                int index = customers.FindIndex(i => i.Id == id);

                if (index != -1)
                {
                    foreach (Order o in customers[index].Orders)
                        PrintOrder(o);

                }
                else
                {
                    Console.WriteLine($"There are no customers with the Id {id}");
                }
            }
            else
            {
                Console.WriteLine("The entered Id was invalid");
            }

            Console.Write("Press enter to continue: ");
            Console.ReadLine();
        }

        //        place orders to store locations for customers
        //add a new customer
        //search customers by name
        //display details of an order
        //display all order history of a store location
        //display all order history of a customer
        static void Main(string[] args)
        {
            string connectionString = SecretString.s;

            DbContextOptions<Project0Context> options = new DbContextOptionsBuilder<Project0Context>()
                .UseSqlServer(connectionString).Options;

            using var context = new Project0Context(options);
            using DataBase data = new DataBase(context);

            string option = "";
            while (option != "Q")
            {
                Console.Clear();
                Console.WriteLine("**************MAIN MENU*************");
                Console.WriteLine("* [1] - Place a new order          *");
                Console.WriteLine("* [2] - Add a new customer         *");
                Console.WriteLine("* [3] - Add a new location         *");
                Console.WriteLine("* [4] - Search for customer        *");
                Console.WriteLine("* [5] - Search for Location        *");
                Console.WriteLine("* [6] - Display orders by Location *");
                Console.WriteLine("* [7] - Display orders by customer *");
                Console.WriteLine("* [Q] - Quite                      *");
                Console.WriteLine("************************************");
                Console.WriteLine();
                Console.Write("Please choise an option from the list: ");
                option = Console.ReadLine();

                if (option == "Q")
                    return;

                switch (option)
                {
                    case "1": // place an order
                        PlaceOrder(data);
                        break;
                    case "2": // Add a new customer
                        AddCustomer(data);
                        break;
                    case "3": // Add a new Location
                        AddLocation(data);
                        break;
                    case "4": // Search for a customer
                        FindCustomer(data);
                        break;
                    case "5": // Search for a location
                        FindLocation(data);
                        break;
                    case "6": // Display orders for a customer
                        PrintCustomerOrders(data);
                        break;
                    case "7": // Display orders for a location
                        PrintLocationOrders(data);
                        break;
                    default:
                        Console.WriteLine("The input was invalid: Press enter to continue");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
