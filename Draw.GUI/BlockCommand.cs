using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class BlockCommand : SyntaxCommand
    {
        public string mapTo;
        
        public BlockCommand(int id, int index, string name) : base(id, index, name) {}
        
    }
}
