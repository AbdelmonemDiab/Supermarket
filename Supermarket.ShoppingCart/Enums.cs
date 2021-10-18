using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart
{
    public enum ProductType
    {
        Weight,
        Quantity
    }
    public enum PricePerUnit
    {
        One=1,
        Ten =10,
        Hundred = 100,
        TwoHundred50 =250,
        FiveHundred =500,
        Thousand =1000
    }
}
