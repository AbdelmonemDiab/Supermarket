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
        public ReceiptItem GenerateReceiptDetails(CartItem cartItem)
        {
     
            var discount=  _DiscountEngine.CalculateDiscount(cartItem);
            var receiptDetails = new ReceiptItem
            {
               Product = cartItem.Product, 
               Quantity = cartItem.Quantity, 
               DiscountedPrice = (cartItem.Quantity * cartItem.Product.ProductPrice) - discount,
               DiscountPercentage = (discount * 100) / (cartItem.Quantity *cartItem.Product.ProductPrice)
            };
            return receiptDetails;
        }

        public Receipt GenerateReceipt(ShoppingCart shoppingCart)
        {
            var receipt = new Receipt();
            receipt.ReceiptItems = shoppingCart.CartItems.Select(c => GenerateReceiptDetails(c)).ToList(); 
            return receipt;

        }
    }
}
