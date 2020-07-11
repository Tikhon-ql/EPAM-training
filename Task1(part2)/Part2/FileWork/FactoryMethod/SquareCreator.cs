using Figures;
using Figures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWork.FactoryMethod
{
    class SquareCreator : FigureCreator
    {
        /// <summary>
        /// Создание квадрата
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public Figure FigureCreate(string[] strs)
        {
            // 0 элемент - название фигуры
            return new Square(Convert.ToDouble(strs[1]));
        }
    }
}
