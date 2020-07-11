using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Models
{
    public class Point
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        /// <summary>
        /// Метод нахождения расстояния между двумя точками
        /// </summary>
        /// <returns></returns>
        public double SearchDistance(Point point)
        {
            int x = point.X - this.X;
            int y = point.Y - this.Y;
            return Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2));
        }
        public override string ToString()
        {
            return X + ":" + Y;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object obj)
        {
            if (X == ((Point)obj).X && Y == ((Point)obj).Y)
                return true;
            else
                return false;
        }
        public static Point Parse(string str)
        {
            string[] strs = str.Split(',');
            return new Point(int.Parse(strs[0]),Convert.ToInt32(strs[1]));
        }
    }
}
