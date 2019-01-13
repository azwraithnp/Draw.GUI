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
    public class BlockCommand : SyntaxCommand
    {
        public string mapTo = null;
        public int mapToIndex = -1;
        public string lineString;

        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="id">id of the block command</param>
        /// <param name="index">index where the block command lies</param>
        /// <param name="name">name of the block command</param>
        /// <param name="line">line where the block command lies</param>
        public BlockCommand(int id, int index, string name, int line) : base(id, index, name, line) {}
        
    }
}
