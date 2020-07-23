using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsLibrary.Exceptions
{
    /// <summary>
    /// Усключения, 
    /// </summary>
    public class CannotPaintableException: Exception
    {
        public CannotPaintableException(string message) : base(message) { }
    }
}
