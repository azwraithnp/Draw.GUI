using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class CommandParser
    {
        private string code;
        List<string> acceptedWords = new List<string>();
        private bool valid = false;

        List<string> ErrorWords = new List<string>();
        List<string> BlockCommands = new List<string>();
        List<string> TwoParameterCommands = new List<string>();
        List<string> ThreeParameterCommands = new List<string>();


        public CommandParser(string code)
        {
            this.code = code;
            parseKeyWords();
            validateCode();

            Console.WriteLine(valid);
        }

        public void parseKeyWords()
        {
            StreamReader strm = new StreamReader("keywords.json");
            string jsonString = strm.ReadToEnd();

            dynamic jsonParsed = System.Web.Helpers.Json.Decode(jsonString);

            acceptedWords.Add(jsonParsed.LineComment);
            acceptedWords.Add(jsonParsed.MultilineCommentStart);
            acceptedWords.Add(jsonParsed.MultilineCommentEnd);

            dynamic[] jsonArrayOperators = jsonParsed.Operators;

            acceptedWords.AddRange(jsonArrayOperators.Cast<string>().ToArray());

            dynamic[] jsonArrayValueTypes = jsonParsed.ValueTypes;

            acceptedWords.AddRange(jsonArrayValueTypes.Cast<string>().ToArray());

            dynamic[] jsonArraySelection = jsonParsed.SelectionStatements;

            acceptedWords.AddRange(jsonArraySelection.Cast<string>().ToArray());

            dynamic[] jsonArrayIteration = jsonParsed.IterationStatements;

            acceptedWords.AddRange(jsonArrayIteration.Cast<string>().ToArray());

            dynamic[] jsonArrayError = jsonParsed.ErrorWords;

            acceptedWords.AddRange(jsonArrayError.Cast<string>().ToArray());

            dynamic[] jsonArrayWarning = jsonParsed.WarningWords;

            acceptedWords.AddRange(jsonArrayWarning.Cast<string>().ToArray());

            dynamic[] jsonArrayTwoParameter = jsonParsed.TwoParameterCommands;

            TwoParameterCommands.AddRange(jsonArrayTwoParameter.Cast<string>().ToArray());

            dynamic[] jsonArrayThreeParameter = jsonParsed.ThreeParameterCommands;

            ThreeParameterCommands.AddRange(jsonArrayThreeParameter.Cast<string>().ToArray());

            dynamic[] jsonArrayBlockCommands = jsonParsed.BlockCommands;

            BlockCommands.AddRange(jsonArrayBlockCommands.Cast<string>().ToArray());


            

            

        }

        public void validateCode()
        {
            foreach (string myString in code.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] wordsinLIne = myString.Split(' ');
                if (myString[0] == '!')
                    continue;

                foreach (string word in wordsinLIne)
                {
                    foreach (string acceptedWord in acceptedWords)
                    {
                        if (word.Equals(acceptedWord))
                            valid = true;
                        
                    }
                    if (!valid)
                        ErrorWords.Add(word);
                }
            }
        }

        public bool isBlockCommand(string word)
        {
            bool isVal = false;
            foreach(string blockWord in BlockCommands)
            {
                if (word.Equals(blockWord))
                    isVal = true;
            }
            return isVal;
        }

        public bool checkBlockValidity(string word)
        {
            string nextWord = "";

            for(int i=0;i<BlockCommands.Count;i++)
            {
                if (word.Equals(BlockCommands[i]))
                    nextWord = BlockCommands[i + 1];
            }


            return false;
        }


    }
}
