using Draw.GUI.Models.Counters;
using Draw.GUI.Models.Shape;
using Draw.GUIMVP.Models;
using Draw.GUIMVP.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI.Presenters
{
    public class CommandParserPresenter
    {
        ICodeView codeView;
        string code;

        int Pointx, Pointy;
        Pen refPen;
        Color themeColor;

        List<CommentCommand> commentList = new List<CommentCommand>();

        public CommandParserPresenter(ICodeView codeView)
        {
            this.codeView = codeView;
            this.code = codeView.editorCode.ToLower();

            UserInfo user = new UserInfo();
            if(user.Theme.Equals("dark"))
            {
                themeColor = Colors.themeLightColor;
            }
            else
            {
                themeColor = Colors.themeDarkColor;
            }


            
            removeComments();
            

        }
        

        public void parseCode()
        {
            foreach (string lineString in code.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (lineString[0].Equals(GeneratedLists.acceptedWords[0][0]))
                    continue;

                var matchWord = "";

                if (GeneratedLists.valueTypeCommands.Any(x => lineString.StartsWith(x)))
                {
                    matchWord = GeneratedLists.valueTypeCommands.Single(x => lineString.StartsWith(x));
                    valueTypeParse(lineString, matchWord);
                }
                    

                else if (GeneratedLists.BlockCommands.Any(x => lineString.StartsWith(x)))
                {
                    matchWord = GeneratedLists.BlockCommands.Single(x => lineString.StartsWith(x));
                    blockParse(matchWord);
                }
                    

            }
        }

       

        public void valueTypeParse(string lineString, string word)
        {
            ShapeFactory shapeFactory = new ShapeFactory();

            switch (word)
            {
                case "pen":

                    string[] words = lineString.Split(' ');

                    refPen = new Pen(Color.FromName(words[1]));

                    break;

                case "drawto":
                    
                    (Pointx, Pointy) = checkParams(lineString);

                    codeView.canvas.DrawLine(refPen, Pointx, Pointx, Pointy, Pointy);
                    
                    break;

                case "moveto":

                    (Pointx, Pointy) = checkParams(lineString);

                    break;

                case "rectangle":

                    (int height, int width) = checkParams(lineString);
                    Shape rect = shapeFactory.getRectangleShape(Pointx, Pointy, height, width, refPen, codeView.canvas);
                    rect.draw();

                    break;

                case "triangle":
                    break;

                case "polygon":
                    break;

                case "circle":
                    break;

                case "number":
                    break;

                case "repeat":
                    break;


            }
        }

        public void blockParse(string word)
        {
            switch (word)
            {
                case "loop":
                    break;

                    
            }

        }

        public (int x, int y) checkParams(string lineString)
        {

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
                        break;
                    }
                }
                else
                {
                    paramsReturn.Add(paramsWord);
                }
            }

            return (int.Parse(paramsReturn[0]), int.Parse(paramsReturn[1]));

        }

        public void removeComments()
        {

            List<string> comments = new List<string>();

            foreach (BlockCommand block in GeneratedLists.blockComsInCode)
            {
                if(block.name.Equals(GeneratedLists.acceptedWords[1]))
                {
                    Console.WriteLine(code.Length);

                    int firstIndex = block.index;
                    int secondIndex = block.mapToIndex;
                    
                    string subString = code.Substring(firstIndex, (secondIndex + block.mapTo.Length) - firstIndex);
                   
                    comments.Add(subString);
                }
            }
            
            foreach (string commentLine in comments)
            {
                code = code.Replace(commentLine, string.Empty);
            }

            
        }

    }
}
