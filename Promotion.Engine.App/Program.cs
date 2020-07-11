using Microsoft.Extensions.DependencyInjection;
using Promotion.Engine.App.Models;
using Promotion.Engine.Domain;
using Promotion.Engine.Domain.Contract;
using System;
using System.Collections.Generic;

namespace Promotion.Engine.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("######################## Sample Promotion Engine Implementation ####################################");

            // Setting up Dependency Injection 
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IPromotionCalculationManager, PromotionCalculationManager>()
            .BuildServiceProvider();

            var promotionCalculationManager = serviceProvider.GetService<IPromotionCalculationManager>();

            SalesProductsLineItems salesProductsLineItems = new SalesProductsLineItems();           
            salesProductsLineItems.SalesProductDetails.Add("A", 3);
            salesProductsLineItems.SalesProductDetails.Add("B", 5);
            salesProductsLineItems.SalesProductDetails.Add("C", 2);
            salesProductsLineItems.SalesProductDetails.Add("D", 2);

            Console.WriteLine("Product List:");
            foreach(var product in salesProductsLineItems.SalesProductDetails)
            {
                Console.WriteLine("Product Name: {0} => Product Count: {1}", product.Key, product.Value);
            }

            try
            {
               promotionCalculationManager.ApplyPromotion(salesProductsLineItems);              
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception During Applying Promotion. Exception: " + ex.ToString());               
            }
            
        }
    }
}
