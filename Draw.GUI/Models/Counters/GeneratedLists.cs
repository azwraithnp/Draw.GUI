using Draw.GUI.Models.Counters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    /// <summary>
    /// creates a model class to store the lists used in validation and parsing of the code
    /// </summary>
    public class GeneratedLists
    {
        public static List<string> acceptedWords = new List<string>();
        public static List<string> valueTypeCommands = new List<string>();
        public static List<string> BlockCommands = new List<string>();
        public static List<string> TwoParameterCommands = new List<string>();
        public static List<string> FourParameterCommands = new List<string>();
        public static List<string> SingleParameterCommands = new List<string>();
        public static List<string> Operators = new List<string>();
        public static Dictionary<Variable, int> repeatDictionary = new Dictionary<Variable, int>();

        public static List<ErrorMessage> errorMessages = new List<ErrorMessage>();

        public static List<Variable> variables = new List<Variable>();

        public static List<BlockCommand> blockComsInCode = new List<BlockCommand>();

        public static bool goodToRun = true;

        /// <summary>
        /// clears the lists and variable(s) to bring them in a reset position
        /// </summary>
        public static void clearAll()
        {
            goodToRun = false;
            acceptedWords.Clear();
            valueTypeCommands.Clear();
            BlockCommands.Clear();
            TwoParameterCommands.Clear();
            FourParameterCommands.Clear();
            variables.Clear();
            SingleParameterCommands.Clear();
            Operators.Clear();
            blockComsInCode.Clear();
            
        }

        /// <summary>
        /// converts the data in the lists to lowercase so that its easier during validation and parsing
        /// </summary>
        public static void ToLower()
        {
            acceptedWords = acceptedWords.ConvertAll(d => d.ToLower());

            valueTypeCommands = valueTypeCommands.ConvertAll(d => d.ToLower());

            TwoParameterCommands = TwoParameterCommands.ConvertAll(d => d.ToLower());

            FourParameterCommands = FourParameterCommands.ConvertAll(d => d.ToLower());

            SingleParameterCommands = SingleParameterCommands.ConvertAll(d => d.ToLower());

            Operators = Operators.ConvertAll(d => d.ToLower());

            BlockCommands = BlockCommands.ConvertAll(d => d.ToLower());

        }

    }
}
