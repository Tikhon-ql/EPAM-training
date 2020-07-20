using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BoxLibrary.Figures
{
    public class Ball:Figure
    {
        public double R { get; set; }
        public Ball(double r,Material material,Color color):base(material,color)
        {
            R = r;
        }
        public Ball(Figure fig,int r):base(fig.Material, fig.Color)
        {
            if(r * r * Math.PI < fig.S())
            {
                R = r;
            }
        }
        /// <summary>
        /// Метод нахождения периметра круга
        /// </summary>
        /// <returns></returns>
        public override double P()
        {
            return Math.Round(2 * Math.PI * R);
        }
        /// <summary>
        /// Метод нахождения площади круга
        /// </summary>
        /// <returns></returns>
        public override double S()
        {
            return Math.Round(Math.PI * R * R);
        }
        public override string ToString()
        {
            return "Круг;" + R;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return -51877379 + R.GetHashCode();
        }
    }
}
