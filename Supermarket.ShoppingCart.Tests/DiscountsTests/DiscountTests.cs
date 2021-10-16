using Supermarket.ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Supermarket.ShoppingCart.Tests
{
    public class DiscountTests
    {
        public DiscountTests()
        {
        }

        [Theory]
        [InlineData(2,6)]
        [InlineData(0, 5)]
        [InlineData(0, 4)]
        [InlineData(1, 7)]
        public void buy2Get2DiscountTest(int execptedCount, int quanitity)
        {
            var buy2Get2Discount = Helper.GetQuantityDiscounts().First(c => c.BuyQuantity == 2 && c.GetQuantity == 2);
           int addedQuantity= buy2Get2Discount.GetAddedQuantity(quanitity);
            Assert.Equal(execptedCount, addedQuantity);
        }
    }
}
