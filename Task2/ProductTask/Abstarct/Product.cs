using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTask.Abstarct
{
    public abstract class Product
    {
        public string Name { get; set; }
        public string Kind { get; set; }
        public decimal Price { get; set; }

        protected Product(string name, string kind, decimal price)
        {
            Name = name;
            Kind = kind;
            Price = price;
        }
        /// <summary>
        /// Перобразование к int
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator int(Product product)
        {
            return Convert.ToInt32(product.Price) * 100;
        }
        /// <summary>
        /// Преобразование к double
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator double(Product product)
        {
            return Convert.ToDouble(product.Price) * 100;
        }
    }
}
