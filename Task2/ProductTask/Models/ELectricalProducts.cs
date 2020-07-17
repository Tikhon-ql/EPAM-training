using ProductTask.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTask.Models
{
    public class ELectricalProducts:Product
    {
        public ELectricalProducts(string name, decimal price) : base(name, "Электрические", price) { }
        /// <summary>
        /// Преобразование из FoodProducts к ElectricalPRoducts
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator ELectricalProducts(FoodProducts product)
        {
            return new ELectricalProducts(product.Name,  product.Price);
        }
        /// <summary>
        /// Преобразование из StationeryProducts к ElectricalPRoducts
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator ELectricalProducts(StationeryProducts product)
        {
            return new ELectricalProducts(product.Name, product.Price);
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// </summary>
        public static ELectricalProducts operator +(ELectricalProducts e1, ELectricalProducts e2)
        {
            return new ELectricalProducts(e1.Name + "-" + e2.Name, (e1.Price + e2.Price) / 2);
        }
    }
}
