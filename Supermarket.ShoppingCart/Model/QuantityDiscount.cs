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

        public int BuyQuantity { get; set; }
        public int GetQuantity { get; set; }
        public int TotalQuantity => BuyQuantity + GetQuantity;

        public DateTime StartDate { get ; set; }
        public DateTime? EndDate { get; set; }

        public double CalculateDiscount(int quantity, Product product)
        {
            return ((int)quantity / TotalQuantity) * BuyQuantity * product.ProductPrice;
        }

        public int GetAddedQuantity(int quantity)
        {

            int discountCount = quantity / TotalQuantity;
            var remainingQuantity = quantity - (discountCount * TotalQuantity);
            if (remainingQuantity >= BuyQuantity)
                return  GetQuantity - (remainingQuantity-BuyQuantity);
            return 0; 
        }

        public int GetUndiscountedQuantity(int quantity)
        {
            return quantity % BuyQuantity;
        }

        public bool IsEligibleForDiscount(int quantity)
        {
            return quantity >= BuyQuantity;
        }
    }
}
