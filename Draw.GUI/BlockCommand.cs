using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class BlockCommand
    {
        private int id;
        private int index;
        private string name;
        private BlockCommand mapTo;

        public BlockCommand(int id, int index, string name, BlockCommand mapTo)
        {
            this.Id = id;
            this.Index = index;
            this.Name = name;
            this.MapTo = mapTo;
        }

        public int Id { get => id; set => id = value; }

        public int Index { get => index; set => index = value; }

        public string Name { get => name; set => name = value; }

        internal BlockCommand MapTo { get => mapTo; set => mapTo = value; }
    }
}
