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
        public static bool IsValidLocationIndex(int index)
        {
            if (locations.Count == 0)
                return false;

            if (index < 0 || index >= locations.Count)
                return false;

            return true;
        }

        public static bool IsValidCustomerIndex(int index)
        {
            if (customers.Count == 0)
                return false;

            if (index < 0 || index >= customers.Count)
                return false;

            return true;
        }

        public static void PlaceAnOrder()
        {
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine($"[{i}] - {customers[i].FirstName} {customers[i].LastName}");
            }

            Console.Write("Please pick a customer to place the order");
            var customerIndex = int.Parse(Console.ReadLine());

            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine($"[{i}] - {locations[i].LocationName}");
            }

            Console.Write("Please pick a location to order from");
            var locationIndex = int.Parse(Console.ReadLine());

            if (IsValidCustomerIndex(customerIndex) && IsValidLocationIndex(locationIndex))
            {
                Order order = new Order(locations[locationIndex], customers[customerIndex]);
                CreateOrder(order);
            }
            else
            {
                Console.WriteLine("Invalid customer or location: Please press any key to continue");
                Console.ReadLine();
            }
        }

        public static void CreateOrder(Order order)
        {
            List<Product> products = order.OrderLocation.Inventory;

            string option = "y";
            while (option != "n")
            {
                for (int i = 0; i < products.Count; i++)
                    Console.WriteLine($"[{i}] - {products[i].Name}  {products[i].Quantity}");
                
                Console.Write("Please pick a product to buy: ");
                var productIndex = int.Parse(Console.ReadLine());

                Console.Write("Please enter a quantity to buy: ");
                var productQuantity = int.Parse(Console.ReadLine());

                if (productIndex >= 0 || productIndex < products.Count)
                {
                    Product p = new Product(products[productIndex].Name, productQuantity);

                    try
                    {
                        order.OrderLocation.BuyProduct(p);
                        order.AddProduct(p);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error in Buying Product: {ex.Message}");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                    }
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
            foreach (Customer c in customers)
            {
                if (c.FirstName == firstName && c.LastName == lastName)
                {
                    found = true;

                    Console.WriteLine("customer found");
                    Console.WriteLine(c);
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

        public static void DisplayLocationOrders()
        {
            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine($"[{i} - {locations[i].LocationName}]");
            }

            Console.Write("Please pick a location to se its inventory: ");
            int index = int.Parse(Console.ReadLine());

            if (index < 0 || index >= locations.Count)
            {
                List<Order> orders = locations[index].Orders;

                foreach (Order order in orders)
                    Console.WriteLine(order);
            }
        }

        public static void DisplayCustomerOrders()
        {

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
                Console.WriteLine("******MAIN MENU******\n");
                Console.WriteLine("[1] - Place a new order");
                Console.WriteLine("[2] - Add a new customer");
                Console.WriteLine("[3] - Search for customer");
                Console.WriteLine("[4] - Display orders by Location");
                Console.WriteLine("[5] - Display orders by customer");
                Console.WriteLine("[Q] - Quite");

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
                        break;
                    case "4": // Display orders by location
                        break;
                    case "5": // Display orders by customers
                        break;
                }
            }
        }
    }
}
