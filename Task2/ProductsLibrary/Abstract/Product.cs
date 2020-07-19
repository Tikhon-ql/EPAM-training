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
        /// Перобразование к целочисленному типу (int)
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator int(Product product)
        {
            return Convert.ToInt32(product.Price) * 100;
        }
        /// <summary>
        /// Преобразование к вещественному типу(decimal)
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator decimal(Product product)
        {
            return product.Price * 100;
        }
        public override string ToString()
        {
            return Name + " " + Kind + " " + Price;
        }
    }
}
