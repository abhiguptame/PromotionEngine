using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Engine.Domain.Models
{
    public class PromotionsOfferRules
    {
        public List<PromotionsCoupon> promotionsRulesList = new List<PromotionsCoupon>();

        public PromotionsOfferRules()
        {
            PromotionsCoupon forProductA = new PromotionsCoupon();
            forProductA.ProductCoupon.Add("A", 3);
            forProductA.DiscountPrice = 130;
            promotionsRulesList.Add(forProductA);

            PromotionsCoupon forProductB = new PromotionsCoupon();
            forProductB.ProductCoupon.Add("B", 2);
            forProductB.DiscountPrice = 45;
            promotionsRulesList.Add(forProductB);

            PromotionsCoupon forProductCD = new PromotionsCoupon();
            forProductCD.ProductCoupon.Add("C", 1);
            forProductCD.ProductCoupon.Add("D", 1);
            forProductCD.DiscountPrice = 30;
            promotionsRulesList.Add(forProductCD);
        }
    }
}
