using Supermarket.ShoppingCart.Interfaces;
using Supermarket.ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Engine
{
    public class DiscountEngine : IDiscountEngine
    {
        public double CalculateDiscount(CartItem cartItem)
        {
            double discountedQuantity = 0;

            double initalQuantity = cartItem.Quantity;
            double totalQuantity = 0;
            foreach (QuantityDiscount discount in cartItem.Product.Discounts.Where(d => d is QuantityDiscount))
            {

                discountedQuantity = +discount.ApplyDiscount(initalQuantity);

                initalQuantity = discount.GetUndiscountedQuantity(initalQuantity);
            }
            totalQuantity = discountedQuantity + initalQuantity;
            foreach (PercentageDiscount discount in cartItem.Product.Discounts.Where(d => d is PercentageDiscount))
            {
                totalQuantity = discount.ApplyDiscount(totalQuantity);
            }
            double totalDiscounted = cartItem.Product.ProductPrice * totalQuantity;
            return totalDiscounted;
        }
    }
}
