using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class InvalidSyntaxErrorMessage : ErrorMessage
    {
        
        public InvalidSyntaxErrorMessage(int index, string word, string fileName, int line, string lineString) : base(index, word, fileName, line, lineString)
        {
            
        }
        
        public override void generateErrorMsg()
        {
            this.message = "Invalid syntax : No definition found for the word or character '" + this.word + "'";
        }
    }
}
