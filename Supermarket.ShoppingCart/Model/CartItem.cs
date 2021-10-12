using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Model
{
    public class CartItem
    {
        private double _Quantity;
        public double Quantity
        {
            get
            { 
                return _Quantity;
            }

            set
            {
                if (value < 0)
                    throw new Exception("Quantity should be greater than zero");
                if(Product?.ProductType == ProductType.Quantity && !int.TryParse(value.ToString(), out int q))
                {
                    throw new Exception("Quantity should be Numbers without fractions");
                }
                _Quantity = value;
            } 
        } 
        public Product Product { get; set; }

        public double ApplyDiscount()
        {
            double discountedQuantity = 0;
           
            double initalQuantity = Quantity;
             double totalQuantity = 0;
            foreach (QuantityDiscount discount in Product.Discounts.Where(d => d is QuantityDiscount))
            {

                discountedQuantity =+ discount.ApplyDiscount(initalQuantity);

                initalQuantity = discount.GetUndiscountedQuantity(initalQuantity);
            }
            totalQuantity = discountedQuantity + initalQuantity;
            foreach (PercentageDiscount discount in Product.Discounts.Where(d => d is PercentageDiscount))
            {
                totalQuantity = discount.ApplyDiscount(totalQuantity);
            }
            double totalDiscounted = Product.ProductPrice * totalQuantity; 
            return totalDiscounted;
        }

    }
}
