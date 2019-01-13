using Microsoft.VisualStudio.TestTools.UnitTesting;
using Draw.GUI.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Draw.GUI.Models.Counters;

namespace Draw.GUI.Presenters.Tests
{
    /// <summary>
    /// creates a test class for CommandParserPresenter class
    /// </summary>
    [TestClass()]
    public class CommandParserPresenterTests
    {
        List<string> comments = new List<string>();
        List<BlockCommand> loopList = new List<BlockCommand>();
        List<BlockCommand> ifList = new List<BlockCommand>();
        List<BlockCommand> elseList = new List<BlockCommand>();

        /// <summary>
        /// creates a test method to check whether blocks of comments are parsed properly
        /// </summary>
        [TestMethod()]
        public void removeCommentsTest()
        {
            string code = "~-- hello this" + Environment.NewLine + "is a line --~";

            BlockCommand cmd = new BlockCommand(99, 0, "~--", 0)
            {
                mapTo = "--~",
                mapToIndex = 24
            };
            GeneratedLists.blockComsInCode.Add(cmd);

            foreach (BlockCommand block in GeneratedLists.blockComsInCode)
            {
                if (block.name.Equals(GeneratedLists.acceptedWords[1]))
                {
                    int firstIndex = block.index;
                    int secondIndex = block.mapToIndex;

                    string subString = code.Substring(firstIndex, (secondIndex + block.mapTo.Length) - firstIndex);

                    comments = subString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                else if (block.name.Equals(GeneratedLists.BlockCommands[0].ToLower()))
                {
                    loopList.Add(block);
                }
                else if (block.name.Equals(GeneratedLists.BlockCommands[2].ToLower()))
                {
                    ifList.Add(block);
                }
                else if (block.name.Equals(GeneratedLists.BlockCommands[4].ToLower()))
                {
                    elseList.Add(block);
                }
            }

            Assert.AreEqual(2, comments.Count); 
            StringAssert.Equals("~-- hello this", comments[0]);
            StringAssert.Equals("is a line --~", comments[1]);
        }

        /// <summary>
        /// creates a test method to check whether parameters of a command are returned properly
        /// </summary>
        [TestMethod()]
        public void checkParamsTest()
        {
            string lineString = "rectangle 200,num";

            Variable var = new Variable("zxc", "Number", 0, "40");

            string[] words = lineString.Split(new[] { ' ' }, 2);

            var restWords = words[1];

            restWords = restWords.Replace(" ", string.Empty);

            string[] paramsPart = restWords.Split(',');

            List<string> paramsReturn = new List<string>();

            foreach (string paramsWord in paramsPart)
            {
                if (!int.TryParse(paramsWord, out int num))
                {
                    foreach (Variable vr in GeneratedLists.variables)
                    {
                        if (paramsWord.Equals(vr.Name))
                        {
                            paramsReturn.Add(vr.Value);
                        }


                    }
                }
                else
                {
                    paramsReturn.Add(paramsWord);
                }
            }

            StringAssert.Equals(200, paramsReturn[0]);
            StringAssert.Equals(40, paramsReturn[1]);
        }
        
    }
}