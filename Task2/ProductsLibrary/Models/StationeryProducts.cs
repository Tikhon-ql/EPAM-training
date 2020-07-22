using ProductTask.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTask.Models
{
    public class StationeryProducts : Product
    {
        public StationeryProducts(string name, decimal price) : base(name, "Канцелярские", price) { }
        /// <summary>
        /// Преобразование из FoodProducts к StationeryProducts
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator StationeryProducts(FoodProducts product)
        {
            if(product != null)
                return new StationeryProducts(product.Name, product.Price);
            else
                throw new Exception();
        }
        /// <summary>
        /// Преобразование из ElectricalProducts к StationeryProducts
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator StationeryProducts(ElectricalProducts product)
        {
            if (product != null)
                return new StationeryProducts(product.Name, product.Price);
            else
                throw new Exception();
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// </summary>
        public static StationeryProducts operator +(StationeryProducts s1, StationeryProducts s2)
        {
            if (s1 != null && s2 != null)
                return new StationeryProducts(s1.Name + "-" + s2.Name, (s1.Price + s2.Price) / 2);
            else
                throw new NullReferenceException();
        }
    }
}
