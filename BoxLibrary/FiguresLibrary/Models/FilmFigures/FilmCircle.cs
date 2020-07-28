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
        /// <summary>
        /// Constructor to cut from another figure
        /// </summary>
        /// <param name="fig">The figure from we cut</param>
        /// <param name="r">radius</param>
        public FilmCircle(FilmFigure fig, int r)
        {
            R = r;
            if(this.S() > fig.S())
                throw new CannotCutableException("Невозможно вырезать фигуру");
        }
        public FilmCircle()
        {

        }
        public override double P()
        {
            return Math.Round(2 * Math.PI * R, 2);
        }
        public override double S()
        {
            return Math.Round(Math.PI * R * R,2);
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
        public override Dictionary<string, string> AttributeXml()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("radius", R.ToString());
            dictionary.Add("type", "FilmCircle");
            return dictionary;
        }
    }
}
