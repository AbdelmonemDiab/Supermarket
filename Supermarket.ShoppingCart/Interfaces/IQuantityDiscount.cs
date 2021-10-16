using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Interfaces
{
    interface IQuantityDiscount :IDiscount
    {
        int GetUndiscountedQuantity(int quanitty);
        int GetAddedQuantity(int quanitty); // if quanitty =2  and it's buy 2 Get 2 , it should return 4.

    }
}
