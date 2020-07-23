
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorsLibrary;
using ColorsLibrary.Exceptions;

namespace FiguresLibrary.Abstract
{
    public abstract class PaperFigure:Figure
    {
        public PaperFigure()
        {

        }
        public PaperFigure(Colors color)
        {
            Color = color;
        }
        public bool IsPainted { get; set; } = false;
        public Colors Color { get; set; } = Colors.White;

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
