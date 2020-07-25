using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Exceptions
{
    /// <summary>
    /// Исключения невозможности вырезать одну фигуру из другой
    /// </summary>
    public class CannotCutableException:Exception
    {
        public CannotCutableException(string message) : base(message) { }
    }
}
