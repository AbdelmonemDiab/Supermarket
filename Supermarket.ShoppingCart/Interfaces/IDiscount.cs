﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Interfaces
{
    public interface IDiscount
    {
        double ApplyDiscount(double quanitty);
    }
}
