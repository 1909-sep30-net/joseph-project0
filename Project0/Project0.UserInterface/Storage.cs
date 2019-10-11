using System;
using System.Collections.Generic;
using System.Text;
using Project0.Business;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;

namespace Project0.UserInterface
{
    class Storage
    {
        public static async Task SerializeLocationsJsonToFileAsync(string filePath, List<Location> locations, List<Customer> customers, List<Product> products)
        {
            await Task.WhenAll
                (
                    SerializeLocationsJsonToFileAsync(filePath, locations),
                    SerializeCustomersJsonToFileAsync(filePath, customers),
                    SerializeProductsJsonToFileAsync(filePath, products)
                );
        }
        private static async Task SerializeLocationsJsonToFileAsync(string filePath, List<Location> data)
        {
            string json = JsonConvert.SerializeObject(data);
            await File.WriteAllTextAsync(filePath + "locations.json", json);
        }
        private static async Task SerializeCustomersJsonToFileAsync(string filePath, List<Customer> data)
        {
            string json = JsonConvert.SerializeObject(data);
            await File.WriteAllTextAsync(filePath + "customers.json", json);
        }
        private static async Task SerializeProductsJsonToFileAsync(string filePath, List<Product> data)
        {
            string json = JsonConvert.SerializeObject(data);
            await File.WriteAllTextAsync(filePath + "products.json", json);
        }
    }
}
