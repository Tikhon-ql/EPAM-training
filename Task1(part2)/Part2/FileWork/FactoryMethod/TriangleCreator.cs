using Figures;
using Figures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWork.FactoryMethod
{
    class TriangleCreator : FigureCreator
    {
        /// <summary>
        /// Создание треугольника
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public Figure FigureCreate(string[] strs)
        {
            // 0 элемент - название фигуры
            return new Triangle(double.Parse(strs[1]),Convert.ToDouble(strs[2]),Convert.ToDouble(strs[3]));
        }
    }
}
