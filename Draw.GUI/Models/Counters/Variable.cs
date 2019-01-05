using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI.Models.Counters
{
    class Variable
    {
        string name;
        string type;
        int line;
        string value;

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
