using Supermarket.ShoppingCart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Model
{
    public class ReceiptEngine : IReceiptEngine
    {
        private readonly IDiscountEngine _DiscountEngine;
        public ReceiptEngine(IDiscountEngine discountEngine)
        {
            _DiscountEngine = discountEngine;
        }
        public ReceiptDetails GenerateReceiptDetails(CartItem cartItem)
        {
     
            var TotalAfterDiscount=  _DiscountEngine.CalculateDiscount(cartItem);
            var receiptDetails = new ReceiptDetails
            {
                CartItem = cartItem,
                DiscountedPrice = TotalAfterDiscount,
                DiscountPercentage = TotalAfterDiscount * 100 / (cartItem.TotalPrice)
            };
            return receiptDetails;
        }
    }
}
