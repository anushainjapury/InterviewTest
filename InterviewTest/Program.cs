﻿using System;
using System.Linq;
using InterviewTest.Customers;
using InterviewTest.Orders;
using InterviewTest.Products;
using InterviewTest.Returns;
using Microsoft.EntityFrameworkCore;
using InterviewTest.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using InterviewTest.Models;


namespace InterviewTest
{

    public class Program
    {
        private static readonly OrderRepository orderRepo = new OrderRepository();
        private static readonly ReturnRepository returnRepo = new ReturnRepository();
        private static int cumulativeTotalOrderedItems = 0; //gets the cumulative total orders for both examples

        static void Main(string[] args)
        {

            // Configuring DbContext with the connection string attempt

            /*
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            //dependency injection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);

            
            var serviceProvider = serviceCollection.BuildServiceProvider();

            
            using (var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {

            }
            */



            // ------------------------
            // Coding Challenge Requirements
            // ------------------------


            // ------------------------
            // Code Implementations
            // ------------------------
            // 1: Implement get total sales, returns, and profit in the CustomerBase class.
            // 2: Record when an item was purchased.


            // ------------------------
            // Bug fixes
            // ------------------------
            // ~~ Run the console app after implementing the Code Changes section above! ~~
            // 1: Meyer Truck Equipment's returns are not being processed.
            // 2: Ruxer Ford Lincoln, Inc.'s totals are incorrect.


            // ------------------------
            // Bonus
            // ------------------------
            // 1: Create unit tests for the ordering and return process.
            // 2: Create a database and refactor all repositories to save/update/pull from it.

            ProcessTruckAccessoriesExample();

            ProcessCarDealershipExample();

            Console.WriteLine($"Total Ordered Items for All Customers: {cumulativeTotalOrderedItems}");

            Console.ReadKey();
           
        }

        //configure services method attempt 
        /*
        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
        */

        private static void ProcessTruckAccessoriesExample()
        {
            var customer = GetTruckAccessoriesCustomer();

            IOrder order = new Order("TruckAccessoriesOrder123", customer);
            order.AddProduct(new HitchAdapter());
            order.AddProduct(new BedLiner());
            customer.CreateOrder(order);           

            IReturn rga = new Return("TruckAccessoriesReturn123", order);
            rga.AddProduct(order.Products.First());
            customer.CreateReturn(rga); //bug fix - missing 

            //originally was recording items like this, but implemented method in the customer class to record count as items are added, rather than recalculating

            /* var totalCustomerOrderedItems = 0;
             foreach (var item in customer.GetOrders()) 
             {               
                 totalCustomerOrderedItems+= item.Products.Count();
             }

             Console.WriteLine($"Number of Items Recorded {totalCustomerOrderedItems}"); */

            cumulativeTotalOrderedItems += customer.TotalOrderedItems;

            ConsoleWriteLineResults(customer);
        }

        private static void ProcessCarDealershipExample()
        { 
            var customer = GetCarDealershipCustomer();

            IOrder order = new Order("CarDealerShipOrder123", customer);
            order.AddProduct(new ReplacementBumper());
            order.AddProduct(new SyntheticOil());
            customer.CreateOrder(order);

            IReturn rga = new Return("CarDealerShipReturn123", order);
            rga.AddProduct(order.Products.First());
            customer.CreateReturn(rga);

            //originally was recording items like this, but implemented method in the customer class to record count as items are added, rather than recalculating

            /*var totalCustomerOrderedItems = 0;
            foreach (var item in customer.GetOrders())
            {
                totalCustomerOrderedItems += item.Products.Count();
            }

            Console.WriteLine($"Number of Items Recorded {totalCustomerOrderedItems}");*/

            cumulativeTotalOrderedItems += customer.TotalOrderedItems;

            ConsoleWriteLineResults(customer);
        }

        private static ICustomer GetTruckAccessoriesCustomer()
        {
            return new TruckAccessoriesCustomer(orderRepo, returnRepo);
        }

        private static ICustomer GetCarDealershipCustomer()
        {
            return new CarDealershipCustomer(orderRepo, returnRepo);
        }

        private static void ConsoleWriteLineResults(ICustomer customer)
        {
            Console.WriteLine(customer.GetName());

            Console.WriteLine($"Total Sales: {customer.GetTotalSales().ToString("c")}");

            Console.WriteLine($"Total Returns: {customer.GetTotalReturns().ToString("c")}");

            Console.WriteLine($"Total Profit: {customer.GetTotalProfit().ToString("c")}");

            //Console.WriteLine($"Number of Items Recorded {customer.TotalOrderedItems}");

            Console.WriteLine();
        }
       
    }
}
