using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    /// <summary>
    /// creates a model class for block commands used in the application,
    /// inherits the SyntaxCommand model class
    /// </summary>
    class CommentCommand : SyntaxCommand
    {
        public string mapTo = null;
        
        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="id">id of the comment command</param>
        /// <param name="index">index where the comment command lies</param>
        /// <param name="name">name of the comment command</param>
        /// <param name="line">line where the comment command lies</param>
        public CommentCommand(int id, int index, string name, int line) : base(id, index, name, line) {}
        
    }
}
