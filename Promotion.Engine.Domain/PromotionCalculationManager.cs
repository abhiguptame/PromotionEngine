using Promotion.Engine.App.Models;
using Promotion.Engine.Domain.Contract;
using Promotion.Engine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Promotion.Engine.Domain
{
    public class PromotionCalculationManager : IPromotionCalculationManager
    {

        public PromotionCalculationManager()
        {
        }

        public async Task<float> ApplyPromotion(SalesProductsLineItems salesProductsLineItems)
        {
            ProductsList products = new ProductsList();
            PromotionsOfferRules promotions = new PromotionsOfferRules();

            Console.WriteLine("Total Price (Without Promotions): " + GetTotalPrice(salesProductsLineItems.SalesProductDetails));

            float promotionsDiscountOffers = 0;

            // Get The Promotional Dicount Price 
            foreach (var promotion in promotions.promotionsRulesList)
            {
                var discountPrice = GetPromotionCouponDiscountPrice(promotion, salesProductsLineItems.SalesProductDetails);
                promotionsDiscountOffers = promotionsDiscountOffers + discountPrice;
            }

            float totalPrice = GetTotalPrice(salesProductsLineItems.SalesProductDetails);

            var promotionalPrice = promotionsDiscountOffers + totalPrice;
            Console.WriteLine("Total Price (With Promotion Applied): " + promotionalPrice); 

            return await Task.FromResult(promotionalPrice);
        }


        private float GetTotalPrice(Dictionary<string, int> productDetailsList)
        {
            ProductsList products = new ProductsList();
            float totalPrice = 0;

            foreach (var productDetail in productDetailsList)
            {
                var productPrice = products.skuDictionary[productDetail.Key] * productDetailsList[productDetail.Key];
                totalPrice = totalPrice + productPrice;               
            }

            return totalPrice;
        }


        private float GetPromotionCouponDiscountPrice(PromotionsCoupon promotionCoupon, Dictionary<string, int> salesProductDetails)
        {
            float promotionCouponDiscountPrice = 0;

            // If only one Promotion Coupon 
            if (promotionCoupon.ProductCoupon.Count == 1)    
            {
                var productName = promotionCoupon.ProductCoupon.ElementAt(0).Key;
                if (salesProductDetails.ContainsKey(productName))
                {
                    int productCount = salesProductDetails[productName];
                    int givenProductOfferCount = promotionCoupon.ProductCoupon[productName];
                    int productOfferCount = productCount / givenProductOfferCount;
                    int remainingProductCount = productCount % productOfferCount;
                    salesProductDetails[productName] = remainingProductCount;
                    promotionCouponDiscountPrice = productOfferCount * promotionCoupon.DiscountPrice;
                }
            }
            // Multiple Coupon For The Proucts
            else
            {  
                var firstProductName = promotionCoupon.ProductCoupon.ElementAt(0).Key;
                var secondProductName = promotionCoupon.ProductCoupon.ElementAt(1).Key; 

                if (salesProductDetails.ContainsKey(firstProductName) && salesProductDetails.ContainsKey(secondProductName))
                {
                    // Calculate For First Product 
                    int firstProductCount = salesProductDetails[firstProductName];
                    int firstGivenProductOfferCount = promotionCoupon.ProductCoupon[firstProductName];
                    int firstProductOfferCount = firstProductCount / firstGivenProductOfferCount;
                    int remainingFirstProductCount = firstProductCount % firstGivenProductOfferCount;

                    // Calculate For Second Product 
                    int secondProductCount = salesProductDetails[secondProductName];
                    int secondGivenProductOfferCount = promotionCoupon.ProductCoupon[secondProductName];
                    int secondProductOfferCount = secondProductCount / secondGivenProductOfferCount;
                    int remainingSecondProductCount = secondProductCount % secondGivenProductOfferCount;

                    if (firstProductOfferCount <= secondProductOfferCount) 
                    {
                        salesProductDetails[firstProductName] = remainingFirstProductCount;
                        salesProductDetails[secondProductName] = remainingSecondProductCount + (secondGivenProductOfferCount * (secondProductOfferCount - firstProductOfferCount));
                        promotionCouponDiscountPrice = firstProductOfferCount * promotionCoupon.DiscountPrice;
                    }
                    else
                    {
                        salesProductDetails[firstProductName] = remainingFirstProductCount + (firstProductOfferCount * (firstProductOfferCount - secondProductOfferCount));
                        salesProductDetails[secondProductName] = remainingSecondProductCount;
                        promotionCouponDiscountPrice = secondProductOfferCount * promotionCoupon.DiscountPrice;
                    }
                }
            }

            return promotionCouponDiscountPrice;
        }

    }
}
