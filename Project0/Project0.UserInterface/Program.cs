using System;
using System.Collections.Generic;
using Project0.Business;
using Project0.Data;

namespace Project0.UserInterface
{

    class Program
    {
        public static List<Location> locations = new List<Location>()
        {
            new Location("store a"),
            new Location("store b"),
            new Location("store c")
        };

        public static List<Customer> customers = new List<Customer>()
        {
            new Customer("customer", "a"),
            new Customer("customer", "b"),
            new Customer("customer", "c")
        };

        public static List<Product> products = new List<Product>()
        {
            new Product("product a", 10),
            new Product("product b", 10),
            new Product("product c", 10),
        };


        public static void Init()
        {
            foreach (Location l in locations)
                foreach (Product p in products)
                    l.AddProduct(p);
        }

        public static void PrintCustomers()
        {
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine($"[{i}] - {customers[i].FirstName} {customers[i].LastName}");
            }
        }

        public static void PrintLocations()
        {
            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine($"[{i}] - {locations[i].LocationName}");
            }
        }

        public static void PrintInventory(Location location)
        {
            List<Product> inventory = location.Inventory;

            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"[{i}] - {inventory[i].Name} = {inventory[i].Quantity}");
            }
        }

        public static void PrintOrder(Order order)
        {
            List<Product> products = order.OrderPoducts;
            string location = order.OrderLocation.LocationName;
            string customer = order.OrderCustomer.FirstName + " " + order.OrderCustomer.LastName;
            Console.WriteLine($"Location - [{location}] - Customer - [{customer}]");
            Console.Write("Products - ");

            foreach (Product product in products)
                Console.Write($"[{product.Name} = {product.Quantity}] ");

            Console.WriteLine("]");
        }

        public static int GetValidCustomerIndex()
        {
            int customerIndex = -1;

            if (customers.Count == 0)
            {
                Console.WriteLine("There are no customers: Press enter to continue");
                Console.ReadLine();
                return customerIndex;
            }

            while (customerIndex < 0 || customerIndex >= customers.Count)
            {
                Console.Clear();
                PrintCustomers();

                Console.Write("Select a customer: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out customerIndex))
                {
                    Console.WriteLine("Invalid input: Press enter to continue");
                    Console.ReadLine();
                }
            }

            return customerIndex;
        }

        public static int GetValidLocationIndex()
        {
            int locationIndex = -1;

            if (locations.Count == 0)
            {
                Console.WriteLine("There are no locations: Press enter to continue");
                Console.ReadLine();
                return locationIndex;
            }

            bool validIndex = false;
            while (!validIndex)
            {
                Console.Clear();
                PrintLocations();

                Console.Write("Select a location: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out locationIndex) && (locationIndex >= 0 && locationIndex < locations.Count))
                {
                    validIndex = true;
                }
                else
                {
                    Console.WriteLine("Invalid input: Press enter to continue");
                    Console.ReadLine();
                }
            }

            return locationIndex;
        }

        public static int GetValidInventoryIndex(Location location)
        {
            int productIndex = -1;

            if (location.Inventory.Count == 0)
            {
                Console.WriteLine("This location has no products to sell: Press enter to continue");
                Console.ReadLine();
                return productIndex;
            }

            bool isValid = false;
            while (!isValid)
            {
                Console.Clear();
                PrintInventory(location);

                Console.WriteLine("Pick a product to buy: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out productIndex) && (productIndex >= 0 && productIndex < location.Inventory.Count))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input: Press enter to continue");
                    Console.ReadLine();
                }

            }

            return productIndex;
        }

        public static void PrintCustomerOrders()
        {
            int customerIndex = GetValidCustomerIndex();

            if (customerIndex != -1)
            {
                List<Order> orders = customers[customerIndex].Orders;

                Console.Clear();
                if (orders.Count != 0)
                {
                    foreach (Order order in orders)
                        PrintOrder(order);

                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("There are no orders for this customer: Press enter to continue");
                    Console.ReadLine();
                }
            }
        }

        public static void PrintLocationOrders()
        {
            int locationIndex = GetValidLocationIndex();
            if (locationIndex != -1)
            {
                List<Order> orders = locations[locationIndex].Orders;

                if (orders.Count == 0)
                {
                    Console.WriteLine("There are no orders for this location: Press enter to continue");
                    Console.ReadLine();
                }
                else
                {
                    foreach (Order order in orders)
                    {
                        PrintOrder(order);
                    }

                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
            }
        }

        public static void PrintLocationInvintory()
        {
            int locationIndex = GetValidLocationIndex();

            if (locationIndex != -1)
            {
                List<Product> products = locations[locationIndex].Inventory;

                if (products.Count == 0)
                {
                    Console.WriteLine("This location does not have any orders: Press enter to continue");
                    Console.ReadLine();
                }
                else
                {
                    foreach (Product product in products)
                        Console.WriteLine(product);
                }
            }
        }

        public static void PlaceAnOrder()
        {

            int customerIndex = GetValidCustomerIndex();
            int locationIndex = -1;
            
            if (customerIndex != -1)
                locationIndex = GetValidLocationIndex();

            if (customerIndex != -1 || locationIndex != -1)
            {
                CreateOrder(locations[locationIndex], customers[customerIndex]);
            }
        }

        public static void CreateOrder(Location location, Customer customer)
        {
            bool orderReady = false;
            Order newOrder = new Order(location, customer);

            while (!orderReady)
            {
                Console.Clear();
                int productIndex = GetValidInventoryIndex(location);
                string productName = location.Inventory[productIndex].Name;

                Console.Write("Enter a quantity to buy: ");
                string input = Console.ReadLine();

                int quantity;
                if (int.TryParse(input, out quantity))
                {   
                    try
                    {
                        Product newProduct = new Product(productName, quantity);
                        location.BuyProduct(newProduct);
                        newOrder.AddProduct(newProduct);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error in making purchase: {ex.Message}");
                        Console.WriteLine("Press enter to continue: ");
                        Console.ReadLine();
                    }
                }

                Console.WriteLine("[y] - Add another product to the order? ");
                if (Console.ReadLine() != "y")
                {
                    location.AddOrder(newOrder);
                    customer.AddOrder(newOrder);
                    orderReady = true;
                }
            }
        }

        public static void AddCustomer()
        {
            Console.Write("Please enter a first name: ");
            var firstName = Console.ReadLine();

            Console.Write("Please enter a last name: ");
            var lastName = Console.ReadLine();

            try
            {
                Customer customer = new Customer(firstName, lastName);
                customers.Add(customer);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error in creating new customer: {ex.Message}");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }

        }

        public static void FindCustomer()
        {
            Console.Write("Please enter the customers first name: ");
            var firstName = Console.ReadLine();

            Console.Write("Please enter the customers last name: ");
            var lastName = Console.ReadLine();

            bool found = false;
            foreach (Customer customer in customers)
            {
                if (customer.FirstName == firstName && customer.LastName == lastName)
                {
                    found = true;

                    Console.WriteLine("Customer found");
                    Console.WriteLine(customer.FirstName + " " + customer.LastName);
                    Console.WriteLine($"Customer has made {customer.Orders.Count} oders so far");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
            }

            if (!found)
            {
                Console.WriteLine("Customer not found");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
        }

//        place orders to store locations for customers
//add a new customer
//search customers by name
//display details of an order
//display all order history of a store location
//display all order history of a customer
        static void Main(string[] args)
        {
            Init();

            string option = "";
            while (option != "Q")
            {
                Console.Clear();
                Console.WriteLine("**************MAIN MENU*************");
                Console.WriteLine("* [1] - Place a new order          *");
                Console.WriteLine("* [2] - Add a new customer         *");
                Console.WriteLine("* [3] - Search for customer        *");
                Console.WriteLine("* [4] - Display orders by Location *");
                Console.WriteLine("* [5] - Display orders by customer *");
                Console.WriteLine("* [Q] - Quite                      *");
                Console.WriteLine("************************************");
                Console.WriteLine();
                Console.Write("Please choise an option from the list: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1": // place an order
                        PlaceAnOrder();
                        break;
                    case "2": // Add a new customer
                        AddCustomer();
                        break;
                    case "3": // Search for a customer
                        FindCustomer();
                        break;
                    case "4": // Display orders by location
                        PrintLocationOrders();
                        break;
                    case "5": // Display orders by customers
                        PrintCustomerOrders();
                        break;
                }
            }
        }
    }
}
