using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    /// <summary>
    /// creates an exception class to handle when pen command is not found in the code,
    /// inherits the system Exception class
    /// </summary>
    class PenNotFoundException : Exception
    {
        /// <summary>
        /// creates a constructor for this class that can be throwed when exception is found
        /// </summary>
        /// <param name="message">message to associate the exception with</param>
        public PenNotFoundException(string message) : base(message)
        {

        }
    }
}
