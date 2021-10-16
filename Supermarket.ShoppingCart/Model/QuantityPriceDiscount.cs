using Supermarket.ShoppingCart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Model
{
    public class QuantityPriceDiscount : IQuantityDiscount
    {

        public int DiscountedQuantity { get; set; }
        public double PricePerDiscountedQuantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public double CalculateDiscount(double quantity, Product product)
        {
            int q = ((int)quantity / DiscountedQuantity); //* DiscountedQuantity;
            var totalPricePerQuantity = quantity * product.ProductPrice;
            var discount = totalPricePerQuantity - (q * PricePerDiscountedQuantity);
            return discount;
        }

        public int GetAddedQuantity(int quanitty)
        {
            return 0;
        }

        public double GetUndiscountedQuantity(double quanitty)
        {
            return ((int)quanitty) % DiscountedQuantity;
        }

        public int GetUndiscountedQuantity(int quanitty)
        {
            return quanitty % DiscountedQuantity;
        }

        public bool IsEligibleForDiscount(double quantity)
        {
            return quantity >= DiscountedQuantity;
        }
    }
}
