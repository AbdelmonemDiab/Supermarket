using Supermarket.ShoppingCart.Engine;
using Supermarket.ShoppingCart.Interfaces;
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
        private readonly Model.ShoppingCart shoppingCart = new Model.ShoppingCart( new ReceiptEngine( new DiscountEngine()));
        private  List<CartItem> cartItems = new List<CartItem>();
        private Product riceProduct = Helper.GetSampleProducts()
                                            .First(c => c.ProductName.ToLower() == "rice");
        private Product applesProduct = Helper.GetSampleProducts()
                                            .First(c => c.ProductName.ToLower() == "apples");

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
                Quantity = 2500
            });
            shoppingCart.CartItems = cartItems;
            var totalPrice = shoppingCart.CalculateShoppingCart();

            Assert.Equal(9.955, totalPrice);
        }


        [Fact]
        public void ShoppingCartDiscounts()
        {
            riceProduct.Discounts = Helper.GetQuantityDiscounts()
                                          .Where(c => c.BuyQuantity == 2 && c.GetQuantity == 2)
                                          .Select(c=>(IDiscount) c)
                                          .ToList();
            applesProduct.Discounts = Helper.GetPercentageDiscounts()
                                          .Where(c => c.MinmumQuantity == 0 && c.Percentage ==0.2)
                                          .Select(c => (IDiscount)c)
                                          .ToList();

            cartItems = new List<CartItem>
            {
                new CartItem
                {
                    Product = riceProduct,
                    Quantity = 4
                },
                new CartItem
                {
                    Product = applesProduct,
                    Quantity = 2500
                }
            }; 
            shoppingCart.CartItems = cartItems;
            var totalPrice = shoppingCart.CalculateShoppingCart();

            Assert.Equal(8.96, totalPrice);
        }
        [Fact]
        public void ShoppingCart2Discounts()
        {
            riceProduct.Discounts = Helper.GetQuantityDiscounts()
                              .Where(c => c.BuyQuantity == 2 && c.GetQuantity == 2)
                              .Select(c => (IDiscount)c)
                              .ToList();
            applesProduct.Discounts = Helper.GetPercentageDiscounts()
                                          .Where(c => c.MinmumQuantity == 0 && c.Percentage == 0.2)
                                          .Select(c => (IDiscount)c)
                                          .ToList();
            cartItems = new List<CartItem>
            {
                new CartItem
                {
                    Product = riceProduct,
                    Quantity = 2
                },
                new CartItem
                {
                    Product = applesProduct,
                    Quantity = 2500
                }
            };
            shoppingCart.CartItems = cartItems;
            var totalPrice = shoppingCart.CalculateShoppingCart();

            Assert.Equal(8.96, totalPrice);
        }
    }
}
