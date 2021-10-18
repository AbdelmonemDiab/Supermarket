using Supermarket.ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Supermarket.ShoppingCart.Tests.DiscountsTests
{
    public class QuantityPriceDiscountTests
    {
        [Theory]
        [InlineData(2, 2, 4, 0)]
        [InlineData(2, 2, 6, 0)]
        [InlineData(2, 2, 7, 1)]
        [InlineData(2, 2, 5, 1)]
        public void GetUndiscountedQuantityTest(int discountedQuantity, double pricePerDiscountedQuantity, int quantity, int expectedUndiscountedQuantity)
        {
            var quantityPriceDiscount = new QuantityPriceDiscount()
            {
                DiscountedQuantity = discountedQuantity,
                PricePerDiscountedQuantity = pricePerDiscountedQuantity,
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(10)

            };
            int actualUndiscountedQuantity = quantityPriceDiscount.GetUndiscountedQuantity(quantity);
            Assert.Equal(expectedUndiscountedQuantity, actualUndiscountedQuantity);
        }

        [Theory]
        [InlineData(2, 2, 4, true)]
        [InlineData(2, 2, 1, false)]

        public void IsEligibleForDiscountTest(int discountedQuantity, double pricePerDiscountedQuantity, int quantity, bool expectedIsEligible)
        {
            var quantityPriceDiscount = new QuantityPriceDiscount()
            {
                DiscountedQuantity = discountedQuantity,
                PricePerDiscountedQuantity = pricePerDiscountedQuantity,
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(10)
            };
            bool actualIsEligible = quantityPriceDiscount.IsEligibleForDiscount(quantity);
            Assert.Equal(expectedIsEligible, actualIsEligible);
        }

        [Theory]
        [InlineData(5, 3, 5, 1, 2)]
       
        public void CalculateDiscountTest(int discountedQuantity, double pricePerDiscountedQuantity, int quantity, double productPrice, double expectedDiscount)
        {
            var quantityPriceDiscount = new QuantityPriceDiscount()
            {
                DiscountedQuantity = discountedQuantity,
                PricePerDiscountedQuantity = pricePerDiscountedQuantity,
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(10)
            };
            double actualDiscount = quantityPriceDiscount.CalculateDiscount(quantity, productPrice);
            Assert.Equal(expectedDiscount, actualDiscount);
        }

    }
}
