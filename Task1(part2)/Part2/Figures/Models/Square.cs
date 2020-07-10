using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Models
{
    public class Square : Figure
    {
        //Координаты вершин
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Point P3 { get; set; }
        public Point P4 { get; set; }
        // Длинны сторон
        public double FirstSide { get; set; } = 0;
        public double SecondSide { get; set; } = 0;
        public double ThirdSide { get; set; } = 0;
        public double FourthSide { get; set; } = 0;


        public Square(Point p1, Point p2, Point p3, Point p4)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }

        public Square(double firstSide, double secondSide, double thirdSide, double fourthSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
            FourthSide = fourthSide;
        }

        public override double P()
        {
            if(FirstSide == 0)
            {
                return FirstSide * 4;
            }
            else
            {
                double a = P1.SearchDistance(P2);

                return a * 4;
            }
        }
        public override double S()
        {
            if (FirstSide == 0)
            {
                return FirstSide * FirstSide;
            }
            else
            {
                double a = P1.SearchDistance(P2);

                return a * a;
            }
        }
        public override string ToString()
        {
            string result = "Square;";
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
            Square squer = (Square)obj;
            if (FirstSide != 0 && squer.FirstSide != 0)
            {
                if (FirstSide == squer.FirstSide && SecondSide == squer.SecondSide && ThirdSide == squer.ThirdSide && FourthSide == squer.FourthSide)
                {
                    return true;
                }
            }
            else
            {
                if (P1.Equals(squer.P1) && P2.Equals(squer.P2) && P3.Equals(squer.P3) && P4.Equals(squer.P4))
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
