using Draw.GUI;
using Draw.GUI.Models;
using Draw.GUIMVP.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUIMVP.Presenters
{
    public class CommandParserPresenter
    {
        ICodeView codeView;
        string code;

        List<BlockCommand> blockList = new List<BlockCommand>();
        
        public CommandParserPresenter(ICodeView codeView)
        {
            this.codeView = codeView;
            this.code = codeView.editorCode;

            codeView.ListView.Items.Clear();
            GeneratedLists.errorMessages.Clear();

            if (!this.code.Equals(Counters.initialCode))
            {
                Counters.initialCode = code;
                ErrorPOSCounters.indexStartFORPos = 0;
                BlockCounters.indexStart = 0;
                BlockCounters.indexSecondStart = 0;
            }

            parseKeyWords();

            validateCode();

            foreach (ErrorMessage msg in GeneratedLists.errorMessages)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { "DG" + msg.index, msg.message, "" + msg.line, msg.fileName });
                codeView.ListView.Items.Add(listViewItem);
            }
        }

        public void validateCode()
        {
            int lineNumber = 1;
            ErrorPOSCounters.indexStartFORPos = 0;

            foreach (string lineString in code.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] wordsinLine = lineString.Split(' ');
                if (lineString[0].Equals(GeneratedLists.acceptedWords[0][0]))
                {
                    lineNumber++;
                    ErrorPOSCounters.indexStartFORPos = ErrorPOSCounters.indexStartFORPos + lineString.Length;
                    continue;
                }

                checkForMultipleCommands(wordsinLine, lineNumber);

                foreach (string word in wordsinLine)
                {
                    if (word.Equals(""))
                        continue;

                    Counters.valid = false;
                    foreach (string acceptedWord in GeneratedLists.acceptedWords)
                    {
                        if (word.Equals(acceptedWord))
                        {
                            Counters.valid = true;
                            if (isBlockCommand(word))
                                checkBlockValidity(word, lineNumber);
                        }
                    }
                    if (!Counters.valid)
                    {
                        //TODO Fix the error messages
                        InvalidSyntaxErrorMessage msg = new InvalidSyntaxErrorMessage(checkErrorPos(word), word, "Untitled", lineNumber);
                        msg.generateErrorMsg();
                        GeneratedLists.errorMessages.Add(msg);
                    }
                    
                }

                ErrorPOSCounters.indexStartFORPos = ErrorPOSCounters.indexStartFORPos + lineString.Length;

                lineNumber++;
            }

            checkBlocknCommentValidity();
            checkInvalidSyntax();

        }

        public void checkForMultipleCommands(string[] wordsInLine, int line)
        {
            int wordsCount = 0;

            foreach (string word in wordsInLine)
            {
                if (word.Equals(""))
                    continue;

                foreach (string acceptedWord in GeneratedLists.acceptedWords)
                {
                    if(word.Equals(acceptedWord))
                    {
                        wordsCount++;
                    }
                }
            }

            if(wordsCount > 1)
            {
                foreach (string word in wordsInLine)
                {
                    if (word.Equals(""))
                        continue;

                    foreach (string acceptedWord in GeneratedLists.acceptedWords)
                    {
                        if(word.Equals(acceptedWord))
                        {
                            //TODO Filename
                            MultipleCommandsErrorMessage errorMessage = new MultipleCommandsErrorMessage(checkErrorPos(word), word, "Untitled", line);
                            errorMessage.generateErrorMsg();
                            GeneratedLists.errorMessages.Add(errorMessage);
                        }
                    }
                }
            }
        }

        public void checkInvalidSyntax()
        {
            List<ErrorMessage> tempList = new List<ErrorMessage>();

            foreach (ErrorMessage message in GeneratedLists.errorMessages)
            {
                if(message.GetType().ToString().Equals("Draw.GUI.InvalidSyntaxErrorMessage"))
                {
                    foreach (BlockCommand block in blockList)
                    {
                        if (block.mapTo != null)
                        {
                            if(message.index > block.index && message.index < block.mapToIndex)
                            {
                                tempList.Add(message);
                                break;
                            }
                        }
                    }
                }
            }

            GeneratedLists.errorMessages = GeneratedLists.errorMessages.Except(tempList).ToList();
        }

        public void checkBlocknCommentValidity()
        {
            foreach (BlockCommand block in blockList)
            {
                Console.WriteLine(block.name + " : " + block.mapTo);
                try
                {
                    string mapTo = block.mapTo;
                    if (mapTo == null) throw new NullReferenceException();
                }
                catch (NullReferenceException e)
                {
                    string nextWord = "";

                    if (block.name.Equals(GeneratedLists.acceptedWords[1]) || block.name.Equals(GeneratedLists.acceptedWords[2]))
                    {
                        int pos = Array.IndexOf(GeneratedLists.acceptedWords.ToArray(), block.name);
                        nextWord = pos == 1 ? GeneratedLists.acceptedWords[2] : GeneratedLists.acceptedWords[1];

                        CommentCommandErrorMessage commentMsg = new CommentCommandErrorMessage(block.index, block.name, nextWord, "Untitled", block.line);
                        commentMsg.generateErrorMsg();
                        GeneratedLists.errorMessages.Add(commentMsg);

                        continue;
                    }

                    for (int i = 0; i < GeneratedLists.BlockCommands.Count; i++)
                    {
                        if (block.name.Equals(GeneratedLists.BlockCommands[i]))
                            if (i % 2 != 0)
                            {
                                nextWord = GeneratedLists.BlockCommands[i - 1];
                            }
                            else
                            {
                                nextWord = GeneratedLists.BlockCommands[i + 1];
                            }
                    }
                    BlockCommandErrorMessage msg = new BlockCommandErrorMessage(block.index, block.name, nextWord, "Untitled", block.line);
                    msg.generateErrorMsg();
                    GeneratedLists.errorMessages.Add(msg);
                }
            }
        }

        public bool isBlockCommand(string word)
        {
            bool isVal = false;

            foreach (string blockWord in GeneratedLists.BlockCommands)
            {
                if (word.Equals(blockWord))
                    isVal = true;
            }
            return isVal;
        }

        

        public void checkBlockValidity(string word, int line)
        {
            BlockCommand block = null;

            string nextWord = "";
            int firstIndex = 0, secondIndex = 0;

            for (int i = 0; i < GeneratedLists.BlockCommands.Count; i++)
            {
                if (word.Equals(GeneratedLists.BlockCommands[i]))
                    if (i % 2 == 0)
                    {
                        nextWord = GeneratedLists.BlockCommands[i + 1];
                        firstIndex = code.IndexOf(word, BlockCounters.indexSecondStart);
                        secondIndex = code.IndexOf(nextWord, BlockCounters.indexStart);

                        if (firstIndex < secondIndex)
                        {
                            block = new BlockCommand(Counters.blockGenerator.Id, firstIndex, word, line)
                            {
                                mapTo = nextWord,
                                mapToIndex = secondIndex
                            };
                        }
                        else
                        {
                            block = new BlockCommand(Counters.blockGenerator.Id, firstIndex, word, line);
                        }

                        blockList.Add(block);
                        
                        BlockCounters.indexStart = secondIndex + nextWord.Length;
                        BlockCounters.indexSecondStart = firstIndex + word.Length;
                    }
                    else
                    {
                        firstIndex = code.IndexOf(word, BlockCounters.indexSecondStart);
                        bool exists = false;

                        foreach(BlockCommand blockCommand in blockList)
                        {
                            int pos = Array.IndexOf(GeneratedLists.BlockCommands.ToArray(), blockCommand.name);
                            if(pos % 2 == 0)
                            {
                                if(blockCommand.mapToIndex == firstIndex)
                                {
                                    block = new BlockCommand(Counters.blockGenerator.Id, firstIndex, word, line)
                                    {
                                        mapTo = blockCommand.name,
                                        mapToIndex = blockCommand.index
                                    };
                                    exists = true;
                                }
                            }
                        }

                        if(!exists)
                        {
                            block = new BlockCommand(Counters.blockGenerator.Id, firstIndex, word, line);
                            
                        }

                        blockList.Add(block);

                        BlockCounters.indexSecondStart = firstIndex + word.Length;
                    }
                    
            }


            Counters.blockGenerator.increment();
        }

        public int checkErrorPos(string word)
        {
            int wordPos = 0;

            for (int i = 0; i < word.Length; i++)
            {
                wordPos = code.IndexOf(word, ErrorPOSCounters.indexStartFORPos);
            }
            
            return wordPos;
        }

        public void parseKeyWords()
        {
            GeneratedLists.clearAll();

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
