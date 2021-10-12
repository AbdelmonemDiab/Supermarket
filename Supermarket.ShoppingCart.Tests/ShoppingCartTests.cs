using Supermarket.ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Supermarket.ShoppingCart.Tests
{
    public class ShoppingCartTests
    {
        private readonly Model.ShoppingCart shoppingCart = new Model.ShoppingCart();
        private  List<CartItem> cartItems = new List<CartItem>();
        private readonly Product riceProduct = new Product
        {
            Discounts = new List<Interfaces.IDiscount>(),
            ProductCategory = "Bag",
            ProductId = 1,
            ProductName = "Rice",
            ProductPrice = 2.49,
            ProductType = ProductType.Quantity
        };
        private readonly Product applesProduct = new Product
        {
            Discounts = new List<Interfaces.IDiscount>(),
            ProductCategory = "Kilo",
            ProductId = 1,
            ProductName = "Apples",
            ProductPrice = 1.99,
            ProductType = ProductType.Weight
        };


        private readonly Product discountedRiceProduct = new Product
        {
            Discounts = new List<Interfaces.IDiscount>()
            {
                new QuantityDiscount
                {
                    Priority =1,
                    TotalProductCount = 4, // Buy 2 Get 2
                    DiscountedProductCount = 2
                }
            },
            ProductCategory = "Bag",
            ProductId = 1,
            ProductName = "Rice",
            ProductPrice = 2.49,
            ProductType = ProductType.Quantity
        };
        private readonly Product discountedApplesProduct = new Product
        {
            Discounts = new List<Interfaces.IDiscount>()
            { 
                new PercentageDiscount { Percentage = 0.2}
            },
            ProductCategory = "Kilo",
            ProductId = 1,
            ProductName = "Apples",
            ProductPrice = 1.99,
            ProductType = ProductType.Weight
        };

        public ShoppingCartTests()
        {

        }
        [Fact]
        public void ShoppingCartWithoutDiscounts()
        {
            cartItems.Add(new CartItem
            {
                 Product = riceProduct,
                 Quantity = 2
            });
            cartItems.Add(new CartItem
            {
                Product = applesProduct,
                Quantity = 2.5
            });
            shoppingCart.CartItems = cartItems;
            var totalPrice = shoppingCart.CalculateShoppingCart();

            Assert.Equal(9.955, totalPrice);
        }


        [Fact]
        public void ShoppingCartDiscounts()
        {
            cartItems = new List<CartItem>
            {
                new CartItem
                {
                    Product = discountedRiceProduct,
                    Quantity = 4
                },
                new CartItem
                {
                    Product = discountedApplesProduct,
                    Quantity = 2.5
                }
            }; 
            shoppingCart.CartItems = cartItems;
            var totalPrice = shoppingCart.CalculateShoppingCart();

            Assert.Equal(8.96, totalPrice);
        }
    }
}
