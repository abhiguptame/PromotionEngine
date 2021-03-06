using FluentAssertions;
using Promotion.Engine.App.Models;
using Promotion.Engine.Domain;
using System;
using Xunit;

namespace Promotion.Engine.UnitTests
{
    public class PromotionCalculationManagerTest
    {
        #region Constructors

        public PromotionCalculationManagerTest()
        {
        }

        #endregion

        #region Public Test Methods

        [Fact]
        public void Senario_A_Unit_Test()
        {
            // Arrange 
            SalesProductsLineItems salesProductsLineItems = new SalesProductsLineItems();
            salesProductsLineItems.SalesProductDetails.Add("A", 1);
            salesProductsLineItems.SalesProductDetails.Add("B", 1);
            salesProductsLineItems.SalesProductDetails.Add("C", 1);

            var promotionCalculationManager = new PromotionCalculationManager();

            // Act
            var promotionalPrice = promotionCalculationManager.ApplyPromotion(salesProductsLineItems).Result;

            // Assert
            promotionalPrice.Should().Be(100);
        }

        [Fact]
        public void Senario_B_Unit_Test()
        {
            // Arrange 
            SalesProductsLineItems salesProductsLineItems = new SalesProductsLineItems();
            salesProductsLineItems.SalesProductDetails.Add("A", 5);
            salesProductsLineItems.SalesProductDetails.Add("B", 5);
            salesProductsLineItems.SalesProductDetails.Add("C", 1);

            var promotionCalculationManager = new PromotionCalculationManager();

            // Act
            var promotionalPrice = promotionCalculationManager.ApplyPromotion(salesProductsLineItems).Result;

            // Assert
            promotionalPrice.Should().Be(370);
        }

        [Fact]
        public void Senario_C_Unit_Test()
        {
            // Arrange 
            SalesProductsLineItems salesProductsLineItems = new SalesProductsLineItems();
            salesProductsLineItems.SalesProductDetails.Add("A", 3);
            salesProductsLineItems.SalesProductDetails.Add("B", 5);
            salesProductsLineItems.SalesProductDetails.Add("C", 1);
            salesProductsLineItems.SalesProductDetails.Add("D", 1);

            var promotionCalculationManager = new PromotionCalculationManager();

            // Act
            var promotionalPrice = promotionCalculationManager.ApplyPromotion(salesProductsLineItems).Result;

            // Assert
            promotionalPrice.Should().Be(280);
        }

        [Fact]
        public void Senario_Custom_Unit_Test()
        {
            // Arrange 
            SalesProductsLineItems salesProductsLineItems = new SalesProductsLineItems();
            salesProductsLineItems.SalesProductDetails.Add("A", 3);
            salesProductsLineItems.SalesProductDetails.Add("B", 5);
            salesProductsLineItems.SalesProductDetails.Add("C", 2);
            salesProductsLineItems.SalesProductDetails.Add("D", 2);

            var promotionCalculationManager = new PromotionCalculationManager();

            // Act
            var promotionalPrice = promotionCalculationManager.ApplyPromotion(salesProductsLineItems).Result;

            // Assert
            promotionalPrice.Should().Be(310);
        }
        #endregion
    }
}
