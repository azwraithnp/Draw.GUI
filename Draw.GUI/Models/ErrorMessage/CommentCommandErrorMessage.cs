using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    /// <summary>
    /// creates a model class for the errors raised during the validation of the code related to any comment commands,
    /// inherits the ErrorMessage model class
    /// </summary>
    class CommentCommandErrorMessage : ErrorMessage
    {
        private string nextWord;

        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="index">index position of the eror command</param>
        /// <param name="word">name of the error command</param>
        /// <param name="nextWord">name of the command that should be mapped to this block command</param>
        /// <param name="fileName">filename of the current active context where the code is being written</param>
        /// <param name="line">line where the error command exists</param>
        /// <param name="lineString">string of the line where the error command exists</param>
        public CommentCommandErrorMessage(int index, string word, string nextWord, string fileName, int line, string lineString) : base(index, word, fileName, line, lineString) {
            this.nextWord = nextWord;
        }

        /// <summary>
        /// creates a method to generate error message for this command error type
        /// </summary>
        public override void generateErrorMsg()
        {
            this.message = "Missing comment counterpart: '" + this.word + "' without '" + this.nextWord + "'";
        }

    }
}
