using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class Counters
    {
        public static bool valid = false;
        public static string initialCode = "";
        public static bool showGrid = false;

        public static IDGenerator blockGenerator = new IDGenerator();
        public static IDGenerator valueTypeGenerator = new IDGenerator();
    }
}
