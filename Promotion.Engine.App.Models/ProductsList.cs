using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Engine.App.Models
{
    public class ProductsList
    {
        public Dictionary<string, float> skuDictionary = new Dictionary<string, float>();
        public ProductsList()
        {
            skuDictionary.Add("A", 50);
            skuDictionary.Add("B", 30);
            skuDictionary.Add("C", 20);
            skuDictionary.Add("D", 15);
        }
    }
}
