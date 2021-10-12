﻿using Supermarket.ShoppingCart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingCart.Model
{
    public class Product
    {
        private double _ProductPrice;
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice
        {
            get 
            {
                return _ProductPrice;
            }
            set 
            {
                if (value < 0)
                    throw new Exception("Product Price should be greater than 0");
                _ProductPrice = value;
            }
        }

        public string ProductCategory { get; set; }
        public List<IDiscount> Discounts { get; set; }
        public ProductType ProductType { get; set; }
    }
}