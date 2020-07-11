using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Models
{
    public class Square : Figure
    {
        //Координаты вершин
        //public Point P1 { get; set; }
        //public Point P2 { get; set; }
        //public Point P3 { get; set; }
        //public Point P4 { get; set; }

        //public Square(Point p1, Point p2, Point p3, Point p4)
        //{
        //    P1 = p1;
        //    P2 = p2;
        //    P3 = p3;
        //    P4 = p4;
        //}



        //public override double P()
        //{

        //        double a = P1.SearchDistance(P2);

        //        return a * 4;
        //}
        //public override double S()
        //{

        //    double a = P1.SearchDistance(P2);
        //    return a * a;
        //}
        //public override string ToString()
        //{
        //    return "Square;" + P1.ToString() + ";" + P2.ToString() + ";" + P3.ToString() + ";" + P4.ToString();
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
        public Square(double s)
        {
            Side = s;
        }
        public double Side { get; set; } = 0;

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
            return "Square;" + Side;
        }
    }
}
