using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class InvalidParameterErrorMessage : ErrorMessage
    {
        public InvalidParameterErrorMessage(int index, string word, string fileName, int line, string lineString) : base(index, word, fileName, line, lineString)
        {

        }

        public override void generateErrorMsg()
        {
            this.message = "Invalid parameter(s) or definition for '" + this.word + "'";
        }

        public void generateErrorMsg(string message)
        {
            this.message = message;
        }
    }
}
