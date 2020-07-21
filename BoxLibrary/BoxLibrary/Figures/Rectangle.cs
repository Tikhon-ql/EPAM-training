using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxLibrary.Figures
{
    public class Rectangle : Figure
    {

        public Rectangle(double h, double w,Material material,Color color):base(material,color)
        {
            Height = h;
            Width = w;
        }
        // длинна квадрата
        public double Height { get; set; } = 0;
        // ширина квадрата
        public double Width { get; set; } = 0;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public Rectangle()
        {

        }
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
        public override Dictionary<string,string> AttributeXml()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("width",Width.ToString());
            dictionary.Add("height",Height.ToString());
            dictionary.Add("color",Color.ToString());
            dictionary.Add("material", Material.ToString());
            return dictionary;
        }
        public override string XmlString()
        {
            return "Rectangle";
        }
    }
}
