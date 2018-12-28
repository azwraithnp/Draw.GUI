using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class GeneratedLists
    {
        public static List<string> acceptedWords = new List<string>();
        public static List<string> BlockCommands = new List<string>();
        public static List<string> TwoParameterCommands = new List<string>();
        public static List<string> ThreeParameterCommands = new List<string>();

        public static List<ErrorMessage> errorMessages = new List<ErrorMessage>();

        public static void clearAll()
        {
            acceptedWords.Clear();
            BlockCommands.Clear();
            TwoParameterCommands.Clear();
            ThreeParameterCommands.Clear();
        }

    }
}
