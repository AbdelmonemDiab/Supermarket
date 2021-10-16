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
        private readonly Product riceProduct = new Product
        {
            Discounts = new List<Interfaces.IDiscount>(),
            ProductUnit = "Bag",
            ProductId = 1,
            ProductName = "Rice",
            ProductPrice = 2.49,
            ProductType = ProductType.Quantity
        };
        private readonly QuantityDiscount buy5Get3Discount = new()
        {
            BuyQuantity = 5,
            GetQuantity = 3,
            EndDate = DateTime.Now.AddDays(10),
            StartDate = DateTime.Now.AddDays(-10)
        };
        private readonly QuantityDiscount buy2Get2Discount = new()
        {
            BuyQuantity = 2,
            GetQuantity = 2,
            EndDate = DateTime.Now.AddDays(10),
            StartDate = DateTime.Now.AddDays(-10)
        };
        private readonly PercentageDiscount percentageDiscount = new()
        {
            Percentage=0.2,
            MinmumQuantity =2,
            EndDate = DateTime.Now.AddDays(10),
            StartDate = DateTime.Now.AddDays(-10)
        };
        private readonly QuantityPriceDiscount quantityPriceDiscount = new()
        {
            DiscountedQuantity=5,
            PricePerDiscountedQuantity =10,
            EndDate = DateTime.Now.AddDays(10),
            StartDate = DateTime.Now.AddDays(-10)
        };
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
           int addedQuantity= buy2Get2Discount.GetAddedQuantity(quanitity);
            Assert.Equal(execptedCount, addedQuantity);
        }
    }
}
