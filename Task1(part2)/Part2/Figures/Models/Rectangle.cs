using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Models
{
    public class Rectangle : Figure
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Point P3 { get; set; }
        public Point P4 { get; set; }

        public double FirstSide { get; set; } = 0;
        public double SecondSide { get; set; } = 0;
        public double ThirdSide { get; set; } = 0;
        public double FourthSide { get; set; } = 0;

        public Rectangle(Point p1, Point p2, Point p3, Point p4)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }

        public Rectangle(double firstSide, double secondSide, double thirdSide, double fourthSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
            FourthSide = fourthSide;
        }

        public override double P()
        {
            if(FirstSide != 0)
            {
                return FirstSide + SecondSide + ThirdSide + FourthSide;
            }
            else
            {
                double a = P1.SearchDistance(P2);
                double b = P2.SearchDistance(P3);
                double c = P3.SearchDistance(P4);
                double d = P4.SearchDistance(P1);
                return a + b + c + d;
            }

        }

        public override double S()
        {
            if(FirstSide != 0)
            {
                return FirstSide * SecondSide;
            }
            else
            {
                double ab = P1.SearchDistance(P2) + P2.SearchDistance(P3);
                double cd = P3.SearchDistance(P4) + P4.SearchDistance(P1);
                return ab * cd;
            }
        }
        public override string ToString()
        {
            string result = "Rectangle;";
            if (FirstSide != 0)
            {
                result += FirstSide + ";" + SecondSide + ";" + ThirdSide + ";" + FourthSide;
            }
            else
            {
                result += P1.ToString() + ";" + P2.ToString() + ";" + P3.ToString() + ";" + P4.ToString();
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            Rectangle rectangle = (Rectangle)obj;
            if(FirstSide != 0 && rectangle.FirstSide != 0)
            {
                if(FirstSide == rectangle.FirstSide && SecondSide == rectangle.SecondSide && ThirdSide == rectangle.ThirdSide && FourthSide == rectangle.FourthSide)
                {
                    return true;
                }
            }
            else
            {
                if(P1.Equals(rectangle.P1) && P2.Equals(rectangle.P2) && P3.Equals(rectangle.P3) && P4.Equals(rectangle.P4))
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 1655589029;
            hashCode = hashCode * -1521134295 + EqualityComparer<Point>.Default.GetHashCode(P1);
            hashCode = hashCode * -1521134295 + EqualityComparer<Point>.Default.GetHashCode(P2);
            hashCode = hashCode * -1521134295 + EqualityComparer<Point>.Default.GetHashCode(P3);
            hashCode = hashCode * -1521134295 + EqualityComparer<Point>.Default.GetHashCode(P4);
            hashCode = hashCode * -1521134295 + FirstSide.GetHashCode();
            hashCode = hashCode * -1521134295 + SecondSide.GetHashCode();
            hashCode = hashCode * -1521134295 + ThirdSide.GetHashCode();
            hashCode = hashCode * -1521134295 + FourthSide.GetHashCode();
            return hashCode;
        }
    }
}
