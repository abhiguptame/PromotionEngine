using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Engine.Domain.Models
{
    public class PromotionsCoupon
    {
        public Dictionary<string, int> ProductCoupon = new Dictionary<string, int>();
        public string InclusionType = "AND";
        public float DiscountPrice { get; set; }
    }
}
