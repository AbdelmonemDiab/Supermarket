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
            double discount = 0;

            double initalQuantity = cartItem.Quantity;
            double totalQuantity = cartItem.Quantity;
            var activeDiscounts = cartItem.Product.Discounts
                                    .Where(c => c.IsActiveDiscount())
                                    .Where(c => c.IsEligibleForDiscount(cartItem.Quantity))
                                    .ToList();

            foreach (var d in activeDiscounts.Where(d => d is QuantityDiscount).Select(c => (QuantityDiscount)c).OrderByDescending(c=>c.BuyQuantity))
            {
                discount += d.CalculateDiscount(initalQuantity, cartItem.Product);
                cartItem.AddedQuantity += d.GetNewQuantity((int)initalQuantity);
                initalQuantity = d.GetUndiscountedQuantity((int)initalQuantity);
                
            }

            initalQuantity = cartItem.Quantity + cartItem.AddedQuantity;
            foreach (var d in activeDiscounts.Where(d => d is QuantityPriceDiscount)
                                              .Select(c => (QuantityPriceDiscount)c)
                                              .OrderByDescending(c => c.DiscountedQuantity))
            {
                discount += d.CalculateDiscount(initalQuantity, cartItem.Product);
                initalQuantity = d.GetUndiscountedQuantity((int)initalQuantity);
            }
            totalQuantity += cartItem.AddedQuantity;
            foreach (var d in activeDiscounts.Where(d => d is PercentageDiscount))
            {
                discount += d.CalculateDiscount(totalQuantity, cartItem.Product);
            }
            return discount;
        }
    }
}
