﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    abstract public class Figure
    {
        /// <summary>
        /// Метод нахождения площади фигуры
        /// </summary>
        /// <returns></returns>
        public abstract double S();
        /// <summary>
        /// Метод нахождения периметра фигуры
        /// </summary>
        /// <returns></returns>
        public abstract double P();
    }
}
