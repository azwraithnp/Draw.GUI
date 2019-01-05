using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class BlockCommand : SyntaxCommand
    {
        public string mapTo = null;
        public int mapToIndex = -1;
        public string lineString;

        public BlockCommand(int id, int index, string name, int line) : base(id, index, name, line) {}
        
    }
}
