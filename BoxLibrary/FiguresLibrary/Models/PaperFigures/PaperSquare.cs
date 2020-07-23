using ColorsLibrary.Exceptions;
using FiguresLibrary.Abstract;
using FiguresLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Models.PaperFigures
{
    public class PaperSquare : PaperFigure
    {
        public PaperSquare(double s)
        {
            Side = s;
        }
        public PaperSquare(){}
        public PaperSquare(PaperFigure figure,double s)
        {
            Side = s;
            Color = figure.Color;
            if (S() > figure.S())
                throw new CannotCutableException("Невозможно вырезать фигуру");
        }
        // сторона квадрата
        public double Side { get; set; } = 0;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return -1545931474 + Side.GetHashCode();
        }

        public override double P()
        {
            return Side * 4;
        }
        public override double S()
        {

            return Side * Side;
        }
        public override string ToString()
        {
            return "PaperSquare;" + Side;
        }
        public override Dictionary<string, string> AttributeXml()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("side", Side.ToString());
            dictionary.Add("color", Color.ToString());
            return dictionary;
        }
        public override string XmlString()
        {
            return "PaperSquare";
        }
    }
}
