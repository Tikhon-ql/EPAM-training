using FiguresLibrary.Abstract;
using FiguresLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Models.FilmFigures
{
    public class FilmCircle:FilmFigure
    {
        public double R { get; set; }
        public FilmCircle(double r)
        {
            R = r;
        }
        public FilmCircle(Figure fig, int r)
        {
            R = r;
            if(S() > fig.S())
                throw new CannotCutableException("Невозможно вырезать фигуру");
        }
        public FilmCircle()
        {

        }
        /// <summary>
        /// Метод нахождения периметра круга
        /// </summary>
        /// <returns></returns>
        public override double P()
        {
            return Math.Round(2 * Math.PI * R);
        }
        /// <summary>
        /// Метод нахождения площади круга
        /// </summary>
        /// <returns></returns>
        public override double S()
        {
            return Math.Round(Math.PI * R * R);
        }
        public override string ToString()
        {
            return "FilmCircle;" + R;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return -51877379 + R.GetHashCode();
        }
        public override string XmlString()
        {
            return "FilmCircle";
        }
        public override Dictionary<string, string> AttributeXml()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("radius", R.ToString());
            return dictionary;
        }
    }
}
