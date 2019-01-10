using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class MoveToNotFoundException : Exception
    {
        public MoveToNotFoundException(string message) : base(message)
        {

        }
    }
}
