using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    /// <summary>
    /// creates a model abstract class for the syntax commands,
    /// acts as a parent class which its subtypes can inherit from
    /// </summary>
    public abstract class SyntaxCommand
    {
        public int id;
        public int index;
        public int line;
        public string name;

        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="id">id of the syntax command</param>
        /// <param name="index">index where the syntax command lies</param>
        /// <param name="name">name of the syntax command</param>
        /// <param name="line">line where the syntax command lies</param>
        public SyntaxCommand(int id, int index, string name, int line)
        {
            this.id = id;
            this.index = index;
            this.name = name;
            this.line = line;
        }
        
    }
}
