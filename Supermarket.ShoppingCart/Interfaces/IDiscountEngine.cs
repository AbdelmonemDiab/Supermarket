using Supermarket.ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Interfaces
{
    public interface IDiscountEngine 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        double CalculateDiscount(CartItem cartItem);
    }
}
