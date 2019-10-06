using System;
using System.Collections.Generic;
using Project0.Business;
using Project0.Data;

namespace Project0.UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var stors = new List<Location>();
            var customers = new List<Customer>();

            string option = "";
            while (option != "6")
            {
                Console.WriteLine("******MAIN MENU******\n");
                Console.WriteLine("[1] - Add a new location");
                Console.WriteLine("[2] - Add a new product to a location");
                Console.WriteLine("[3] - Add a new customer");
                Console.WriteLine("[4] - Add a new customer order");
                Console.WriteLine("[5] - Delete a location");
                Console.WriteLine("[6] - Delete a customer");
                Console.WriteLine("[6] - Quite");

                Console.Write("Please choise an option from the list: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter the location name: ");
                        var name = Console.ReadLine();

                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                }

                if (option == "6")
                    break;

                Console.Clear();
            }
        }
    }
}
