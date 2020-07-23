using FiguresLibrary.Abstract;
using FiguresLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Models.FilmFigures
{
    public class FilmRectangle:FilmFigure
    {
        public FilmRectangle(double h, double w) : base()
        {
            Height = h;
            Width = w;
        }
        public FilmRectangle(FilmFigure figure, double widht, double height)
        {
            Width = widht;
            Height = height;
            if (S() > figure.S())
                throw new CannotCutableException("Невозможно вырезать фигуру");
        }
        public FilmRectangle() : base()
        {

        }
        // длинна квадрата
        public double Height { get; set; } = 0;
        // ширина квадрата
        public double Width { get; set; } = 0;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            int hashCode = 168294001;
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            return hashCode;
        }

        public override double P()
        {

            return (Width + Height) * 2;
        }

        public override double S()
        {
            return Height * Width;
        }
        public override string ToString()
        {
            return "FilmRectangle;" + Height + ";" + Width;
        }
        public override Dictionary<string, string> AttributeXml()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("width", Width.ToString());
            dictionary.Add("height", Height.ToString());
            return dictionary;
        }
        public override string XmlString()
        {
            return "FilmRectangle";
        }
    }
}
