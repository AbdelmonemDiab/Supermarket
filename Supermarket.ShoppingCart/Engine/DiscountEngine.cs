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

            int initalQuantity = cartItem.Quantity;
            int totalQuantity = cartItem.Quantity;
            var activeDiscounts = cartItem.Product.Discounts
                                    .Where(c => c.IsActiveDiscount())
                                    .Where(c => c.IsEligibleForDiscount(cartItem.Quantity))
                                    .ToList();

            (discount, cartItem.AddedQuantity) = CalculateQuantityDiscount(activeDiscounts
                .Where(d => d is QuantityDiscount)
                .Select(c => (QuantityDiscount)c)
                .ToList(), 
                cartItem.Product,
                cartItem.Quantity);

            totalQuantity = cartItem.Quantity + cartItem.AddedQuantity;

            discount+= CalculateQuantityPriceDiscount(activeDiscounts.Where(d => d is QuantityPriceDiscount)
                                              .Select(c => (QuantityPriceDiscount)c).ToList(), cartItem.Product,
                                              totalQuantity);

            foreach (var d in activeDiscounts.Where(d => d is PercentageDiscount))
            {
                discount += d.CalculateDiscount(totalQuantity, cartItem.Product);
            }
            return discount;
        }

        public (double Discount, int AddedItems) CalculateQuantityDiscount(List<QuantityDiscount> quantityDiscounts, Product product, int quantity)
        {
            double discount = 0;
            int addedItems = 0;
            foreach (var quantityDiscount in quantityDiscounts.OrderByDescending(c => c.BuyQuantity))
            {
                discount += quantityDiscount.CalculateDiscount(quantity, product);
                addedItems += quantityDiscount.GetAddedQuantity(quantity);
                quantity = quantityDiscount.GetUndiscountedQuantity(quantity);
            }
            return (discount, addedItems);
        }

        public double CalculateQuantityPriceDiscount(List<QuantityPriceDiscount> quantityPriceDiscounts, Product product, int quantity)
        {
            double discount = 0;

            foreach (var quantityDiscount in quantityPriceDiscounts.OrderByDescending(c => c.DiscountedQuantity))
            {
                discount += quantityDiscount.CalculateDiscount(quantity, product);
            
                quantity = quantityDiscount.GetUndiscountedQuantity(quantity);
            }
            return discount;
        }
    }
}
