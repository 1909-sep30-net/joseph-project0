using System;
using System.Linq;
using System.Collections.Generic;
using Project0.Business;
using Project0.Data;
using Microsoft.EntityFrameworkCore;
using Project0.Data.Entities;
using Serilog;

namespace Project0.UserInterface
{
    class Program
    {
        /// <summary>
        /// gets user input and validates that input agianst the given list of Customers return
        /// returns a user chosen index from the list thats validated
        /// if list is empty returns a -1 value
        /// </summary>
        /// <param name="customers">the list of Customer objects</param>
        /// <returns>the index of the user picked Customer or -1 if no locations exist</returns>
        public static int GetValidCustomer(List<Customer> customers)
        {
            int index = -1;
            bool isValid = false;

            if (customers.Count == 0)
                return index;

            while (!isValid)
            {
                Console.Clear();
                PrintCustomers(customers);
                Console.Write("Enter a customer Id for the perchase: ");

                int id;
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    index = customers.FindIndex(p => p.Id == id);

                    if (index != -1)
                    {
                        isValid = true;
                    }
                }

                if (!isValid)
                {
                    Console.WriteLine("Customer Id is invalid: Press enter to continue");
                    Console.ReadLine();
                }
            }

            return index;
        }

        /// <summary>
        /// gets user input and validates that input agianst the given list of Locations return
        /// returns a user chosen index from the list thats validated
        /// if list is empty returns a -1 value
        /// </summary>
        /// <param name="locations">the list of Location objects</param>
        /// <returns>the index of the user picked Location or -1 if no locations exist</returns>
        public static int GetValidLocation(List<Location> locations)
        {
            int index = -1;
            bool isValid = false;

            if (locations.Count == 0)
                return index;

            while (!isValid)
            {
                Console.Clear();
                PrintLocations(locations);
                Console.Write("Enter a location Id for the perchase: ");

                int id;
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    index = locations.FindIndex(p => p.Id == id);

                    if (index != -1)
                    {
                        isValid = true;
                    }
                }

                if (!isValid)
                {
                    Console.WriteLine("location Id is invalid: Press enter to continue");
                    Console.ReadLine();
                }
            }

