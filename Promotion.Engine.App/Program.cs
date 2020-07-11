using Microsoft.Extensions.DependencyInjection;
using Promotion.Engine.Domain;
using Promotion.Engine.Domain.Contract;
using System;

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
        }
    }
}
