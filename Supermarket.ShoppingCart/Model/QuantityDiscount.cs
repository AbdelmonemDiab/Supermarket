using Supermarket.ShoppingCart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Model
{
    public class QuantityDiscount : IQuantityDiscount
    {
        //public int TotalProductCount { get; set; } // Buy 2 Get 2 means , total Product  4 , DiscountedProductCount
        // public int DiscountedProductCount { get; set; } // this will be 2 
        //public int RemaingProductCount => TotalProductCount - DiscountedProductCount;

        public int BuyQuantity { get; set; }
        public int GetQuantity { get; set; }
        public int TotalQuantity => BuyQuantity + GetQuantity;

        public DateTime StartDate { get ; set; }
        public DateTime? EndDate { get; set; }

        //public double ApplyDiscount(double quanitty)
        //{
        //    if(quanitty >= TotalProductCount)
        //    {
        //        return ((int)quanitty / TotalProductCount) * (RemaingProductCount);
        //    }
        //    return 0;
        //}

        public double CalculateDiscount(double quantity, Product product)
        {
            return ((int)quantity / TotalQuantity) * BuyQuantity * product.ProductPrice;
        }

        public int GetNewQuantity(int quantity)
        {
            if (quantity % (BuyQuantity + GetQuantity) == 0)
                return 0;
            int discountedCount = quantity / BuyQuantity;
            return discountedCount * (TotalQuantity) + quantity % BuyQuantity;
        }

        public int GetUndiscountedQuantity(int quantity)
        {
            return quantity % BuyQuantity;
        }

        public bool IsEligibleForDiscount(double quantity)
        {
            return quantity >= BuyQuantity;
        }
    }
}
