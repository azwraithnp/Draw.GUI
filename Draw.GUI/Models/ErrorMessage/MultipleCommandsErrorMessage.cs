using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class MultipleCommandsErrorMessage : ErrorMessage
    {
        public MultipleCommandsErrorMessage(int index, string word, string fileName, int line) : base(index, word, fileName, line) { }

        public override void generateErrorMsg()
        {
            this.message = "Multiple commands in the same line '" + this.word + "'";
        }
    }
}
