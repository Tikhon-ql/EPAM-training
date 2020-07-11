using Figures;
using Figures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWork.FactoryMethod
{
 
    class RectanlgeCreator : FigureCreator
    {
        /// <summary>
        /// Создание прямоугольника
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Figure FigureCreate(string[] str)
        {
            // 0 элемент - название фигуры
            return new Rectangle(double.Parse(str[1]),Convert.ToDouble(str[2]));
        }
    }
}
