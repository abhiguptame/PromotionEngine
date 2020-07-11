using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Promotion.Engine.Domain.Contract
{
    public interface IPromotionCalculationManager
    {
        Task<float> ApplyPromotion();
    }
}
