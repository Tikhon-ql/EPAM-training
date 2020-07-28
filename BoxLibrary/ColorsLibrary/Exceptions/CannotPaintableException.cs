using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsLibrary.Exceptions
{
    /// <summary>
    /// Exceptions to the impossibility of recolouring the figure
    /// </summary>
    public class CannotPaintableException: Exception
    {
        public CannotPaintableException(string message) : base(message) { }
    }
}
