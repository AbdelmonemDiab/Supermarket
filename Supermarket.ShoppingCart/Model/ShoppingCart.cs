using Supermarket.ShoppingCart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Model
{
    public class ShoppingCart
    {
        private readonly IReceiptEngine receiptEngine;
        public ShoppingCart(IReceiptEngine receiptEngine)
        {
            this.receiptEngine = receiptEngine;
        }
        public List<CartItem> CartItems { get; set; }

        public double CalculateShoppingCart()
        {
           return CartItems.Select(c=> receiptEngine.GenerateReceiptDetails(c))
                .Sum(c => c.DiscountedPrice);
        }
    } 
}
