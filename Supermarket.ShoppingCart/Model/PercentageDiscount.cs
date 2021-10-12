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
        public double Percentage { get; set; }
        public double ApplyDiscount(double quanitty)
        {
            return quanitty*(1-Percentage);
        }
    }
}
