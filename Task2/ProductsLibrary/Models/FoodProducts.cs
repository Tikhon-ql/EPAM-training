using ProductTask.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
            if(product != null)
                return new FoodProducts(product.Name, product.Price);
            else 
                throw new Exception();
        }
        /// <summary>
        /// Преобразование из StationeryProducts к FoodProducts
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator FoodProducts(StationeryProducts product)
        {
            if (product != null)
                return new FoodProducts(product.Name, product.Price);
            else
                throw new Exception();
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// </summary>
        public static FoodProducts operator +(FoodProducts f1, FoodProducts f2)
        {
            if (f1 != null && f2 != null)
                return new FoodProducts(f1.Name + "-" + f2.Name, (f1.Price + f2.Price) / 2);
            else
                throw new NullReferenceException();
        }

    }
}
