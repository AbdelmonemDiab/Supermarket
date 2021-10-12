﻿using Supermarket.ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Interfaces
{
    public interface IReceiptEngine
    {
        ReceiptDetails GenerateReceiptDetails(CartItem cartItem);
    }
}
