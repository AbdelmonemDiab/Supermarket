using Supermarket.ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Tests
{
    public static class Helper
    {
        public static List<Product> GetSampleProducts()
        {
            return new ()
            {
                new()
                {
                    ProductId = 1, 
                    ProductName = "rice",
                    ProductPrice= 2.49,
                    ProductType = ProductType.Quantity,
                    ProductUnit = "Bag"
                },
                new()
                {
                    ProductId = 2,
                    ProductName = "toothbrush",
                    ProductPrice = 0.99,
                    ProductType = ProductType.Quantity,
                    ProductUnit = "Quantity"
                },
                new()
                {
                    ProductId = 3,
                    ProductName = "apples",
                    ProductPrice = 1.99,
                    ProductType = ProductType.Weight,
                    ProductUnit = "Kilo"
                },
                new()
                {
                    ProductId = 4,
                    ProductName = "toothpaste",
                    ProductPrice = 1.79,
                    ProductType = ProductType.Quantity,
                    ProductUnit = "Quantity"
                },
                new()
                {
                    ProductId = 5,
                    ProductName = "cherry tomatoes",
                    ProductPrice = 0.69,
                    ProductType = ProductType.Quantity,
                    ProductUnit = "Box"
                },
                new()
                {
                    ProductId = 6,
                    ProductName = "milk",
                    ProductPrice = 1.0,
                    ProductType = ProductType.Quantity,
                    ProductUnit = "Bottle"
                },
            };
        }

        public static List<QuantityPriceDiscount> GetQuantityPriceDiscounts()
        {
            return new()
            {
                new()
                {
                    DiscountedQuantity = 5,
                    PricePerDiscountedQuantity = 7.49,
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = null
                },
                new()
                {
                    DiscountedQuantity = 2,
                    PricePerDiscountedQuantity = 0.99,
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = DateTime.Now.AddDays(10)
                }
            };
        }

        public static List<QuantityDiscount> GetQuantityDiscounts()
        {
            return new()
            {
                new()
                {
                    BuyQuantity = 2,
                    GetQuantity = 1,
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = null
                },
                new()
                {
                    BuyQuantity = 2,
                    GetQuantity = 2,
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = DateTime.Now.AddDays(10)
                },
                new()
                {
                    BuyQuantity = 5,
                    GetQuantity = 3,
                    EndDate = DateTime.Now.AddDays(10),
                    StartDate = DateTime.Now.AddDays(-10)
                }
            };
        }

        public static List<PercentageDiscount> GetPercentageDiscounts()
        {
            return new()
            {
                new()
                {
                    MinmumQuantity = 2,
                    Percentage = 0.2,
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = null
                },
                new()
                {
                    MinmumQuantity = 0,
                    Percentage = 0.1,
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = DateTime.Now.AddDays(10)
                },
                new()
                {
                    MinmumQuantity = 0,
                    Percentage = 0.2,
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = DateTime.Now.AddDays(10)
                }
            };
        }
    }
}
