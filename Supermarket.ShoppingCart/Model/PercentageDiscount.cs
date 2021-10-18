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

        public double CalculateDiscount(int quantity, double productPrice)
        {
            return Percentage * quantity* productPrice;
        }

        public bool IsEligibleForDiscount(int quantity)
        {
            return MinmumQuantity <= quantity;
        }
    }
}
