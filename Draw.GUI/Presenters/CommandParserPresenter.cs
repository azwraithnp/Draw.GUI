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

        Point point1, point2;
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
            string[] words;

            switch (word)
            {
                case "pen":

                    words = lineString.Split(' ');

                    refPen = new Pen(Color.FromName(words[1]));

                    break;

                case "drawto":
                    
                    (point1, point2) = checkParamsForPoint(lineString);
                    
                    codeView.canvas.DrawLine(refPen, point1, point2);
                    
                    break;

                case "moveto":

                    (point1, point2) = checkParamsForPoint(lineString);

                    break;

                case "rectangle":

                    int[] paramsInt = checkParams(lineString);

                    Console.WriteLine(paramsInt.Length);

                    Shape rect = shapeFactory.getRectangleShape(point1, point2, paramsInt[0], paramsInt[1], refPen, codeView.canvas);
                    rect.draw();

                    break;

                case "triangle":

                    Point[] points = checkParamsForPolygon(lineString);

                    Shape triangle = shapeFactory.getTriangleShape(points[0], points[1], points[2], refPen, codeView.canvas);
                    triangle.draw();

                    break;

                case "polygon":

                    Point[] polygonPoints = checkParamsForPolygon(lineString);

                    Point firstPoint = polygonPoints[0];
                    Point secondPoint = polygonPoints[1];

                    List<Point> polygonList = polygonPoints.ToList();
                    polygonList.Remove(firstPoint);
                    polygonList.Remove(secondPoint);
                    
                    Shape polygon = shapeFactory.getPolygonShape(firstPoint, secondPoint, polygonList.ToArray(), refPen, codeView.canvas) ;
                    polygon.draw();

                    break;

                case "circle":

                    words = lineString.Split(' ');
                    
                    if(!int.TryParse(words[1], out int radius))
                    {
                        foreach (Variable vr in GeneratedLists.variables)
                        {
                            if (vr.Name.Equals(words[1]))
                                radius = int.Parse(vr.Value);
                        }
                    }
                    
                    Shape circle = shapeFactory.getCircleShape(point1, point2, radius, refPen, codeView.canvas);
                    circle.draw();

                    break;
                    
                case "repeat":

                    string[] repeatWords = lineString.Split(' ');

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

        public int[] checkParams(string lineString)
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

                        
                    }
                }
                else
                {
                    paramsReturn.Add(paramsWord);
                }
            }

            Console.WriteLine(paramsReturn.Count);

            return paramsReturn.Select(x => int.Parse(x)).ToArray();
            
        }

        public (Point firstPoint, Point secondPoint) checkParamsForPoint(string lineString)
        {
            Point firstPoint, secondPoint;

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

            firstPoint = new Point(int.Parse(paramsReturn[0]), int.Parse(paramsReturn[1]));
            secondPoint = new Point(int.Parse(paramsReturn[2]), int.Parse(paramsReturn[3]));

            return (firstPoint, secondPoint);

        }

        public Point[] checkParamsForPolygon(string lineString)
        {
            List<Point> points = new List<Point>();

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
;
            for(int i=0;i<paramsReturn.Count;i+=2)
            {
                points.Add(new Point(int.Parse(paramsReturn[i]), int.Parse(paramsReturn[i+1])));
            }

            return points.ToArray();
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
