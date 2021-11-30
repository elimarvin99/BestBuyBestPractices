using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            //var departmentRepo = new DapperDepartmentRepository(conn);

            //Console.WriteLine("Type a new department name:");
            //var newDepartment = Console.ReadLine();

            //departmentRepo.InsertDepartment(newDepartment);

            //var departments = departmentRepo.GetAllDepartments();

            //foreach (var item in departments)
            //{
            //    Console.WriteLine($"Dept Name: {item.Name}");
            //    Console.WriteLine($"Dept Id: {item.DepartmentID}");
            //}
            var productRepo = new DapperProductRepository(conn);

            Console.WriteLine("Type a new Product name:");
            var newProduct = Console.ReadLine();
            Console.WriteLine($"How much does {newProduct} cost?");
            Console.Write("$");
            var newProductPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"What is {newProduct}'s categoryID number (must be between 1 - 10)?");
            //display all category id's 
            Console.WriteLine("1: Computers, 2: Appliances, 3: Phones, 4: Audio, 5: Home Theater, 6: Printers; 7: Music, 8: Games, 9: Services, 10: Other");
            var newProductCategoryID = Convert.ToInt32(Console.ReadLine());
            productRepo.CreateProduct(newProduct, newProductPrice, newProductCategoryID);

            var products = productRepo.GetAllProducts();
            foreach (var item in products)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.ProductID);
            }
            Console.WriteLine("What is the productID that you would like to delete?");
            var input = Convert.ToInt32(Console.ReadLine());

            productRepo.DeleteProduct(input);
        }
    }
}
