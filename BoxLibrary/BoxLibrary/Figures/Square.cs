using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxLibrary.Figures
{
    public class Square : Figure
    {
        public Square(double s,Material material,Color color):base(material,color)
        {
            Side = s;
        }
        public Square()
        {

        }
        // сторона квадрата
        public double Side { get; set; } = 0;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

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
        public override Dictionary<string, string> AttributeXml()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("side",Side.ToString());
            dictionary.Add("color", Color.ToString());
            dictionary.Add("material", Material.ToString());
            return dictionary;
        }
        public override string XmlString()
        {
            return "Square";
        }
    }
}
