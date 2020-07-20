using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxLibrary.Figures
{
    abstract public class Figure
    {
        public Material Material { get; set; }
        public Color Color { get; set; }
        /// <summary>
        /// Свойство для провкрки покрашенна ли фигура(если фигура из пленки то IsPainted = true)
        /// </summary>
        public bool IsPainted { get; set; } = false;
        protected Figure(Material material,Color color)
        {
            Material = material;
            if(material != Material.Film)
            {
                Color = color;
            }
            else
            {
                IsPainted = true;
            }
        }
        public Figure()
        {

        }
        /// <summary>
        /// Метод покраски бумажной фигуры
        /// </summary>
        /// <param name="color"></param>
        public void Paint(Color color)
        {
            if (!IsPainted)
                Color = color;
        }
        /// <summary>
        /// Метод нахождения площади фигуры
        /// </summary>
        /// <returns></returns>
        public abstract double S();
        /// <summary>
        /// Метод нахождения периметра фигуры
        /// </summary>
        /// <returns></returns>
        public abstract double P();
        public override bool Equals(object obj)
        {
            if(obj != null)
            {
                if (this.P() == ((Figure)obj).P())
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
