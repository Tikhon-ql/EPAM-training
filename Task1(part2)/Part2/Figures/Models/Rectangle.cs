using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Models
{
    public class Rectangle : Figure
    {
        //public Point P1 { get; set; }
        //public Point P2 { get; set; }
        //public Point P3 { get; set; }
        //public Point P4 { get; set; }


        //public Rectangle(Point p1, Point p2, Point p3, Point p4)
        //{
        //    P1 = p1;
        //    P2 = p2;
        //    P3 = p3;
        //    P4 = p4;
        //}

        //public override double P()
        //{
        //    double a = P1.SearchDistance(P2);
        //    double b = P2.SearchDistance(P3);
        //    double c = P3.SearchDistance(P4);
        //    double d = P4.SearchDistance(P1);
        //    return a + b + c + d;
        //}

        //public override double S()
        //{
        //    double ab = P1.SearchDistance(P2) + P2.SearchDistance(P3);
        //    double cd = P3.SearchDistance(P4) + P4.SearchDistance(P1);
        //    return ab * cd;
        //}
        //public override string ToString()
        //{
        //    return "Rectangle;" + P1.ToString() + ";" + P2.ToString() + ";" + P3.ToString() + ";" + P4.ToString();
        //}


        //public override int GetHashCode()
        //{
        //    int hashCode = 1655589029;
        //    hashCode = hashCode * -1521134295 + EqualityComparer<Point>.Default.GetHashCode(P1);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<Point>.Default.GetHashCode(P2);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<Point>.Default.GetHashCode(P3);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<Point>.Default.GetHashCode(P4);
        //    return hashCode;
        //}

        public Rectangle(double h,double w)
        {
            Height = h;
            Width = w;
        }

        public double Height { get; set; } = 0;
        public double Width { get; set; } = 0;

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
            return "Rectangle;" + Height + ";" + Width;
        }

    }
}
