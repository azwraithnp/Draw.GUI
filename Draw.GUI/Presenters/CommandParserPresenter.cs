using Draw.GUI.Models.Counters;
using Draw.GUI.Models.Shape;
using Draw.GUIMVP.Models;
using Draw.GUIMVP.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUI.Presenters
{
    /// <summary>
    /// creates a presenter class to implement the business logic for parsing of the user written code in coding form
    /// </summary>
    public class CommandParserPresenter
    {
        ICodeView codeView;
        string code;

        Point point1, point2;
        Pen refPen;
        

        int drawtoCount = 0;

        int repeatCount = 0;
        int loopCount = 0;
        int ifCount = 0;
        int elseCount = 0;
        
        List<BlockCommand> loopList = new List<BlockCommand>();
        List<BlockCommand> ifList = new List<BlockCommand>();
        List<BlockCommand> elseList = new List<BlockCommand>();

        List<string> comments = new List<string>();
        List<string> blocks = new List<string>();

        bool ifValid = true;

        /// <summary>
        /// creates a constructor to implement the interface and initialize the instance variables,
        /// removes the comments and blocks so that it can be ignored while parsing the user written code
        /// </summary>
        /// <param name="codeView">required interface passed from the coding form</param>
        public CommandParserPresenter(ICodeView codeView)
        {
            this.codeView = codeView;
            this.code = codeView.editorCode.ToLower();
           

            removeComments();
            
        }
        
        /// <summary>
        /// creates a method to parse the user-written code provided by the texteditor control,
        /// splits the code document line by line,
        /// if line is a comment ignores that line,
        /// checks if the line is part of a comment block or a block commmand's block if so ignores them to be parsed,
        /// after all of the above conditions are gone through, checks the type of command and parses it accordingly
        /// </summary>
        public void parseCode()
        {
            foreach (string lineString in code.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (lineString[0].Equals(GeneratedLists.acceptedWords[0][0]))
                    continue;

                if (comments.Any(x => lineString.Equals(x)) || blocks.Any(x => lineString.Equals(x)))
                    continue;

                string[] wordsinLine = lineString.Split(' ');

                var matchWord = "";

                if (GeneratedLists.valueTypeCommands.Any(x => wordsinLine[0].Equals(x)))
                {
                    matchWord = GeneratedLists.valueTypeCommands.Single(x => lineString.StartsWith(x));
                    valueTypeParse(lineString, matchWord);
                }
                
                else if (GeneratedLists.BlockCommands.Any(x => wordsinLine[0].Equals(x)))
                {
                    matchWord = GeneratedLists.BlockCommands.Find(x => lineString.StartsWith(x));
                    blockParse(matchWord, lineString);
                }

                else if(GeneratedLists.variables.Any(x => lineString.StartsWith(x.Name)))
                {
                    matchWord = GeneratedLists.variables.Single(x => lineString.StartsWith(x.Name)).Name;
                    int value = int.Parse(GeneratedLists.variables.Single(x => lineString.StartsWith(x.Name)).Value);

                    string line = lineString.Replace(" ", string.Empty);

                    foreach(string s in GeneratedLists.Operators)
                    {
                        if(line.Contains(s))
                        {
                            string[] words = line.Split(char.Parse(s));
                            switch(s)
                            {
                                case "+":
                                    GeneratedLists.variables.Find(c => c.Name.Equals(matchWord)).Value = "" + (int)(value + int.Parse(words[1]));
                                    break;

                                case "-":
                                    GeneratedLists.variables.Find(c => c.Name.Equals(matchWord)).Value = "" + (int)(value - int.Parse(words[1]));
                                    break;

                                case "*":
                                    GeneratedLists.variables.Find(c => c.Name.Equals(matchWord)).Value = "" + (int)(value * int.Parse(words[1]));
                                    break;

                                case "%":
                                    GeneratedLists.variables.Find(c => c.Name.Equals(matchWord)).Value = "" + (int)(value % int.Parse(words[1]));
                                    break;

                                case "=":
                                    GeneratedLists.variables.Find(c => c.Name.Equals(matchWord)).Value = "" + int.Parse(words[1]);
                                    break;

                                default:
                                    GeneratedLists.variables.Find(c => c.Name.Equals(matchWord)).Value = "" + (int)(value + int.Parse(words[1]));
                                    break;
                            } 
                            break;
                        }
                    }
                }
            }
        }

       /// <summary>
       /// parses the code line if it contains a value type command like pen, moveto, rectangle, etc.
       /// gets the specific shape object through the shapefactory for the respective value type command,
       /// draws the specific shape after getting its object onto the graphics object in the coding form panel,
       /// retrieves the parameters for each value type command through helper methods such as checkParams()
       /// </summary>
       /// <param name="lineString">line string of the command</param>
       /// <param name="word">name of the command</param>
        public void valueTypeParse(string lineString, string word)
        {
            lineString = lineString.Trim();
            ShapeFactory shapeFactory = new ShapeFactory();
            string[] words;
            
            switch (word)
            {
                case "pen":

                    words = lineString.Split(new[] { ' ' }, 2);

                    var restWords = words[1].Trim();

                    if(restWords.Contains(','))
                    {
                        var paramsPart = restWords.Split(',');
                        refPen = new Pen(Color.FromName(paramsPart[0]), int.Parse(paramsPart[1]));
                    }
                    else
                    {
                        refPen = new Pen(Color.FromName(words[1]));
                    }

                    break;

                case "drawto":
                    
                    (point1, point2) = checkParamsForPoint(lineString);
                    
                    codeView.canvas.DrawLine(refPen, point1, point2);

                    drawtoCount++;

                    break;

                case "moveto":
                    
                    (point1, point2) = checkParamsForPoint(lineString);

                    for (int i=0;i<drawtoCount;i++)
                    {
                        codeView.canvas.DrawLine(refPen, point1, point2);
                    }

                    drawtoCount = 0;

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

                case "arc":

                    Point[] pointsArc = checkParamsForPolygon(lineString);

                    Shape arc = shapeFactory.getArcShape(point1, point2, pointsArc[0].X, pointsArc[0].Y, pointsArc[1].X, pointsArc[1].Y, refPen, codeView.canvas);
                    arc.draw();

                    break;

                case "pie":

                    Point[] pointsPie = checkParamsForPolygon(lineString);

                    Shape pie = shapeFactory.getPieShape(point1, point2, pointsPie[0].X, pointsPie[0].Y, pointsPie[1].X, pointsPie[1].Y, refPen, codeView.canvas);
                    pie.draw();

                    break;

                case "bezier":

                    Point[] pointsBez = checkParamsForPolygon(lineString);

                    Shape bezier = shapeFactory.getBezierShape(pointsBez[0], pointsBez[1], pointsBez[2], pointsBez[3], refPen, codeView.canvas);
                    bezier.draw();

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
                            {
                                radius = int.Parse(vr.Value);
                            }

                        }
                    }
                    
                    Shape circle = shapeFactory.getCircleShape(point1, point2, radius, refPen, codeView.canvas);
                    circle.draw();

                    break;
                    
                case "repeat":

                    string[] repeatWords = lineString.Split(' ');

                    int loopCount = int.Parse(repeatWords[1]);

                    int circRadius = int.Parse(GeneratedLists.repeatDictionary.Keys.ElementAt(repeatCount).Value);
                    int hitCount = GeneratedLists.repeatDictionary[GeneratedLists.repeatDictionary.Keys.ElementAt(repeatCount)];

                    for(int i=0;i<loopCount;i++)
                    {
                        Shape circleInstance = shapeFactory.getCircleShape(point1, point2, circRadius, refPen, codeView.canvas);
                        circleInstance.draw();
                        circRadius = circRadius + hitCount;
                    }

                    repeatCount++;
                    break;


            }
        }

        /// <summary>
        /// parses the code line if it contains a value type command like loop, if, etc.
        /// retrieves the substring which contains the block of code enclosed in the block command,
        /// parses it because it will be ignored while parsing at the start of the parsing commands,
        /// parsing of the block is done with the helper command parseBlock()
        /// </summary>
        /// <param name="word">name of the block command</param>
        /// <param name="lineString">line string of the block command</param>
        public void blockParse(string word, string lineString)
        {
            lineString = lineString.Trim();
            switch (word)
            {
                case "loop":
                   
                    string[] loopParams = lineString.Split(' ');

                    if(!int.TryParse(loopParams[1], out int forCount))
                    {
                        foreach(Variable vr in GeneratedLists.variables)
                        {
                            if(loopParams[1].Equals(vr.Name))
                            {
                                forCount = int.Parse(vr.Value);
                            }
                        }
                    }
                    
                    BlockCommand loop = loopList[loopCount];
                    
                    int firstIndex = loop.name.Length + loop.index;
                    int secondIndex = (loop.mapToIndex - 1) - firstIndex;
                    string subString = code.Substring(firstIndex, secondIndex);

                    string subStringTOIGNORE = code.Substring(loop.index, (loop.mapToIndex + loop.mapTo.Length) - loop.index);

                    blocks.AddRange(subStringTOIGNORE.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList());
                    
                    loopCount++;

                    for(int i=0;i<forCount;i++)
                    {
                        parseBlock(subString);
                    }

                break;

                case "if":

                    string[] words = lineString.Split(new[] { ' ' }, 2);

                    string restWords = words[1];

                    restWords = restWords.Replace(" ", string.Empty);

                    string[] paramsPart = restWords.Split('=');

                    int result = (int) new DataTable().Compute(paramsPart[0], null);

                    BlockCommand ifWord = ifList[ifCount];

                    int fIndex = ifWord.name.Length + ifWord.index;
                    int sIndex = (ifWord.mapToIndex - 1) - fIndex;
                    string IFsubString = code.Substring(fIndex, sIndex);

                    string IFsubStringTOIGNORE = code.Substring(ifWord.index, (ifWord.mapToIndex + ifWord.mapTo.Length) - ifWord.index);

                    blocks.AddRange(IFsubStringTOIGNORE.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList());

                    ifCount++;

                    if (result == int.Parse(paramsPart[1]))
                    {
                        ifValid = true;
                        
                        parseBlock(IFsubString);
                    }
                    else
                    {
                        ifValid = false;
                    }

                    break;

                case "else":

                    BlockCommand elseWord = elseList[elseCount];

                    int startIndex = elseWord.name.Length + elseWord.index;
                    int endIndex = (elseWord.mapToIndex - 1) - startIndex;
                    string ELSEsubString = code.Substring(startIndex, endIndex);

                    string ELSEsubStringTOIGNORE = code.Substring(elseWord.index, (elseWord.mapToIndex + elseWord.mapTo.Length) - elseWord.index);

                    blocks.AddRange(ELSEsubStringTOIGNORE.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList());

                    elseCount++;
                    
                    if(!ifValid)
                    {
                        parseBlock(ELSEsubString);
                    }

                    break;
                    
            }

        }

        /// <summary>
        /// parses the block of code passed from the block command parsing method,
        /// implements similar logic from the first document parsing method,
        /// the method is like a recursive function of parseCode() which is run when a block command is detected,
        /// when this method terminates, it goes back to the block commmand parsing method and eventually the first parseCode() method
        /// </summary>
        /// <param name="codeBlock">substring containing the block of code</param>
        public void parseBlock(string codeBlock)
        {
            Console.WriteLine("Block entered");
            foreach (string lineString in codeBlock.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (lineString[0].Equals(GeneratedLists.acceptedWords[0][0]))
                    continue;

                string[] wordsinLine = lineString.Split(' ');

                var matchWord = "";

                if (GeneratedLists.valueTypeCommands.Any(x => wordsinLine[0].Equals(x)))
                {
                    matchWord = GeneratedLists.valueTypeCommands.Single(x => lineString.StartsWith(x));
                    valueTypeParse(lineString, matchWord);
                }

                else if (GeneratedLists.BlockCommands.Any(x => wordsinLine[0].Equals(x)))
                {
                    matchWord = GeneratedLists.BlockCommands.Single(x => lineString.StartsWith(x));
                    blockParse(matchWord, lineString);
                }

                else if (GeneratedLists.variables.Any(x => lineString.StartsWith(x.Name)))
                {
                    matchWord = GeneratedLists.variables.Single(x => lineString.StartsWith(x.Name)).Name;
                    int value = int.Parse(GeneratedLists.variables.Single(x => lineString.StartsWith(x.Name)).Value);

                    string line = lineString.Replace(" ", string.Empty);

                    foreach (string s in GeneratedLists.Operators)
                    {
                        if (line.Contains(s))
                        {
                            string[] words = line.Split(char.Parse(s));
                            switch (s)
                            {
                                case "+":
                                    GeneratedLists.variables.Find(c => c.Name.Equals(matchWord)).Value = "" + (int)(value + int.Parse(words[1]));
                                    break;

                                case "-":
                                    GeneratedLists.variables.Find(c => c.Name.Equals(matchWord)).Value = "" + (int)(value - int.Parse(words[1]));
                                    break;

                                case "*":
                                    GeneratedLists.variables.Find(c => c.Name.Equals(matchWord)).Value = "" + (int)(value * int.Parse(words[1]));
                                    break;

                                case "%":
                                    GeneratedLists.variables.Find(c => c.Name.Equals(matchWord)).Value = "" + (int)(value % int.Parse(words[1]));
                                    break;

                                case "=":
                                    GeneratedLists.variables.Find(c => c.Name.Equals(matchWord)).Value = "" + int.Parse(words[1]);
                                    break;

                                default:
                                    GeneratedLists.variables.Find(c => c.Name.Equals(matchWord)).Value = "" + (int)(value + int.Parse(words[1]));
                                    break;
                            }
                            break;
                        }
                    }
                }

            }
        }

        /// <summary>
        /// retrieves the list of parameters in the specific command,
        /// splits the line string based on ' ' spaces,
        /// then splits the second part of the string based on ','
        /// parameters are stored in a local variable and returned in the form of array
        /// </summary>
        /// <param name="lineString">line string associated with the required command</param>
        /// <returns>integer array containing the parameters</returns>
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
            

            return paramsReturn.Select(x => int.Parse(x)).ToArray();
            
        }

        /// <summary>
        /// retrieves the list of parameters for commands needing a Point object,
        /// splits the line string by ' ' spaces,
        /// splits the second part of the text by ','
        /// stores the parameters in local objects and returns them in the form of tuples
        /// </summary>
        /// <param name="lineString">linestring associated with the command</param>
        /// <returns>returns the first Point and second Point object</returns>
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

        /// <summary>
        /// retrieves the list of parameters for polygon type commands needing an array of Points,
        /// splits the string by ' ' spaces,
        /// splits the second half of the string by ','
        /// retrieves the parameters and stores them in a local array and returns them
        /// </summary>
        /// <param name="lineString">line string associated with the required command</param>
        /// <returns>returns an array of Point</returns>
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

        /// <summary>
        /// creates a method to remove the comments and blocks enclosed in block commands,
        /// stores the comments and blocks in an array to be ignored by the beginning parseCode() method,
        /// ignoring of the comments is natural but blocks are ignored so that they are not parsed twice,
        /// method is called in the beginning of the class object
        /// </summary>
        public void removeComments()
        {
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
            
        }

    }
}
