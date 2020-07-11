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
        public double FirstSide { get; set; } = 0;
        public double SecondSide { get; set; } = 0;
        public double ThirdSide { get; set; } = 0;

        public Triangle(double f,double s,double t)
        {
            FirstSide = f;
            SecondSide = s;
            ThirdSide = t;
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
            return "Triangle;" + FirstSide.ToString() + ";" + SecondSide.ToString() + ";" + ThirdSide.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Triangle triangle &&
                   base.Equals(obj) &&
                   FirstSide == triangle.FirstSide &&
                   SecondSide == triangle.SecondSide &&
                   ThirdSide == triangle.ThirdSide;
        }
    }
}
