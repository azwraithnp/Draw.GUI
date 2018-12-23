using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class IDGenerator
    {
        private int id;

        public IDGenerator()
        {

        }

        public int Id { get => id; set => id = value; }

        public void increment()
        {
            id++;
        }
    }
}
