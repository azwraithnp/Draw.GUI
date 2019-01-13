using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI.Models.Counters
{
    /// <summary>
    /// creates a model class for the variables declared by user in the code
    /// </summary>
    public class Variable
    {
        string name;
        string type;
        int line;
        string value;

        /// <summary>
        /// creates a constructor for the class that initializes its instance variables
        /// </summary>
        /// <param name="name">name of the variable</param>
        /// <param name="type">type of the variable</param>
        /// <param name="line">line number where the variable exists</param>
        /// <param name="value">value of the variable</param>
        public Variable(string name, string type, int line, string value)
        {
            this.Name = name;
            this.Type = type;
            this.Line = line;
            this.Value = value;
        }

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public int Line { get => line; set => line = value; }
        public string Value { get => value; set => this.value = value; }
    }
}
