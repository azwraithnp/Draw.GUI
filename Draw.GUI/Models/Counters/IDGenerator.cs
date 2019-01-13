using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    /// <summary>
    /// creates a model class to generate ids for block and value type commands
    /// </summary>
    class IDGenerator
    {
        private int id;

        public IDGenerator()
        {

        }

        public int Id { get => id; set => id = value; }

        /// <summary>
        /// increments the id on each iteration
        /// </summary>
        public void increment()
        {
            id++;
        }
    }
}
