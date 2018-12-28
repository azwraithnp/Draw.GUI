using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class CommentCommand : SyntaxCommand
    {
        public string mapTo = null;
        
        public CommentCommand(int id, int index, string name) : base(id, index, name) {}
        
    }
}
