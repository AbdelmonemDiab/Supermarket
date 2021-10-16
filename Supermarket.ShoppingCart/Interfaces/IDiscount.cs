using Supermarket.ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Interfaces
{
    public interface IDiscount
    {
        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }

        bool IsActiveDiscount()
        {
            return DateTime.Now >= StartDate && (EndDate is null || EndDate >= DateTime.Now);
        }
        bool IsEligibleForDiscount(double quantity);

        // return the discounted Amount 
        double CalculateDiscount(double quantity, Product product);

        
        //double ApplyDiscount(double quanitty);
    }
}
