using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    abstract class SyntaxCommand
    {
        public int id;
        public int index;
        public int line;
        public string name;

        public SyntaxCommand(int id, int index, string name, int line)
        {
            this.id = id;
            this.index = index;
            this.name = name;
            this.line = line;
        }



    }
}
