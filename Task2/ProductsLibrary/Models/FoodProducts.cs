using ProductTask.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTask.Models
{
    public class FoodProducts : Product
    {
        public FoodProducts(string name, decimal price) : base(name, "Пищевые", price) { }
        /// <summary>
        /// Преобразование из ElectriaclaPRoducts к FoodProducts
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator FoodProducts(ElectricalProducts product)
        {
            return new FoodProducts(product.Name, product.Price);
        }
        /// <summary>
        /// Преобразование из StationeryProducts к FoodProducts
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator FoodProducts(StationeryProducts product)
        {
            return new FoodProducts(product.Name, product.Price);
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// </summary>
        public static FoodProducts operator +(FoodProducts f1, FoodProducts f2)
        {
            return new FoodProducts(f1.Name + "-" + f2.Name, (f1.Price + f2.Price) / 2);
        }

    }
}
