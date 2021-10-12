using Supermarket.ShoppingCart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Model
{
    public class QuantityDiscount : IDiscount
    {
        public int Priority { get; set; }
        public int TotalProductCount { get; set; } // Buy 2 Get 2 means , total Product  4 , DiscountedProductCount
        public int DiscountedProductCount { get; set; }
        public int RemaingProductCount => TotalProductCount - DiscountedProductCount;
        public double ApplyDiscount(double quanitty)
        {
            if(quanitty >= TotalProductCount)
            {
                return ((int)quanitty / TotalProductCount) * (RemaingProductCount);
            }
            return 0;
        }
        public double GetUndiscountedQuantity(double quanitty)
        {
            return ((int)quanitty) % TotalProductCount;
        }
    }
}
