using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Model
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public int AddedQuantity { get; set; }


    }
}
