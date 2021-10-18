using Supermarket.ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Supermarket.ShoppingCart.Tests.DiscountsTests
{
    public class QuantityDiscountTests
    {
        [Theory]
        [InlineData(2,2,4,0)]
        [InlineData(2, 2, 6, 2)]
        [InlineData(2, 2, 7, 1)]
        [InlineData(2, 2, 5, 0)]
        public void GetAddedQuantityTest(int buyQuantity, int getQuantity,int quantity, int expectedAddedItemCount)
        {
            var quantityDiscount = new QuantityDiscount()
            {
                BuyQuantity = buyQuantity,
                GetQuantity = getQuantity,
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(10)

            };
            int actualAddedItemsCount = quantityDiscount.GetAddedQuantity(quantity);
            Assert.Equal(expectedAddedItemCount, actualAddedItemsCount);
        }

        [Theory]
        [InlineData(2, 2, 4, 0)]
        [InlineData(2, 2, 6, 0)]
        [InlineData(2, 2, 7, 0)]
        [InlineData(2, 2, 5, 1)]
        public void GetUndiscountedQuantityTest(int buyQuantity, int getQuantity, int quantity, int expectedUndiscountedQuantity)
        {
            var quantityDiscount = new QuantityDiscount()
            {
                BuyQuantity = buyQuantity,
                GetQuantity = getQuantity,
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(10)

            };
            int actualUndiscountedQuantity = quantityDiscount.GetUndiscountedQuantity(quantity);
            Assert.Equal(expectedUndiscountedQuantity, actualUndiscountedQuantity);
        }

        [Theory]
        [InlineData(2, 2, 4, true)]
        [InlineData(2, 2, 1, false)]

        public void IsEligibleForDiscountTest(int buyQuantity, int getQuantity, int quantity, bool expectedIsEligible)
        {
            var quantityDiscount = new QuantityDiscount()
            {
                BuyQuantity = buyQuantity,
                GetQuantity = getQuantity,
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(10)

            };
            bool actualIsEligible = quantityDiscount.IsEligibleForDiscount(quantity);
            Assert.Equal(expectedIsEligible, actualIsEligible);
        }

        [Theory]
        [InlineData(2, 2, 4,1, 2)]
        [InlineData(2, 2, 1,1,0)]
        public void CalculateDiscountTest(int buyQuantity, int getQuantity, int quantity,double productPrice, double expectedDiscount)
        {
            var quantityDiscount = new QuantityDiscount()
            {
                BuyQuantity = buyQuantity,
                GetQuantity = getQuantity,
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(10)

            };
            double actualDiscount = quantityDiscount.CalculateDiscount(quantity, productPrice);
            Assert.Equal(expectedDiscount, actualDiscount);
        }

    }
}
