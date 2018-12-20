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

        List<BlockCommand> blockList = new List<BlockCommand>();

        //TODO modify to new error messages
        List<ErrorMessage> errors = new List<ErrorMessage>();

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
                if (myString[0].Equals(acceptedWords[0]))
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

        public bool checkCommentsValidity()
        {
            
            return false;
        }

        public bool checkBlockValidity(string word)
        {
            BlockCommand block;
            Counters.blockCounter++;
            
            string nextWord = "";
            int firstIndex = 0, secondIndex = 0;

            //TODO Merge %2 logic for first and second index right here 
            for(int i=0;i<BlockCommands.Count;i++)
            {
                if (word.Equals(BlockCommands[i]))
                    if (i % 2 != 0)
                        nextWord = BlockCommands[i + 1];
                    else
                        nextWord = BlockCommands[i - 1];
            }

            
            firstIndex = code.IndexOf(word, Counters.indexStart);
            secondIndex = code.IndexOf(nextWord, Counters.indexStart);

            if (firstIndex < secondIndex)
            {
                    block = new BlockCommand(Counters.blockCounter, firstIndex, word);
                    block.mapTo = nextWord;
            }
            else
            {
                    block = new BlockCommand(Counters.blockCounter, firstIndex, word);
            }

            Counters.indexStart = secondIndex + nextWord.Length;
            
            Counters.blockCounter++;

            blockList.Add(block);
            //TODO BlockCommand Array 
            //TODO ErrorMessage

            return false;
        }

        public int checkErrorPos(string word)
        {
            int wordPos = 0;

            for(int i = 0;i<word.Length;i++)
            {
                wordPos = code.IndexOf(word, wordPos);
            }

            Counters.indexStartFORPos = wordPos + word.Length;
            
            return 0;
        }


    }
}
