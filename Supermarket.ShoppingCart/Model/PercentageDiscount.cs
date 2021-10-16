using Supermarket.ShoppingCart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Model
{
    public class PercentageDiscount : IDiscount
    {
        public double MinmumQuantity { get; set; }
        public double Percentage { get; set; }
        public DateTime StartDate { get; set ; }
        public DateTime? EndDate { get ; set ; }

        //public double ApplyDiscount(double quanitty)
        //{
        //    return quanitty*(1-Percentage);
        //}

        public double CalculateDiscount(double quantity, Product product)
        {
            return Percentage * quantity*product.ProductPrice;
        }

        public bool IsEligibleForDiscount(double quantity)
        {
            return MinmumQuantity <= quantity;
        }
    }
}
