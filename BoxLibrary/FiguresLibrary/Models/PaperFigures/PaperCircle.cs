using FiguresLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorsLibrary;
using System.Runtime.ExceptionServices;
using FiguresLibrary.Exceptions;

namespace FiguresLibrary.Models.PaperFigures
{
    public class PaperCircle : PaperFigure
    {
        public double R { get; set; }
        public PaperCircle(double r, Colors color) : base(color)
        {
            R = r;
        }
        public PaperCircle(double r):base()
        {
            R = r;
        }
        public PaperCircle(PaperFigure fig, int r)
        {
            this.R = r;
            Color = fig.Color;
            if(S() > fig.S())
                throw new CannotCutableException("Невозможно вырезать фигуру");
        }
        public PaperCircle()
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
            return "PaperCircle;" + R;
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
            return "PaperCircle";
        }
        public override Dictionary<string, string> AttributeXml()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("radius", R.ToString());
            dictionary.Add("color", Color.ToString());
            return dictionary;
        }
    }
}
