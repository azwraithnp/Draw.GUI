﻿using Draw.GUI;
using Draw.GUI.Models;
using Draw.GUI.Models.Counters;
using Draw.GUIMVP.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUIMVP.Presenters
{
    /// <summary>
    /// creates a presenter class to implement the business logic for validation of the user written code in coding form
    /// </summary>
    public class CommandValidatorPresenter
    {
        ICodeView codeView;
        string code;
        string fileName;

        List<BlockCommand> blockList = new List<BlockCommand>();
        List<ValueTypeCommand> valueCmdList = new List<ValueTypeCommand>();
        List<Variable> variableList = new List<Variable>();

        /// <summary>
        /// creates a constructor to implement the interface and initialize the instance variables,
        /// clears the error messages and resets the value of counter variables,
        /// parses the keywords and validates the code written by the user,
        /// adds a log of error messages in the listview for each error message,
        /// saves the block commands detected in the code to GeneratedLists to be used later during parsing,
        /// checks if pen or moveto/drawto command is declared and throws a exception if not found
        /// </summary>
        /// <param name="codeView">required interface passed from the coding form</param>
        public CommandValidatorPresenter(ICodeView codeView)
        {
            GeneratedLists.goodToRun = true;
            this.codeView = codeView;
            this.code = codeView.editorCode.ToLower();
            this.fileName = codeView.fileName;

            codeView.ListView.Items.Clear();
            GeneratedLists.errorMessages.Clear();

            Counters.initialCode = code;
            ErrorPOSCounters.indexStartFORPos = 0;
            BlockCounters.indexStart = 0;
            BlockCounters.indexSecondStart = 0;
            
            parseKeyWords();
            validateCode();
            
            foreach (ErrorMessage msg in GeneratedLists.errorMessages)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { "DG" + msg.index, msg.message, "" + msg.line, msg.fileName });
                codeView.ListView.Items.Add(listViewItem);
            }

            GeneratedLists.blockComsInCode = blockList;

            try
            {
                if (valueCmdList.Count > 0 && !valueCmdList.Any(x => x.name.Equals("pen")))
                {
                    throw new PenNotFoundException("Pen not found");
                }
            }
            catch (PenNotFoundException)
            {
                
                GeneratedLists.goodToRun = false;
                MessageBox.Show("Pen is not declared. Drawing commands might not work.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                if (valueCmdList.Count > 0 && !valueCmdList.Any(x => x.name.Equals("moveto") || x.name.Equals("drawto")))
                {
                    throw new MoveToNotFoundException("Moveto not found");
                }
                
            }
            catch (MoveToNotFoundException)
            {
                
                GeneratedLists.goodToRun = false;
                MessageBox.Show("Moveto is not declared. Moveto and drawto commands are used to position the drawing commands.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        /// <summary>
        /// method responsible for validating the user written code retrieved from the texteditor control of the coding form,
        /// splits the code by Environment.Newline to be checked line by line,
        /// if the line is a comment it is ignored but counter variables are still incremented,
        /// checkForMultipleCommands() method is called to check whether multiple lines are declared in one line,
        /// splits the linestring by word, i.e., by ' ' spaces,
        /// checks whether the word is a valid syntax command,
        /// if command is a type of value type command adds it to value commands list,
        /// if command is a type of block command, calls the method reponsible for the validation of block commands,
        /// generate error if the word is not a valid syntax command.
        /// call methods responsible for block and comment validity and invalid syntax errors
        /// </summary>
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

                checkForMultipleCommands(wordsinLine, lineNumber, lineString);

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

                            if (GeneratedLists.valueTypeCommands.Contains(word))
                            {
                                valueCmdList.Add(new ValueTypeCommand(Counters.valueTypeGenerator.Id, checkErrorPos(word), word, lineNumber, lineString));
                                Counters.valueTypeGenerator.increment();
                            }

                            if (GeneratedLists.BlockCommands.Contains(word))
                                checkBlockValidity(word, lineNumber, lineString);
                               
                        }
                        
                    }
                    if (!Counters.valid)
                    {
                        //TODO Fix the error messages
                        InvalidSyntaxErrorMessage msg = new InvalidSyntaxErrorMessage(checkErrorPos(word), word, fileName, lineNumber, lineString);
                        msg.generateErrorMsg();
                        GeneratedLists.errorMessages.Add(msg);
                    }
                    
                }

                ErrorPOSCounters.indexStartFORPos = ErrorPOSCounters.indexStartFORPos + lineString.Length;

                lineNumber++;
            }

            checkBlocknCommentValidity();
            checkParameters();
            foreach (ErrorMessage msg in GeneratedLists.errorMessages)
            {
                checkInvalidSyntax();
            }
        }

        /// <summary>
        /// creates method to check whether more than one command is declared in same line,
        /// creates a counter variable to check the number of syntax commands present in the line,
        /// if word count that matches syntax commands is greater than 1, creates a multiple commands error for those words 
        /// </summary>
        /// <param name="wordsInLine">words in line passed from the parseCode() method</param>
        /// <param name="line">line number associated with the lineString</param>
        /// <param name="lineString">string of line passed form the calling method</param>
        public void checkForMultipleCommands(string[] wordsInLine, int line, string lineString)
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
                            MultipleCommandsErrorMessage errorMessage = new MultipleCommandsErrorMessage(checkErrorPos(word), word, fileName, line, lineString);
                            errorMessage.generateErrorMsg();
                            GeneratedLists.errorMessages.Add(errorMessage);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// creates method to check whether the erors identified as syntax commands are really errors or not,
        /// creates a temp list to store the errors that should be ignored,
        /// creates another list to store errors in the error list which are identified by this method,
        /// ignores the commands in the same line as repeat command as its parameters,
        /// ignores the commands in the same line as block and value type commands,
        /// makes sure that the variables declared are not counted as invalid syntax errors,
        /// if the variables parameters is not valid, creates an invalid parameter errro and adds it to the list,
        /// removes the ignored list of errors from the GeneratedLists object
        /// </summary>
        public void checkInvalidSyntax()
        {
            List<ErrorMessage> tempList = new List<ErrorMessage>();
            List<ErrorMessage> toAdd = new List<ErrorMessage>();

            foreach (ErrorMessage message in GeneratedLists.errorMessages)
            {
                if(message.lineString.StartsWith("repeat") && !message.GetType().ToString().Equals("Draw.GUI.InvalidParameterErrorMessage"))
                {

                    tempList.Add(message);
                                        
                    goto End;
                }
                else if(message.lineString.StartsWith("repeat") && message.word.Equals("circle"))
                {
                    tempList.Add(message);

                    goto End;
                }

                if(message.GetType().ToString().Equals("Draw.GUI.InvalidSyntaxErrorMessage") || message.GetType().ToString().Equals("Draw.GUI.MultipleCommandsErrorMessage"))
                {
       
                    //For block parameter checking
                    foreach (BlockCommand block in blockList)
                    {
                        if (block.mapTo != null)
                        {
                            //if(message.index > block.index && message.index < block.mapToIndex)
                            //{
                            //    Console.WriteLine("Error word: " + message.word + "AND YES");
                            //    tempList.Add(message);
                            //    goto End;
                            //}

                            if (message.line == block.line)
                            {
                                tempList.Add(message);
                                goto End;
                            }
                        }
                    }

                    //For value types parameter checking
                    foreach (ValueTypeCommand value in valueCmdList)
                    {
                        if(message.line == value.line)
                        {
                            tempList.Add(message);
                            goto End;
                        }
                    }

                   
                    foreach (Variable vr in GeneratedLists.variables)
                    {
                        bool valid = false;
                        string errorMsg = "";

                        InvalidSyntaxErrorMessage msg = (InvalidSyntaxErrorMessage) message;
                        if(msg.lineString.StartsWith(vr.Name))
                        {
                            tempList.Add(message);
                            string line = msg.lineString;
                            line = line.Replace(" ", string.Empty);
                            
                            foreach(string s in GeneratedLists.Operators)
                            {
                                if(line.Contains(s))
                                {
                                    string[] words = line.Split(char.Parse(s));
                                    if(words[0].Equals(vr.Name))
                                    {
                                        valid = true;
                                        List<string> abc = words.ToList();
                                        abc.Remove(words[0]);
                                        words = abc.ToArray();
                                    }
                                    (valid, errorMsg) = checkforParamsSplit(words);
              
                                    break;
                                }
                            }

                            if(!valid)
                            {
                                InvalidParameterErrorMessage error = new InvalidParameterErrorMessage(message.index, vr.Name, fileName, vr.Line, message.lineString);
                                if (errorMsg.Equals(""))
                                {
                                    error.generateErrorMsg();
                                }
                                else
                                {
                                    error.generateErrorMsg(errorMsg);
                                }

                                toAdd.Add(error);
                            }

                            break;
                        }
                    }
                                        
                }
            }
            
            End: 
            GeneratedLists.errorMessages = GeneratedLists.errorMessages.Except(tempList).ToList();
            GeneratedLists.errorMessages.AddRange(toAdd);
        }

        
        /// <summary>
        /// creates a method to check parameters of the syntax commands,
        /// since parameters of every syntax command can be different, checks the type of command before validating,
        /// checks the parameter of every value type command detected in the code according to its definition,
        /// after validation of value type commands is done, same is done for block commands detected in the code,
        /// validation is done by splitting the line string of command by ' ' spaces and then by ','
        /// parameters returned by splitting the second part of the string is then checked for integer value or variable declaration,
        /// for if command, the parameter is checked for a valid conditional statement 
        /// </summary>
        public void checkParameters()
        {
            foreach(ValueTypeCommand valueCmd in valueCmdList)
            {
                bool valid = true;
                
                if (valueCmd.name.Equals("number"))
                {
                    string message = "";

                    var words = valueCmd.lineString.Split(new[] { ' ' }, 2);

                    if (words.Length < 2)
                    {
                        valid = false;
                    }
                    else
                    {
                        var restWords = words[1];
                        restWords = restWords.Replace("  ", String.Empty);

                        string[] assignmentPart = restWords.Split('=');

                        if (assignmentPart.Length < 2 || assignmentPart.Length > 2 || assignmentPart[0].Equals(""))
                        {
                            valid = false;
                        }
                        else
                        {
                            if (!int.TryParse(assignmentPart[1], out int n))
                                valid = false;
                        }

                        foreach (Variable vr in GeneratedLists.variables)
                        {
                            if(vr.Name.Equals(assignmentPart[0].Trim()))
                            {
                                valid = false;
                                message = "Variable with name '" + assignmentPart[0] + "' already declared in this context";
                            }
                        }

                        if (valid)
                            GeneratedLists.variables.Add(new Variable(assignmentPart[0].Trim(), "Number", valueCmd.line, assignmentPart[1].Trim()));
                        else
                        //TODO Filename
                        {
                            InvalidParameterErrorMessage error = new InvalidParameterErrorMessage(valueCmd.index, valueCmd.name, fileName, valueCmd.line, valueCmd.lineString);
                            if(message.Equals(""))
                            {
                                error.generateErrorMsg();
                            }
                            else
                            {
                                error.generateErrorMsg(message);
                            }
                            GeneratedLists.errorMessages.Add(error);
                        }
                    }

                }

                else if (valueCmd.name.Equals("pen"))
                {
                    valid = true;

                    var words = valueCmd.lineString.Split(new[] { ' ' }, 2);

                    
                    if (words.Length < 2)
                    {
                        valid = false;
                    }
                    else
                    {
                        var restWords = words[1];

                        if(restWords.Equals(""))
                        {
                            valid = false;
                        }
                        else
                        {
                            if (restWords.Contains(','))
                            {
                                string[] paramsPart = restWords.Split(',');
                                valid = int.TryParse(paramsPart[1], out int res);
                            }
                        }
                        
                    }
                    if(!valid)
                    {
                        InvalidParameterErrorMessage error = new InvalidParameterErrorMessage(valueCmd.index, valueCmd.name, fileName, valueCmd.line, valueCmd.lineString);
                        error.generateErrorMsg();
                        GeneratedLists.errorMessages.Add(error);
                    }
                }

                else if (valueCmd.name.Equals("polygon"))
                {
                    valid = true;
                    string message = "";

                    var words = valueCmd.lineString.Split(new[] { ' ' }, 2);

                    if (words.Length < 2)
                    {
                        valid = false;
                    }
                    else
                    {
                        var restWords = words[1];
                        restWords = restWords.Replace(" ", String.Empty);

                        string[] paramsPart = restWords.Split(',');

                        if(paramsPart.Length < 4)
                        {
                            valid = false;
                        }
                        else
                        {
                            (valid, message) = checkforParamsSplit(paramsPart);
                        }

                    }
                    if (!valid)
                    {
                        InvalidParameterErrorMessage error = new InvalidParameterErrorMessage(valueCmd.index, valueCmd.name, fileName, valueCmd.line, valueCmd.lineString);
                        if (message.Equals(""))
                        {
                            error.generateErrorMsg();
                        }
                        else
                        {
                            error.generateErrorMsg(message);
                        }

                        GeneratedLists.errorMessages.Add(error);
                    }
                }

                else if(valueCmd.name.Equals("bezier"))
                {
                    valid = true;
                    string message = "";

                    var words = valueCmd.lineString.Split(new[] { ' ' }, 2);

                    if (words.Length < 2)
                    {
                        valid = false;
                    }
                    else
                    {
                        var restWords = words[1];
                        restWords = restWords.Replace(" ", String.Empty);

                        string[] paramsPart = restWords.Split(',');

                        if (paramsPart.Length < 8)
                        {
                            valid = false;
                        }
                        else
                        {
                            (valid, message) = checkforParamsSplit(paramsPart);
                        }

                    }
                    if (!valid)
                    {
                        InvalidParameterErrorMessage error = new InvalidParameterErrorMessage(valueCmd.index, valueCmd.name, fileName, valueCmd.line, valueCmd.lineString);
                        if (message.Equals(""))
                        {
                            error.generateErrorMsg();
                        }
                        else
                        {
                            error.generateErrorMsg(message);
                        }

                        GeneratedLists.errorMessages.Add(error);
                    }
                }

                else if (valueCmd.name.Equals("triangle"))
                {
                    valid = true;
                    string message = "";

                    var words = valueCmd.lineString.Split(new[] { ' ' }, 2);

                    if (words.Length < 2)
                    {
                        valid = false;
                    }
                    else
                    {

                        var restWords = words[1];
                        restWords = restWords.Replace(" ", String.Empty);

                        string[] paramsPart = restWords.Split(',');

                        if(paramsPart.Length < 6 || paramsPart.Length > 6)
                        {
                            valid = false;
                        }
                        else
                            (valid, message) = checkforParamsSplit(paramsPart);
                        
                    }
                    if (!valid)
                    {
                        InvalidParameterErrorMessage error = new InvalidParameterErrorMessage(valueCmd.index, valueCmd.name, fileName, valueCmd.line, valueCmd.lineString);
                        if (message.Equals(""))
                        {
                            error.generateErrorMsg();
                        }
                        else
                        {
                            error.generateErrorMsg(message);
                        }

                        GeneratedLists.errorMessages.Add(error);
                    }
                }
                
                else if (GeneratedLists.TwoParameterCommands.Contains(valueCmd.name))
                {
                    valid = true;
                    string message = "";

                    var words = valueCmd.lineString.Split(new[] { ' ' }, 2);
                    
                    if (words.Length < 2)
                    {
                        valid = false;
                    }
                    else
                    {
                        var restWords = words[1];
                        restWords = restWords.Replace(" ", String.Empty);

                        string[] paramsPart = restWords.Split(',');

                        if (paramsPart.Length < 2 || paramsPart.Length > 2)
                        {
                            valid = false;
                        }
                        else
                        {
                            (valid, message) = checkforParamsSplit(paramsPart);
                        }

                       
                    }

                    if (!valid)
                    //TODO Filename
                    {
                        InvalidParameterErrorMessage error = new InvalidParameterErrorMessage(valueCmd.index, valueCmd.name, fileName, valueCmd.line, valueCmd.lineString);
                        if (message.Equals(""))
                        {
                            error.generateErrorMsg();
                        }
                        else
                        {
                            error.generateErrorMsg(message);
                        }

                        GeneratedLists.errorMessages.Add(error);
                    }

                }

                else if (GeneratedLists.FourParameterCommands.Contains(valueCmd.name))
                {
                    valid = true;
                    string message = "";

                    var words = valueCmd.lineString.Split(new[] { ' ' }, 2);

                    if (words.Length < 2)
                    {
                        valid = false;
                    }
                    else
                    {
                        var restWords = words[1];
                        restWords = restWords.Replace(" ", String.Empty);

                        string[] paramsPart = restWords.Split(',');

                        if (paramsPart.Length < 4 || paramsPart.Length > 4)
                        {
                            valid = false;
                        }
                        else
                        {
                            (valid, message) = checkforParamsSplit(paramsPart);
                        }


                    }


                    if (!valid)
                    //TODO Filename
                    {
                        InvalidParameterErrorMessage error = new InvalidParameterErrorMessage(valueCmd.index, valueCmd.name, fileName, valueCmd.line, valueCmd.lineString);
                        if (message.Equals(""))
                        {
                            error.generateErrorMsg();
                        }
                        else
                        {
                            error.generateErrorMsg(message);
                        }
                        GeneratedLists.errorMessages.Add(error);
                    }
                }

                else if (GeneratedLists.SingleParameterCommands.Contains(valueCmd.name))
                {
                    valid = true;
                    string message = "";

                    string[] words = valueCmd.lineString.Split(' ');

                    if (words.Length > 2 || words.Length < 2)
                    {
                        valid = false;
                    } 
                    else
                    {
                        if (!int.TryParse(words[1], out int sp))
                        {
                            valid = false;
                            message = "Invalid parameters. Couldn't find the variable '" + words[1] + "' declared in the context";
                            foreach (Variable vr in GeneratedLists.variables)
                            {
                                if (words[1].Equals(vr.Name))
                                    valid = true;
                            }
                        }
                    }

                    if (!valid)
                    //TODO Filename
                    {
                        InvalidParameterErrorMessage error = new InvalidParameterErrorMessage(valueCmd.index, valueCmd.name, fileName, valueCmd.line, valueCmd.lineString);
                        if (message.Equals(""))
                        {
                            error.generateErrorMsg();
                        }
                        else
                        {
                            error.generateErrorMsg(message);
                        }

                        GeneratedLists.errorMessages.Add(error);
                        
                    }
                }

                else if(valueCmd.name.Equals("repeat"))
                {
                    valid = true;
                    string msg = "";

                    string[] words = valueCmd.lineString.Split(' ');

                    if (words.Length > 6 || words.Length < 4)
                    {
                        valid = false;
                    }
                    else
                    {
                        if (!int.TryParse(words[1], out int num))
                        {
                            valid = false;
                            msg = "Invalid parameters. Couldn't find the variable '" + words[1] + "' declared in the context";
                            foreach (Variable vr in GeneratedLists.variables)
                            {
                                if (words[1].Equals(vr.Name))
                                    valid = true;
                            }
                        }

                        if (words[2].ToLower().Equals("circle"))
                        {
                            valid = false;

                            if (words.Length == 4)
                            {
                                foreach (Variable vr in GeneratedLists.variables)
                                {
                                    if (words[3].StartsWith(vr.Name))
                                    {
                                        foreach (string s in GeneratedLists.Operators)
                                        {
                                            if (words[3].Contains(s))
                                            {
                                                string[] trimWords = words[3].Split(char.Parse(s));
                                                if (trimWords[0].Equals(vr.Name))
                                                {
                                                    valid = true;
                                                    List<string> abc = trimWords.ToList();
                                                    words = abc.ToArray();
                                                }
                                                (valid, msg) = checkforParamsSplit(words);
                                                if(valid)
                                                {
                                                    GeneratedLists.repeatDictionary.Add(vr, int.Parse(trimWords[1]));
                                                }

                                                break;

                                            }

                                        }

                                    }

                                }

                            }

                            else
                            {
                                string restWords = "";
                                for (int i = 3; i < words.Length; i++)
                                {
                                    restWords += words[i];
                                }

                                Console.WriteLine(restWords);

                                restWords = restWords.Replace(" ", string.Empty);

                                foreach (Variable vr in GeneratedLists.variables)
                                {
                                    if (restWords.StartsWith(vr.Name))
                                    {
                                        foreach (string s in GeneratedLists.Operators)
                                        {
                                            if (restWords.Contains(s))
                                            {
                                                string[] trimWords = restWords.Split(char.Parse(s));
                                                if (trimWords[0].Equals(vr.Name))
                                                {
                                                    valid = true;
                                                    List<string> abc = trimWords.ToList();
                                                    words = abc.ToArray();
                                                }
                                                (valid, msg) = checkforParamsSplit(words);

                                                if(valid)
                                                {
                                                    GeneratedLists.repeatDictionary.Add(vr, int.Parse(trimWords[1]));
                                                }

                                                break;

                                            }

                                        }

                                    }

                                }

                            }

                        }
                    }

                    if (!valid)
                    {
                        InvalidParameterErrorMessage error = new InvalidParameterErrorMessage(valueCmd.index, valueCmd.name, fileName, valueCmd.line, valueCmd.lineString);
                        if (msg.Equals(""))
                        {
                            error.generateErrorMsg();
                        }
                        else
                        {
                            error.generateErrorMsg(msg);
                        }

                        GeneratedLists.errorMessages.Add(error);
                        
                    }
                }
               
            }

            foreach (BlockCommand bc in blockList)
            {
                bool valid = true;
                string message = "";

                if(bc.name.Equals("loop"))
                {
                    
                    string[] words = bc.lineString.Split(' ');

                    Console.WriteLine(words.Length);

                    if (words.Length < 2 || words.Length > 2)
                    {
                        valid = false;
                    }
                    else
                    {
                        if (!int.TryParse(words[1], out int ab))
                        {
                            valid = false;

                            message = "Invalid parameters. Couldn't find the variable '" + words[1] + "' declared in the context";
                            foreach (Variable vr in GeneratedLists.variables)
                            {
                                if (words[1].Equals(vr.Name))
                                    valid = true;
                            }

                        }
                        
                    }

                    if (!valid)
                    {
                        InvalidParameterErrorMessage error = new InvalidParameterErrorMessage(bc.index, bc.name, fileName, bc.line, bc.lineString);
                        error.generateErrorMsg();
                        GeneratedLists.errorMessages.Add(error);
                    }
                }

                if (bc.name.Equals("if"))
                {
                    string[] words = bc.lineString.Split(new[] { ' ' }, 2);

                    if (words.Length < 2)
                    {
                        valid = false;
                    }
                    else
                    {
                        var restWords = words[1];

                        restWords = restWords.Replace(" ", String.Empty);

                        if(!restWords.Contains('='))
                        {
                            valid = false;
                        }
                        else
                        {
                            string[] paramsPart = restWords.Split(GeneratedLists.Operators.ToArray(), StringSplitOptions.None);

                            if (paramsPart.Length < 2)
                            {
                                valid = false;
                            }
                            else
                            {
                                (valid, message) = checkforParamsSplit(paramsPart);
                            }
                        }
                        
                    }

                    if (!valid)
                    {
                        InvalidParameterErrorMessage error = new InvalidParameterErrorMessage(bc.index, bc.name, fileName, bc.line, bc.lineString);
                        if (message.Equals(""))
                        {
                            error.generateErrorMsg();
                        }
                        else
                        {
                            error.generateErrorMsg(message);
                        }
                        
                        GeneratedLists.errorMessages.Add(error);
                    }

                }

            }

        }

        /// <summary>
        /// creates a method used by other validation methods for the paramter part,
        /// checks for every paramter passed by the calling method for int or variable declaration,
        /// if parameter is not integer value or not a variable, invalid parameter error message is generated,
        /// the valid boolean value and string message is returned in the form of a tuple
        /// </summary>
        /// <param name="paramsPart">the list of parameters passed from the calling method</param>
        /// <returns></returns>
        public (bool valid, string message) checkforParamsSplit(string[] paramsPart)
        {
            bool valid = true;
            string message = "";

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
                        foreach (Variable vr in GeneratedLists.variables)
                        {
                            if (paramsPartWord.Equals(vr.Name))
                            valid = true;
                        }
                    }
                }
            }
            
            return (valid, message);
        }

        /// <summary>
        /// creates a method responsible for validation of both block commands and comment commands,
        /// stores the count of if and else commands detected in the code to check later,
        /// for every block command detected, it checks whether the word is should be mapped to is declared in the context or not,
        /// if any block command is not closed, or is closed without opening a block command error message is generated
        /// </summary>
        public void checkBlocknCommentValidity()
        {
            int ifCount=0, elseCount = 0;

            foreach (BlockCommand block in blockList)
            {
                if(block.name.Equals("if"))
                {
                    ifCount++;
                }
                if(block.name.Equals("else"))
                {
                    elseCount++;
                }

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

                        CommentCommandErrorMessage commentMsg = new CommentCommandErrorMessage(block.index, block.name, nextWord, fileName, block.line, block.lineString);
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

                    BlockCommandErrorMessage msg = new BlockCommandErrorMessage(block.index, block.name, nextWord, fileName, block.line, block.lineString);
                    msg.generateErrorMsg();
                    GeneratedLists.errorMessages.Add(msg);
                }
            }

            if(elseCount > ifCount)
            {
                BlockCommandErrorMessage msg = new BlockCommandErrorMessage(0, "else", "if", fileName, 0, "");
                msg.generateErrorMsg();
                GeneratedLists.errorMessages.Add(msg);
            }
        }

        /// <summary>
        /// creates a method responsibe for the validation of block commands,
        /// part of block validation another part is continued in checkBlocknCommentValidity() method,
        /// this method is used to detect the block commands and then check their mapping word,
        /// to check whether the mapping word is present or not, index is calculated for the opening block command,
        /// if the index of closing block command is after the index of opening block command it is considered to be true,
        /// algorithm is hence modified to account for nested block commands and list of other block commands,
        /// after block commands are stored in a list with their mappings, another method checks for validation
        /// </summary>
        /// <param name="word">name of the block command</param>
        /// <param name="line">line number of the block command</param>
        /// <param name="lineString">line string where the block command lies</param>
        public void checkBlockValidity(string word, int line, string lineString)
        {
            BlockCommand block = null;

            string nextWord = "";
            int firstIndex = 0, secondIndex = 0;

            for (int i = 0; i < GeneratedLists.BlockCommands.Count; i++)
            {
                if (word.Equals(GeneratedLists.BlockCommands[i]))
                {
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
                                mapToIndex = secondIndex,
                                lineString = lineString
                            };
                        }
                        else
                        {
                            block = new BlockCommand(Counters.blockGenerator.Id, firstIndex, word, line)
                            {
                                lineString = lineString
                            };
                        }

                        blockList.Add(block);

                        BlockCounters.indexStart = secondIndex + nextWord.Length;
                        BlockCounters.indexSecondStart = firstIndex + word.Length;
                    }
                    else
                    {
                        firstIndex = code.IndexOf(word, BlockCounters.indexSecondStart);
                        bool exists = false;

                        foreach (BlockCommand blockCommand in blockList)
                        {
                            int pos = Array.IndexOf(GeneratedLists.BlockCommands.ToArray(), blockCommand.name);
                            if (pos % 2 == 0)
                            {
                                if (blockCommand.mapToIndex == firstIndex)
                                {
                                    block = new BlockCommand(Counters.blockGenerator.Id, firstIndex, word, line)
                                    {
                                        mapTo = blockCommand.name,
                                        mapToIndex = blockCommand.index,
                                        lineString = lineString
                                    };
                                    exists = true;
                                }
                            }
                        }

                        if (!exists)
                        {
                            block = new BlockCommand(Counters.blockGenerator.Id, firstIndex, word, line)
                            {
                                lineString = lineString
                            };
                        }

                        blockList.Add(block);

                        BlockCounters.indexSecondStart = firstIndex + word.Length;
                    }

                    break;
                }
            }
            
            Counters.blockGenerator.increment();
        }

        /// <summary>
        /// creates a method used by other validation methods to check the index of error commands
        /// </summary>
        /// <param name="word">required command</param>
        /// <returns></returns>
        public int checkErrorPos(string word)
        {
            int wordPos = 0;

            for (int i = 0; i < word.Length; i++)
            {
                wordPos = code.IndexOf(word, ErrorPOSCounters.indexStartFORPos);
            }
            
            return wordPos;
        }

        /// <summary>
        /// creates a method to parse keywords stored in the keywords.json file,
        /// clears the GeneratedLists arrays to reset them when calling the presenter class,
        /// parses the json file to check for accepted syntax commands, the operators, block commands, etc.
        /// stores them in an array and lowers their case so that it can be easier for validation and parsing
        /// </summary>
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

        }
    }
}

