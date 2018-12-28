using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class Counters
    {
        public static int errorCounter = 0;
        public static int indexStart = 0;
        public static int indexStartFORPos = 0;
        public static int indexStartFORCV = 0;
        public static bool valid = false;
        public static string initialCode = "";

        public static IDGenerator blockGenerator = new IDGenerator();
        public static IDGenerator commentGenerator = new IDGenerator();
    }
}
