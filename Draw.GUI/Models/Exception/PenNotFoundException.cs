using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class PenNotFoundException : Exception
    {
        public PenNotFoundException(string message) : base(message)
        {

        }
    }
}
