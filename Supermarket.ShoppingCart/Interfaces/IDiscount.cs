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
        /// <summary>
        /// Start Date of the Discount
        /// </summary>
        DateTime StartDate { get; set; }
        /// <summary>
        /// End Date of the Discount
        /// nullable means no End Date.
        /// </summary>
        DateTime? EndDate { get; set; }

        /// <summary>
        /// check if the disount if active 
        /// </summary>
        /// <returns></returns>
        bool IsActiveDiscount()
        {
            return DateTime.Now >= StartDate && (EndDate is null || EndDate >= DateTime.Now);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        bool IsEligibleForDiscount(int quantity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        double CalculateDiscount(int quantity, double productPrice);

        

    }
}
