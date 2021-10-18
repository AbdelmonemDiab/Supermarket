using Supermarket.ShoppingCart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Model
{
    public class QuantityPriceDiscount : IQuantityPriceDiscount
    {

        public int DiscountedQuantity { get; set; }
        public double PricePerDiscountedQuantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public double CalculateDiscount(int quantity, double productPrice)
        {
            int q = ((int)quantity / DiscountedQuantity); 
            var totalPricePerQuantity = quantity * productPrice;
            var discount = totalPricePerQuantity - (q * PricePerDiscountedQuantity);
            return discount;
        }



        public int GetUndiscountedQuantity(int quanitty)
        {
            return quanitty % DiscountedQuantity;
        }

        public bool IsEligibleForDiscount(int quantity)
        {
            return quantity >= DiscountedQuantity;
        }
    }
}
