using Draw.GUI.Models.Counters;
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
        public static List<string> valueTypeCommands = new List<string>();
        public static List<string> BlockCommands = new List<string>();
        public static List<string> TwoParameterCommands = new List<string>();
        public static List<string> ThreeParameterCommands = new List<string>();
        public static List<string> SingleParameterCommands = new List<string>();
        public static List<string> Operators = new List<string>();

        public static List<ErrorMessage> errorMessages = new List<ErrorMessage>();

        public static List<Variable> variables = new List<Variable>();

        public static void clearAll()
        {
            acceptedWords.Clear();
            valueTypeCommands.Clear();
            BlockCommands.Clear();
            TwoParameterCommands.Clear();
            ThreeParameterCommands.Clear();
            variables.Clear();
            SingleParameterCommands.Clear();
            Operators.Clear();
        }

        public static void ToLower()
        {
            acceptedWords = acceptedWords.ConvertAll(d => d.ToLower());

            valueTypeCommands = valueTypeCommands.ConvertAll(d => d.ToLower());

            TwoParameterCommands = TwoParameterCommands.ConvertAll(d => d.ToLower());

            ThreeParameterCommands = ThreeParameterCommands.ConvertAll(d => d.ToLower());

            SingleParameterCommands = SingleParameterCommands.ConvertAll(d => d.ToLower());

            Operators = Operators.ConvertAll(d => d.ToLower());

            BlockCommands = BlockCommands.ConvertAll(d => d.ToLower());

        }

    }
}
