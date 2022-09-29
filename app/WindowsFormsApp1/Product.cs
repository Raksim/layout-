using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Product
    {
        public int id;
        public string title;
        public string type_product;
        public int articul;
        public string material;
        public string image;
        public decimal price;

        public Product(int id, string title, string type_product, int articul,string material,string image, decimal price)
        {
            this.id = id;
            this.title = title;
            this.type_product = type_product;
            this.articul = articul;
            this.material = material;
            this.image = image;
            this.price = price;
        }
    }
}
