using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BoxLibrary.Figures
{
    public class Circle:Figure
    {
        public double R { get; set; }
        public Circle(double r,Material material,Color color):base(material,color)
        {
            R = r;
        }
        public Circle(Figure fig,int r):base(fig.Material, fig.Color)
        {
            if(r * r * Math.PI < fig.S())
            {
                R = r;
            }
        }
        public Circle()
        {

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
        public override string XmlString()
        {
            return "Circle";
        }
        public override Dictionary<string,string> AttributeXml()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("radius",R.ToString());
            dictionary.Add("color", Color.ToString());
            dictionary.Add("marerial", Material.ToString());
            return dictionary;
        }
    }
}
