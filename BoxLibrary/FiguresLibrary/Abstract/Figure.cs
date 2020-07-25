using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Abstract
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
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (this.P() == ((Figure)obj).P())
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Метод для подговки атрибутов xml
        /// </summary>
        /// <returns></returns>
        public abstract Dictionary<string, string> AttributeXml();
    }
}
