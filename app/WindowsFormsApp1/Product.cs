﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Product
    {
        public string title;
        public string type_product;
        public int articul;
        public string material;
        public decimal price;

        public Product(string title, string type_product, int articul,string material, decimal price)
        {
            this.title = title;
            this.type_product = type_product;
            this.articul = articul;
            this.material = material;
            this.price = price;
        }
    }
}
