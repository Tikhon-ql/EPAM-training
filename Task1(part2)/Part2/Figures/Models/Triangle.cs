using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Models
{
    public class Triangle : Figure
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Point P3 { get; set; }
        public double FirstSide { get; set; } = 0;
        public double SecondSide { get; set; } = 0;
        public double ThirdSide { get; set; } = 0;

        public Triangle(Point p1, Point p2, Point p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        public override double P()
        {
            if (FirstSide != 0)
            {
                return FirstSide + SecondSide + ThirdSide;
            }
            else
            {
                double a = P1.SearchDistance(P2);
                double b = P2.SearchDistance(P3);
                double c = P3.SearchDistance(P1);
                return a + b + c;
            }
        }

        public override double S()
        {
            double p = this.P() / 2;
            ////hfgh/////
            if (FirstSide != 0) 
            {
                return Math.Sqrt(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide));
            }
            else
            {
                double a = P1.SearchDistance(P2);
                double b = P2.SearchDistance(P3);
                double c = P3.SearchDistance(P1);
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }
        public override string ToString()
        {
            string result = "Triangle;";
            if(FirstSide != 0)
            {
                result += FirstSide + ";" + SecondSide + ";" + ThirdSide;
            }
            else
            {
                result += P1.ToString() + ";" + P2.ToString() + ";" + P3.ToString();
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            Triangle tr = ((Triangle)obj);
            if(FirstSide != 0 && tr.FirstSide != 0)
            {
                if (FirstSide == tr.FirstSide && SecondSide == tr.SecondSide && ThirdSide == tr.ThirdSide)
                    return true;
            }
            else
            {
                if (P1.Equals(tr.P1) && P2.Equals(tr.P2) && P3.Equals(tr.P3))
                    return true;
            }
            return false;
        }
    }
}
