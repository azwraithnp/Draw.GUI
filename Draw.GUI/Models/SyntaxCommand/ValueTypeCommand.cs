using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    /// <summary>
    /// creates a model class for value type commands used in the application,
    /// inherits the SyntaxCommand model class
    /// </summary>
    class ValueTypeCommand : SyntaxCommand
    {
        public string lineString;

        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="id">id of the command</param>
        /// <param name="index">index where the command lies</param>
        /// <param name="name">name of the command</param>
        /// <param name="line">line where the command lies</param>
        /// <param name="lineString">string of the line where the command lies</param>
        public ValueTypeCommand(int id, int index, string name, int line, string lineString) : base(id, index, name, line)
        {
            this.lineString = lineString;
        }
    }
}
