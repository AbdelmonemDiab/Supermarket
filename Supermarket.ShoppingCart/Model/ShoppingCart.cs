using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Model
{
    public class ShoppingCart
    {
        public List<CartItem> CartItems { get; set; }

        public double CalculateShoppingCart()
        {
           return CartItems.Sum(c => c.ApplyDiscount());
        }
    } 
}
