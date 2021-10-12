using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Model
{
    public class ReceiptDetails
    {
        public CartItem CartItem { get; set; }
        public double DiscountedPrice { get; set; }
        public double DiscountPercentage { get; set; }


    }
}
