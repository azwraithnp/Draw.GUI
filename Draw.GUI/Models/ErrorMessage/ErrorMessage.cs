using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    /// <summary>
    /// creates a model abstract class for the error messages,
    /// acts as a parent class which its subtypes can inherit from
    /// </summary>
    public abstract class ErrorMessage
    {
        public string message;
        public string word;
        public string fileName;
        public int index;
        public int line;
        public string lineString;

        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="index">index position of the eror command</param>
        /// <param name="word">name of the error command</param>
        /// <param name="fileName">filename of the current active context where the code is being written</param>
        /// <param name="line">line where the error command exists</param>
        /// <param name="lineString">string of the line where the error command exists</param>
        public ErrorMessage(int index, string word, string fileName, int line, string lineString)
        {
            this.index = index;
            this.word = word;
            this.fileName = fileName;
            this.line = line;
            this.lineString = lineString;
        }

        /// <summary>
        /// creates an abstract method to generate error message for the error command
        /// </summary>
        abstract public void generateErrorMsg();

    }
}
