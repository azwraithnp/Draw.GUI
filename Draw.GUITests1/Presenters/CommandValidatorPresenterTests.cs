using Microsoft.VisualStudio.TestTools.UnitTesting;
using Draw.GUIMVP.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Draw.GUI;
using System.IO;
using Draw.GUI.Models.Counters;

namespace Draw.GUIMVP.Presenters.Tests
{

    /// <summary>
    /// creates a test class for CommandValidatorPresenter class
    /// </summary>
    [TestClass()]
    public class CommandValidatorPresenterTests
    {
        int errorCount = 0;

        /// <summary>
        /// creates a test method to check whether the keywords are being parsed properly from the json file
        /// </summary>
        [TestMethod()]
        public void parseKeyWordsTest()
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
                
            GeneratedLists.Operators.AddRange(jsonArrayOperators.Cast<string>().ToArray());

            dynamic[] jsonArrayValueTypes = jsonParsed.ValueTypes;

            GeneratedLists.acceptedWords.AddRange(jsonArrayValueTypes.Cast<string>().ToArray());

            GeneratedLists.valueTypeCommands.AddRange(jsonArrayValueTypes.Cast<string>().ToArray());

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

            dynamic[] jsonArrayFourParameter = jsonParsed.FourParameterCommands;

            GeneratedLists.FourParameterCommands.AddRange(jsonArrayFourParameter.Cast<string>().ToArray());

            dynamic[] jsonArraySingleParameter = jsonParsed.SingleParameterCommands;

            GeneratedLists.SingleParameterCommands.AddRange(jsonArraySingleParameter.Cast<string>().ToArray());

            dynamic[] jsonArrayBlockCommands = jsonParsed.BlockCommands;

            GeneratedLists.BlockCommands.AddRange(jsonArrayBlockCommands.Cast<string>().ToArray());

            GeneratedLists.ToLower();

            Assert.AreEqual(34, GeneratedLists.acceptedWords.Count);
            Assert.AreEqual(8, GeneratedLists.BlockCommands.Count);
            Assert.AreEqual(12, GeneratedLists.valueTypeCommands.Count);
            Assert.AreEqual(1, GeneratedLists.SingleParameterCommands.Count);
            Assert.AreEqual(4, GeneratedLists.FourParameterCommands.Count);
            Assert.AreEqual(1, GeneratedLists.TwoParameterCommands.Count);
        }

        /// <summary>
        /// creates a test method to check if multiple commands are entered in the same line
        /// </summary>
        [TestMethod()]
        public void checkForMultipleCommandsTest()
        {
            int wordsCount = 0;
            string[] wordsInLine = { "if", "loop"};

            foreach (string word in wordsInLine)
            {
                if (word.Equals(""))
                    continue;

                foreach (string acceptedWord in GeneratedLists.acceptedWords)
                {
                    if (word.Equals(acceptedWord))
                    {
                        wordsCount++;
                    }
                }
            }

            if (wordsCount > 1)
            {
                foreach (string word in wordsInLine)
                {
                    if (word.Equals(""))
                        continue;

                    foreach (string acceptedWord in GeneratedLists.acceptedWords)
                    {
                        if (word.Equals(acceptedWord))
                        {
                            //TODO Filename
                            errorCount++;
                        }
                    }
                }
            }

            Assert.AreEqual(2, errorCount);

        }
        
        /// <summary>
        /// creates a test method to check whether the validation for the parameters is working properly
        /// </summary>
        [TestMethod()]
        public void checkforParamsSplitTest()
        {
            bool valid = true;
            string message = "";

            string[] paramsPart = { "100", "num", "ab"};

            Variable vr = new Variable("num", "Number", 0, "20");
            Variable vr2 = new Variable("ab", "Number", 1, "100");

            GeneratedLists.variables.Add(vr);
            GeneratedLists.variables.Add(vr2);

            foreach (string paramsPartWord in paramsPart)
            {
                if (paramsPartWord.Equals(""))
                {
                    valid = false;
                    message = " Invalid parametes. Empty value found in between the statement";
                }
                else
                {
                    if (!int.TryParse(paramsPartWord, out int pp))
                    {
                        valid = false;
                        message = "Invalid parameters. Couldn't find the variable '" + paramsPartWord + "' declared in the context";
                        foreach (Variable var in GeneratedLists.variables)
                        {
                            if (paramsPartWord.Equals(var.Name))
                                valid = true;
                        }
                    }
                }
            }

            Assert.IsTrue(valid);
            if(!valid)
            {
                StringAssert.Equals(message, "Invalid parameters. Couldn't find the variable 'num2' declared in the context");
            }
            
        }
        
        /// <summary>
        /// creates a method to check whether the index finding mechanism for a word is working properly
        /// </summary>
        [TestMethod()]
        public void checkErrorPosTest()
        {
            int wordPos = 0;

            string word = "abc";

            string code = "number abc=3";

            for (int i = 0; i < word.Length; i++)
            {
                wordPos = code.IndexOf(word, 0);
            }

            Assert.AreEqual(7, wordPos);
            
        }

        /// <summary>
        /// creates a method to check whether the parsed keywords are all converted to lower case or not
        /// </summary>
        [TestMethod]
        public void checkLowerCase()
        {
            if(GeneratedLists.acceptedWords.All(x => x.All(char.IsUpper)))
            {
                Assert.Fail();
            }
            
        }
    }
}