            return index;
        }

        /// <summary>
        /// gets user input and validates that input agianst the given list of ProductEnteries return
        /// returns a user chosen index from the list thats validated
        /// if list is empty returns a -1 value
        /// </summary>
        /// <param name="productEnteries">the list of PoductEnter objects</param>
        /// <returns>the index of the user picked ProductEntery or -1 if no locations exsist</returns>
        public static int GetValidProductEntery(List<ProductEntery> productEnteries)
        {
            int index = -1;
            bool isValid = false;

            if (productEnteries.Count == 0)
                return index;

            while (!isValid)
            {
                Console.Clear();
                PrintProductEnteries(productEnteries);
                Console.Write("Enter a product Id for the perchase: ");

                int id;
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    index = productEnteries.FindIndex(p => p.Id == id);

                    if (index != -1)
                    {
                        isValid = true;
                    }
                }

                if (!isValid)
                {
                    Console.WriteLine("Product Id is invalid: Press enter to continue");
                    Console.ReadLine();
                }
            }

            return index;
        }

        /// <summary>
        /// gets user input and validates that input agianst the given list of Products return
        /// returns a user chosen index from the list thats validated
        /// if list is empty returns a -1 value
        /// </summary>
        /// <param name="products">the list of Poduct objects</param>
        /// <returns>the index of the user picked Product or -1 if no locations exsist</returns>
        public static int GetValidProduct(List<Product> products)
        {
            int index = -1;
            bool isValid = false;
            while (!isValid)
            {
                Console.Clear();
                PrintProducts(products);
                Console.Write("Enter a product Id for the perchase: ");

                int id;
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    index = products.FindIndex(p => p.Id == id);

                    if (index != -1)
                    {
                        isValid = true;
                    }
                }

                if (!isValid)
                {
                    Console.WriteLine("location Id is invalid: Press enter to continue");
                    Console.ReadLine();
                }
            }

            return index;
        }

        /// <summary>
        /// prints to console each Customer's info
        /// </summary>
        /// <param name="customers">the list of Customer objects</param>
        public static void PrintCustomers(List<Customer> customers)
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("There are no customers");
            }
            else
            {
                foreach (Customer c in customers)
                    Console.WriteLine($"Id = [{c.Id}]  Name = [{c.FirstName} {c.LastName}]");
            }
        }

        /// <summary>
        /// prints to console each Location's info
        /// </summary>
        /// <param name="locations">the list of Location objects</param>
        public static void PrintLocations(List<Location> locations)
        {
            if (locations.Count == 0)
            {
                Console.WriteLine("There are no locations");
            }
            else
            {
                foreach (Location l in locations)
                    Console.WriteLine($"Id = [{l.Id}]  Name = [{l.Name}]");
            }
        }

        /// <summary>
        /// prints to console each ProductEntery's info
        /// </summary>
        /// <param name="products">the list of ProductEntery objects</param>
        public static void PrintProductEnteries(List<ProductEntery> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("There are no products");
            }
            else
            {
                foreach (ProductEntery p in products)
                    Console.WriteLine($"ID = [{p.Id}]  Name = [{p.Name}]  Quantity = [{p.Quantity}]  Price = [{p.PricePerUnit}]");

            }
        }

        /// <summary>
        /// prints to console each Product's info
        /// </summary>
        /// <param name="products">the list of Product objects</param>
        public static void PrintProducts(List<Product> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("There are no Products in the system");
            }
            else
            {
                foreach (Product p in products)
                    Console.WriteLine($"ID = [{p.Id}]   Name = [{p.Name}]   Price = [{p.CostPerUnit}]");
            }
        }

        /// <summary>
        /// prints to console each Order's info
        /// </summary>
        /// <param name="order">the list of order objects</param>
        public static void PrintOrders(List<Order> orders)
        {
            foreach (Order o in orders)
                Console.WriteLine($"Order Id = [{o.Id}]  Location Id = [{o.LocationId}]  " +
                    $"Customer Id = [{o.CustomerId}]  Total = [{o.TotalPrice}]");
        }

        /// <summary>
        /// prints to console an Order's info
        /// </summary>
        /// <param name="order">the order object</param>
        public static void PrintOrder(Order order)
        {
            Console.WriteLine($"Order Id = [{order.Id}]  Location Id = [{order.LocationId}]  " +
                    $"Customer Id = [{order.CustomerId}]  Total = [{order.TotalPrice}]");

            foreach (Business.ProductOrder p in order.ProductOrders)
                Console.WriteLine($"Id = [{p.Id}]  Name = [{p.Name}]  Quantity = [{p.Quantity}]");

        }

        /// <summary>
        /// prints to console all the known products currently in the database
        /// </summary>
        /// <param name="data">the DBcontect for the database</param>
        public static void PrintAllProducts(DataBase data)
        {
            List<Product> products = data.GetAllProducts().ToList();

            PrintProducts(products);
            Console.Write("Press enter to continue: ");
            Console.ReadLine();
        }

        /// <summary>
        /// sub menu for creating a new order then adding it to the database
        /// </summary>
        /// <param name="data">the DBcontect for the database</param>
        public static void PlaceOrder(DataBase data)
        {
            List<Customer> customers = data.GetAllCustomers().ToList();
            List<Location> locations = data.GetAllLocations().ToList();

            if (locations.Count == 0)
            {
                Console.WriteLine("There are no locations to make a puchase: Press enter to return to the main menu");
                Console.ReadLine();
                return;
            }

            if (customers.Count == 0)
            {
                Console.WriteLine("There are no customers to make a puchase: Press enter to return to the main menu");
                Console.ReadLine();
                return;
            }

            Customer customer = customers[GetValidCustomer(customers)];
            Location location = locations[GetValidLocation(locations)];

            if (location.Inventory.Count == 0)
            {
                Console.WriteLine("The location has no products to sell: Press enter to return to the main menu");
                Console.ReadLine();

                return;
            }

            Order order = new Order()
            {
                Id = 0,
                LocationId = location.Id,
                CustomerId = customer.Id,
            };

            bool orderReady = false;
            while (!orderReady)
            {
                ProductEntery product = location.Inventory[GetValidProductEntery(location.Inventory)];
                Console.WriteLine("Enter the quantity to perchase: ");

                int id;
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    Business.ProductOrder productOrder = new Business.ProductOrder()
                    {
                        Name = product.Name,
                        Id = 0,
                        OrderId = 0,
                        ProductId = product.Id,
                        PricePerUnit = product.PricePerUnit,
                    };

                    order.AddProduct(productOrder);
                }
                else
                {
                    Console.WriteLine("Quantity was invalid:");
                }

                Console.WriteLine("---Current order information---");
                
                Console.Write("[y/n] - would you like to add another product to the order: ");

                if (Console.ReadLine() == "n")
                {
                    orderReady = true;

                    try
                    {
                        location.PlaceOrder(order);
                        customer.Orders.Add(order);

                        data.UpdateLocation(location);
                        data.UpdateCustomer(customer);
                        data.Save();

                        Console.Write("Order placed: Press enter to return to the main menu: ");
                        Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error while placing order: {ex.Message}");
                        Console.Write("Press enter to return to the main menu: ");
                        Console.ReadLine();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Log.Warning("Error in database update {Message}", ex.Message);
                        Console.WriteLine($"Error in updating database: {ex.Message}");
                    }
                    catch (DbUpdateException ex)
                    {
                        Log.Warning("Error in database update {Message}", ex.Message);
                        Console.WriteLine($"Error in updating database: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// sub menu for creating a new Customer and adding it to the database
        /// </summary>
        /// <param name="data">the DBcontect for the database</param>
        public static void AddCustomer(DataBase data)
        {
            Console.Write("Enter the first name of the customer: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter the last name of the customer: ");
            string lastName = Console.ReadLine();

            List<Customer> customers = data.GetAllCustomers(firstName: firstName, lastName: lastName).ToList();

            if (customers.Count == 0)
            {
                try
                {
                    Customer customer = new Customer()
                    {
                        Id = 0,
                        FirstName = firstName,
                        LastName = lastName,
                    };

                    data.AddCustomer(customer);
                    data.Save();

                    Console.WriteLine($"Customer [{firstName}] [{lastName}] added");
                }
                catch (ArgumentException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new customer: {ex.Message}");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new customer: {ex.Message}");
                }
                catch (DbUpdateException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
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

        /// <summary>
        /// sub menu for creating a new Location and adding it to the database
        /// </summary>
        /// <param name="data">the DBcontect for the database</param>
        public static void AddLocation(DataBase data)
        {
            Console.Write("Enter the a name of the location: ");
            string name = Console.ReadLine();

            List<Location> locations = data.GetAllLocations(name: name).ToList();

            if (locations.Count == 0)
            {
                try
                {
                    Location location = new Location()
                    {
                        Id = 0,
                        Name = name,
                    };

                    data.AddLocation(location);
                    data.Save();
                }
                catch (ArgumentException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new location: {ex.Message}");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new location: {ex.Message}");
                }
                catch (DbUpdateException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new location: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Location allready exist");
            }

            Console.Write("Press enter to continue: ");
            Console.ReadLine();
        }

        /// <summary>
        /// sub menu for creating a new Product and adding it to the database
        /// </summary>
        /// <param name="data">the DBcontect for the database</param>
        public static void AddProduct(DataBase data)
        {
            Console.Write("Enter a name for the product: ");
            string name = Console.ReadLine();
            decimal price = 0;

            bool isValid = false;
            while(!isValid)
            {
                Console.Write("Enter a Price for the product: ");

                if (decimal.TryParse(Console.ReadLine(), out price))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Price was invalid:");
                }
            }

            List<Product> products = data.GetAllProducts(name: name).ToList();
            if (products.Count == 0)
            {
                try
                {
                    Product newProduct = new Product()
                    {
                        Name = name,
                        CostPerUnit = price,
                    };

                    data.AddProduct(newProduct);
                }
                catch (ArgumentException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new location: {ex.Message}");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new location: {ex.Message}");
                }
                catch (DbUpdateException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new location: {ex.Message}");
                }
            }

            


        }

        /// <summary>
        /// sub menu for Deleteing a Customer from the database
        /// </summary>
        /// <param name="data">the DBcontect for the database</param>
        public static void DeleteCustomer(DataBase data)
        {
            List<Customer> customers = data.GetAllCustomers().ToList();

            if (customers.Count == 0)
            {
                Console.WriteLine("There are no customers: Press enter to continue ");
                Console.ReadLine();
            }

            Customer customer = customers[GetValidCustomer(customers)];

            Console.Clear();
            Console.WriteLine($"Id = [{customer.Id}]  Name = [{customer.FirstName} {customer.LastName}]" +
                $"  Purchase Total = [{customer.TotalPurchases}]");
            Console.Write("[y/n] Delete this customer? ");

            if (Console.ReadLine() == "y")
            {
                try
                {
                    data.DeleteCustomer(customer);
                    data.Save();

                    Console.WriteLine("Customer deleted: Press enter to continue ");
                    Console.ReadLine();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new location: {ex.Message}");
                    Console.ReadLine();
                }
                catch (DbUpdateException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new location: {ex.Message}");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Deleting customer aborted: Press enter to continue to main menu ");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// sub menu for Deleteing a Location from the database
        /// </summary>
        /// <param name="data"></param>
        public static void DeleteLocation(DataBase data)
        {
            List<Location> locations = data.GetAllLocations().ToList();

            if (locations.Count == 0)
            {
                Console.WriteLine("There are no locations: Press enter to continue ");
                Console.ReadLine();
            }

            Location location = locations[GetValidLocation(locations)];

            Console.Clear();
            Console.WriteLine($"Id = [{location.Id}]  Name = [{location.Name}]" +
                $"  Sales Total = [{location.Total}]");

            Console.Write("[y/n] Delete this Location? ");
            if (Console.ReadLine() == "y")
            {
                try
                {
                    data.DeleteLocation(location);
                    data.Save();

                    Console.WriteLine("Location deleted: Press enter to continue ");
                    Console.ReadLine();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new location: {ex.Message}");
                    Console.ReadLine();
                }
                catch (DbUpdateException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new location: {ex.Message}");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Deleting customer aborted: Press enter to continue to main menu ");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// sub menu for Deleteing a Product from the database
        /// </summary>
        /// <param name="data">the DBcontect for the database</param>
        public static void DeleteProduct(DataBase data)
        {
            Console.WriteLine("Need to be implimented! Press enter to cotinue");
            Console.ReadLine();
        }

        /// <summary>
        /// sub menu for adding products to locations
        /// only products that have been added to the databass can be added to locations
        /// products are stored as ProductEntery in Locations that is they also have a quantity field
        /// </summary>
        /// <param name="data">the DBcontect for the database</param>
        public static void AddProductToLocation(DataBase data)
        {
            List<Location> locations= data.GetAllLocations().ToList();
            List<Product> products = data.GetAllProducts().ToList();

            if (locations.Count() == 0)
            {
                Console.Write("There are no locations to add product to: Press enter to continue");
                Console.ReadLine();
            }
            else if (products.Count() == 0)
            {
                Console.Write("There are no products to add product to: Press enter to continue");
                Console.ReadLine();
            }
            else
            {
                Location location = locations[GetValidLocation(locations)];
                Product product = products[GetValidProduct(products)];

                bool isValid = false;
                int quantity = 0;
                while(!isValid)
                {
                    Console.Write("Enter a quantity to add: ");

                    if (int.TryParse(Console.ReadLine(), out quantity))
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Quantity was invalid");
                    }
                }
                
                try
                {
                    ProductEntery newProductEntery = new ProductEntery()
                    {
                        Id = 0,
                        Name = product.Name,
                        LocationId = location.Id,
                        ProductId = product.Id,
                        Quantity = quantity,
                        PricePerUnit = product.CostPerUnit,
                    };

                    location.AddProduct(newProductEntery);
                    data.UpdateLocation(location);
                }
                catch (ArgumentException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new location: {ex.Message}");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new location: {ex.Message}");
                }
                catch (DbUpdateException ex)
                {
                    Log.Warning("Error in database update {Message}", ex.Message);
                    Console.WriteLine($"Error in creating new location: {ex.Message}");
                }
            }
        }
        /// <summary>
        /// sub menu for serching the database for Customers
        /// </summary>
        /// <param name="data">the DBcontect for the database</param>
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
                    PrintCustomers(data.GetAllCustomers(firstName: firstName).ToList());
                    Console.WriteLine("Press enter to continue: ");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Enter last name: ");
                    string lastName = Console.ReadLine();
                    PrintCustomers(data.GetAllCustomers(lastName: lastName).ToList());
                    Console.WriteLine("Press enter to continue: ");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Enter first name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Enter last name: ");
                    lastName = Console.ReadLine();
                    PrintCustomers(data.GetAllCustomers(firstName: firstName, lastName: lastName).ToList());
                    Console.WriteLine("Press enter to continue: ");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Write("Enter the customer id: ");
                    string stringId = Console.ReadLine();

                    int id;
                    if (int.TryParse(stringId, out id))
                    {
                        PrintCustomers(data.GetAllCustomers(id: id).ToList());

                    }
                    else
                    {
                        Console.WriteLine("Id entered was invalid:");
                        Console.ReadLine();
                    }
                    Console.WriteLine("Press enter to continue: ");
                    Console.ReadLine();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("The option entered was invalid: Press enter to continue");
                    Console.ReadLine();
                    break;
            }
        }
        /// <summary>
        /// sub menu for serching the database for Locations
        /// </summary>
        /// <param name="data">the DBcontect for the database</param>
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
                    PrintLocations(data.GetAllLocations(name: Console.ReadLine()).ToList());

                    break;
                case "2":
                    Console.Write("Enter a location Id: ");

                    int id;
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        PrintLocations(data.GetAllLocations(id: id).ToList());
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
        /// <summary>
        /// sub menu for selecting a Location to display all orders place at this location
        /// </summary>
        /// <param name="data">the DBcontect for the database</param>
        public static void PrintLocationOrders(DataBase data)
        {
            List<Location> locations = data.GetAllLocations().ToList();

            if (locations.Count == 0)
            {
                Console.WriteLine("There are currently no locations: Press enter to continue");
                Console.ReadLine();
            }
            else
            {
                Location location = locations[GetValidLocation(locations)];

                if (location.Orders.Count == 0)
                {
                    Console.Write("There have not been any orders placed at this location: Press enter to continue");
                    Console.ReadLine();
                }
                else
                {
                    PrintOrders(location.Orders);
                    Console.ReadLine();
                }
            }

        }
        /// <summary>
        /// sub menu for selecting a Customer to display all orders placed by this customer
        /// </summary>
        /// <param name="data">the DBcontect for the database</param>
        public static void PrintCustomerOrders(DataBase data)
        {
            List<Customer> customers = data.GetAllCustomers().ToList();

            if (customers.Count == 0)
            {
                Console.WriteLine("There are currently no customers: Press enter to continue");
                Console.ReadLine();
            }
            else
            {
                Customer customer = customers[GetValidCustomer(customers)];

                if (customer.Orders.Count == 0)
                {
                    Console.Write("This customer has not placed any orders yet: Press enter to continue");
                    Console.ReadLine();
                }
                else
                {
                    PrintOrders(customer.Orders);
                    Console.ReadLine();
                }
            }
        }

        public static void CustomerMenu(DataBase data)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("************Customer Menu************");
                Console.WriteLine("* [0] - Place an order              *");
                Console.WriteLine("* [1] - Add a new Customer          *");
                Console.WriteLine("* [2] - Delete a Customer           *");
                Console.WriteLine("* [3] - Search for a Customer       *");
                Console.WriteLine("* [4] - Display a Customer's orders *");
                Console.WriteLine("* [5] - return to main menu         *");
                Console.WriteLine("*************************************");
                Console.WriteLine();
                Console.Write("Enter an option from the list: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "0": // place an order
                        PlaceOrder(data);
                        break;
                    case "1": // add a new customer
                        AddCustomer(data);
                        break;
                    case "2": // delete a customer
                        DeleteCustomer(data);
                        break;
                    case "3": // search for a customer
                        FindCustomer(data);
                        break;
                    case "4": // Display Customer orders
                        PrintCustomerOrders(data);
                        break;
                    case "5": // return to main menu
                        return;
                        break;
                    default:
                        Console.Write("Option entered was invalid: Press enter to continue");
                        Console.ReadLine();
                        break;
                }
            }

        }

        public static void LocationMenu(DataBase data)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("************Location Menu************");
                Console.WriteLine("* [0] - Place an order              *");
                Console.WriteLine("* [1] - Add a new Location          *");
                Console.WriteLine("* [2] - Add a Product to a Location *");
                Console.WriteLine("* [3] - Delete a Location           *");
                Console.WriteLine("* [4] - Search for a Location       *");
                Console.WriteLine("* [5] - Display a location's orders *");
                Console.WriteLine("* [6] - return to main menu         *");
                Console.WriteLine("*************************************");
                Console.WriteLine();
                Console.Write("Enter an option from the list: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "0": // place an order
                        PlaceOrder(data);
                        break;
                    case "1": // add a new location
                        AddLocation(data);
                        break;
                    case "2": // add product to location
                        AddProductToLocation(data);
                        break;
                    case "3": // delete a location
                        DeleteLocation(data);
                        break;
                    case "4": // search for a location
                        FindLocation(data);
                        break;
                    case "5": // Display location orders
                        PrintLocationOrders(data);
                        break;
                    case "6": // return to main menu
                        return;
                    default:
                        Console.Write("Option entered was invalid: Press enter to continue");
                        Console.ReadLine();
                        break;
                }
            }

        }

        public static void ProductMenu(DataBase data)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("************Customer Menu***********");
                Console.WriteLine("* [0] - Add new product            *");
                Console.WriteLine("* [1] - Delete product             *");
                Console.WriteLine("* [2] - Display all known products *");
                Console.WriteLine("* [3] - return to main menu        *");
                Console.WriteLine("************************************");
                Console.WriteLine();
                Console.Write("Enter an option from the list: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "0": // add a product
                        AddProduct(data);
                        break;
                    case "1": // delete product
                        DeleteProduct(data);
                        break;
                    case "2": // display products in system
                        PrintAllProducts(data);
                        break;
                    case "3": // return to main menu
                        return;
                    default:
                        Console.Write("Option entered was invalid: Press enter to continue");
                        Console.ReadLine();
                        break;
                }
            }

        }
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("../../../serilog.txt")
                .CreateLogger();

            Log.Information("it worked!");

            DbContextOptions<Project0Context> options = new DbContextOptionsBuilder<Project0Context>()
                .UseSqlServer(SecretString.s).Options;

            using var context = new Project0Context(options);
            using DataBase data = new DataBase(context);

            string option = "";
            while (option != "Q")
            {
                Console.Clear();
                Console.WriteLine("*******MAIN MENU*******");
                Console.WriteLine("* [0] - Customer Menu *");
                Console.WriteLine("* [1] - Location Menu *");
                Console.WriteLine("* [2] - Product Menu  *");
                Console.WriteLine("* [3] - Quit          *");
                Console.WriteLine("***********************");
                Console.WriteLine();
                Console.Write("Please choise an option from the list: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "0": // Customer menu
                        CustomerMenu(data);
                        break;
                    case "1": // location menu
                        LocationMenu(data);
                        break;
                    case "2": // product menu
                        ProductMenu(data);
                        break;
                    case "3": // quit program
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
