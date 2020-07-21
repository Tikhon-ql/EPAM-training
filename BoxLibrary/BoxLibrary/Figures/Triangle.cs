using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxLibrary.Figures
{
    public class Triangle : Figure
    {
        public double FirstSide { get; set; } = 0;
        public double SecondSide { get; set; } = 0;
        public double ThirdSide { get; set; } = 0;

        public Triangle(double f, double s, double t,Material material,Color color):base(material,color)
        {
            FirstSide = f;
            SecondSide = s;
            ThirdSide = t;
        }
        public Triangle()
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
            return "Triangle;" + FirstSide.ToString() + ";" + SecondSide.ToString() + ";" + ThirdSide.ToString();
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
            dictionary.Add("material", Material.ToString());
            return dictionary;
        }
        public override string XmlString()
        {
            return "Triangle";
        }
    }
}
