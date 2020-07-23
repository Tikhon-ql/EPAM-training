using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Exceptions
{
    public class CannotCutableException:Exception
    {
        public CannotCutableException(string message) : base(message) { }
    }
}
