using Promotion.Engine.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Promotion.Engine.Domain
{
    public class PromotionCalculationManager : IPromotionCalculationManager
    {

        public PromotionCalculationManager()
        {

        }

        public async Task<float> ApplyPromotion(){

            return await Task.FromResult(new float());
        }

   
    }
}
