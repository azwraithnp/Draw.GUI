using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class MultipleCommandsErrorMessage : ErrorMessage
    {
        public MultipleCommandsErrorMessage(int index, string word, string fileName, int line, string lineString) : base(index, word, fileName, line, lineString) { }

        public override void generateErrorMsg()
        {
            this.message = "Multiple commands in the same line '" + this.word + "'";
        }
    }
}
