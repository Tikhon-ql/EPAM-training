using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Models
{
    public class Rectangle : Figure
    {

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
