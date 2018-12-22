﻿using System;
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
        
        List<ErrorMessage> errorMessages = new List<ErrorMessage>();

        List<BlockCommand> blockList = new List<BlockCommand>();
        
        public CommandParser(string code)
        {
            this.code = code;
            parseKeyWords();
            validateCode();

            Console.WriteLine(errorMessages.Count);
            
        }
        
        public void validateCode()
        {
            foreach (string myString in code.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] wordsinLIne = myString.Split(' ');
                if (myString[0].Equals(GeneratedLists.acceptedWords[0][0]))
                    continue;

                foreach (string word in wordsinLIne)
                {
                    Counters.valid = false;
                    foreach (string acceptedWord in GeneratedLists.acceptedWords)
                    {
                        if (word.Equals(acceptedWord))
                        {
                            Counters.valid = true;
                            if (isBlockCommand(word))
                                checkBlockValidity(word);
                        }
                    }
                    if (!Counters.valid)
                    {
                        InvalidSyntaxErrorMessage msg = new InvalidSyntaxErrorMessage(checkErrorPos(word), word);
                        errorMessages.Add(msg);
                    }
                }
            }

            foreach (BlockCommand block in blockList)
            {
                try
                {
                    string mapTo = block.mapTo;
                }
                catch (NullReferenceException e)
                {
                    string nextWord = "";

                    for (int i = 0; i < GeneratedLists.BlockCommands.Count; i++)
                    {
                        if (block.name.Equals(GeneratedLists.BlockCommands[i]))
                            if (i % 2 != 0)
                            {
                                nextWord = GeneratedLists.BlockCommands[i + 1];
                            }
                            else
                            {
                                nextWord = GeneratedLists.BlockCommands[i - 1];
                            }
                    }
                    BlockCommandErrorMessage msg = new BlockCommandErrorMessage(block.index, block.name, nextWord);
                    errorMessages.Add(msg);
                }
            }
        }

        public bool isBlockCommand(string word)
        {
            bool isVal = false;
             
            foreach(string blockWord in GeneratedLists.BlockCommands)
            {
                if (word.Equals(blockWord))
                    isVal = true;
            }
            return isVal;
        }

        //TODO Comment validation
        public bool checkCommentsValidity()
        {
            
            return false;
        }

        public void checkBlockValidity(string word)
        {
            BlockCommand block;
            Counters.blockCounter++;
            
            string nextWord = "";
            int firstIndex = 0, secondIndex = 0;

            for(int i=0;i< GeneratedLists.BlockCommands.Count;i++)
            {
                if (word.Equals(GeneratedLists.BlockCommands[i]))
                    if (i % 2 != 0)
                    {
                        nextWord = GeneratedLists.BlockCommands[i + 1];
                        firstIndex = code.IndexOf(word, Counters.indexStart);
                        secondIndex = code.IndexOf(nextWord, Counters.indexStart);

                        if (firstIndex < secondIndex)
                        {
                            block = new BlockCommand(Counters.blockCounter, firstIndex, word)
                            {
                                mapTo = nextWord
                            };
                        }
                        else
                        {
                            block = new BlockCommand(Counters.blockCounter, firstIndex, word);
                        }

                        blockList.Add(block);
                    }
                    else
                    {
                        nextWord = GeneratedLists.BlockCommands[i - 1];
                        firstIndex = code.IndexOf(word, Counters.indexStart);
                        secondIndex = code.IndexOf(nextWord, Counters.indexStart);

                        if (firstIndex > secondIndex)
                        {
                            block = new BlockCommand(Counters.blockCounter, firstIndex, word)
                            {
                                mapTo = nextWord
                            };
                        }
                        else
                        {
                            block = new BlockCommand(Counters.blockCounter, firstIndex, word);
                        }

                        blockList.Add(block);
                    }
                        
            }

            Counters.indexStart = secondIndex + nextWord.Length;
            
            Counters.blockCounter++;

            //TODO BlockCommand Array 
            //TODO ErrorMessage
            
        }

        public int checkErrorPos(string word)
        {
            int wordPos = 0;

            for(int i = 0;i<word.Length;i++)
            {
                wordPos = code.IndexOf(word, Counters.indexStartFORPos);
            }

            Counters.indexStartFORPos = wordPos + word.Length;
            
            return 0;
        }

        public void parseKeyWords()
        {
            StreamReader strm = new StreamReader("keywords.json");
            string jsonString = strm.ReadToEnd();

            dynamic jsonParsed = System.Web.Helpers.Json.Decode(jsonString);

            GeneratedLists.acceptedWords.Add(jsonParsed.LineComment);
            GeneratedLists.acceptedWords.Add(jsonParsed.MultilineCommentStart);
            GeneratedLists.acceptedWords.Add(jsonParsed.MultilineCommentEnd);

            dynamic[] jsonArrayOperators = jsonParsed.Operators;

            GeneratedLists.acceptedWords.AddRange(jsonArrayOperators.Cast<string>().ToArray());

            dynamic[] jsonArrayValueTypes = jsonParsed.ValueTypes;

            GeneratedLists.acceptedWords.AddRange(jsonArrayValueTypes.Cast<string>().ToArray());

            dynamic[] jsonArraySelection = jsonParsed.SelectionStatements;

            GeneratedLists.acceptedWords.AddRange(jsonArraySelection.Cast<string>().ToArray());

            dynamic[] jsonArrayIteration = jsonParsed.IterationStatements;

            GeneratedLists.acceptedWords.AddRange(jsonArrayIteration.Cast<string>().ToArray());

            dynamic[] jsonArrayError = jsonParsed.ErrorWords;

            GeneratedLists.acceptedWords.AddRange(jsonArrayError.Cast<string>().ToArray());

            dynamic[] jsonArrayWarning = jsonParsed.WarningWords;

            GeneratedLists.acceptedWords.AddRange(jsonArrayWarning.Cast<string>().ToArray());

            dynamic[] jsonArrayTwoParameter = jsonParsed.TwoParameterCommands;

            GeneratedLists.TwoParameterCommands.AddRange(jsonArrayTwoParameter.Cast<string>().ToArray());

            dynamic[] jsonArrayThreeParameter = jsonParsed.ThreeParameterCommands;

            GeneratedLists.ThreeParameterCommands.AddRange(jsonArrayThreeParameter.Cast<string>().ToArray());

            dynamic[] jsonArrayBlockCommands = jsonParsed.BlockCommands;

            GeneratedLists.BlockCommands.AddRange(jsonArrayBlockCommands.Cast<string>().ToArray());

        }
    }
}
