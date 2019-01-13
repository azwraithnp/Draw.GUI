using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    // <summary>
    /// creates a model class for the errors raised during the validation of the code related to multiple commands in same line,
    /// inherits the ErrorMessage model class
    /// </summary>
    public class MultipleCommandsErrorMessage : ErrorMessage
    {
        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="index">index position of the eror command</param>
        /// <param name="word">name of the error command</param>
        /// <param name="fileName">filename of the current active context where the code is being written</param>
        /// <param name="line">line where the error command exists</param>
        /// <param name="lineString">string of the line where the error command exists</param>
        public MultipleCommandsErrorMessage(int index, string word, string fileName, int line, string lineString) : base(index, word, fileName, line, lineString) { }

        /// <summary>
        /// creates a method to generate error message for this command error type
        /// </summary>
        public override void generateErrorMsg()
        {
            this.message = "Multiple commands in the same line '" + this.word + "'";
        }
    }
}
