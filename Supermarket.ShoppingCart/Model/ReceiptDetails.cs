using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Model
{
    public class ReceiptItem
    {
        public Product Product { get; set; }
        public double Quantity { get; set; }

        public double TotalPrice => Quantity * Product.ProductPrice;
       
        public double DiscountedPrice { get; set; }
        public double DiscountPercentage { get; set; }
       
        //public double N { get; set; }
       // public CartItem CartItem { get; set; }

    }
}
