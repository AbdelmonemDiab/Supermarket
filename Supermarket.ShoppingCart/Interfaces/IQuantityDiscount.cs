using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Interfaces
{
    interface IQuantityDiscount :IDiscount
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quanitty"></param>
        /// <returns></returns>
        int GetUndiscountedQuantity(int quanitty);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quanitty"></param>
        /// <returns></returns>
        int GetAddedQuantity(int quanitty); 

    }
}
