
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorsLibrary;
using ColorsLibrary.Exceptions;

namespace FiguresLibrary.Abstract
{
    /// <summary>
    /// Paper figures's class
    /// </summary>
    public abstract class PaperFigure:Figure
    {
        public PaperFigure()
        {

        }   
        public PaperFigure(Colors color)
        {
            Color = color;
        }
        /// <summary>
        /// Figure is painted property
        /// </summary>
        public bool IsPainted { get; set; } = false;
        public Colors Color { get; set; } = Colors.White;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int hashCode = 715578416;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + IsPainted.GetHashCode();
            hashCode = hashCode * -1521134295 + Color.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// Coloring paper figure method
        /// </summary>
        /// <param name="color"></param>
        public void Paint(Colors color)
        {
            if (!IsPainted)
            {
                Color = color;
                IsPainted = true;
            }
            else
                throw new CannotPaintableException("Невозможно окрасить фигуру");
        }

    }
}
