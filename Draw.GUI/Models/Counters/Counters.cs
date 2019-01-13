using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    /// <summary>
    /// creates a model class to store counters for different validations and properties used in the application
    /// </summary>
    class Counters
    {
        public static bool valid = false;
        public static string initialCode = "";
        public static bool showGrid = false;
        public static bool colorFill = false;
        public static bool textureFill = false;

        public static IDGenerator blockGenerator = new IDGenerator();
        public static IDGenerator valueTypeGenerator = new IDGenerator();
    }
}
