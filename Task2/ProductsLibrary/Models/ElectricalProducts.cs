using ProductTask.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTask.Models
{
    public class ElectricalProducts : Product
    {
        public ElectricalProducts(string name, decimal price) : base(name, "Электрические", price) { }
        /// <summary>
        /// Преобразование из FoodProducts к ElectricalPRoducts
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator ElectricalProducts(FoodProducts product)
        {
            if (product != null)
                return new ElectricalProducts(product.Name, product.Price);
            else 
                throw new Exception();
        }
        /// <summary>
        /// Преобразование из StationeryProducts к ElectricalPRoducts
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator ElectricalProducts(StationeryProducts product)
        {
            if (product != null)
                return new ElectricalProducts(product.Name, product.Price);
            else
                throw new Exception();
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// </summary>
        public static ElectricalProducts operator +(ElectricalProducts e1, ElectricalProducts e2)
        {
            return new ElectricalProducts(e1.Name + "-" + e2.Name, (e1.Price + e2.Price) / 2);
        }
    }
}
