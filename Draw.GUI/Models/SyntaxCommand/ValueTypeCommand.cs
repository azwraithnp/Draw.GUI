using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class ValueTypeCommand : SyntaxCommand
    {
        public string lineString;

        public ValueTypeCommand(int id, int index, string name, int line, string lineString) : base(id, index, name, line)
        {
            this.lineString = lineString;
        }
    }
}
