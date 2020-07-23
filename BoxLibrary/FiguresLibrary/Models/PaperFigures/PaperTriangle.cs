using ColorsLibrary;
using FiguresLibrary.Abstract;
using FiguresLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Models.PaperFigures
{
    public class PaperTriangle:PaperFigure
    {
        public double FirstSide { get; set; } = 0;
        public double SecondSide { get; set; } = 0;
        public double ThirdSide { get; set; } = 0;

        public PaperTriangle(double f, double s, double t, Colors color) : base( color)
        {
            FirstSide = f;
            SecondSide = s;
            ThirdSide = t;
        }
        public PaperTriangle(double f, double s, double t) : base()
        {
            FirstSide = f;
            SecondSide = s;
            ThirdSide = t;
        }
        public PaperTriangle(PaperFigure figure,double f, double s, double t)
        {
            FirstSide = f;
            SecondSide = s;
            ThirdSide = t;
            Color = figure.Color;
            if(S() > figure.S())
                throw new CannotCutableException("Невозможно вырезать фигуру");
        }
        public PaperTriangle():base()
        {

        }


        public override int GetHashCode()
        {
            int hashCode = -1075677331;
            hashCode = hashCode * -1521134295 + FirstSide.GetHashCode();
            hashCode = hashCode * -1521134295 + SecondSide.GetHashCode();
            hashCode = hashCode * -1521134295 + ThirdSide.GetHashCode();
            return hashCode;
        }

        public override double P()
        {
            return FirstSide + SecondSide + ThirdSide;
        }

        public override double S()
        {
            double p = this.P() / 2;
            return Math.Sqrt(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide));
        }
        public override string ToString()
        {
            return "PaperTriangle;" + FirstSide.ToString() + ";" + SecondSide.ToString() + ";" + ThirdSide.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override Dictionary<string, string> AttributeXml()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("first", FirstSide.ToString());
            dictionary.Add("second", SecondSide.ToString());
            dictionary.Add("third", ThirdSide.ToString());
            dictionary.Add("color", Color.ToString());
            return dictionary;
        }
        public override string XmlString()
        {
            return "PaperTriangle";
        }
    }
}
