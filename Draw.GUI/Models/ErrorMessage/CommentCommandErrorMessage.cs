using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class CommentCommandErrorMessage : ErrorMessage
    {
        private string nextWord;

        public CommentCommandErrorMessage(int index, string word, string nextWord, string fileName, int line, string lineString) : base(index, word, fileName, line, lineString) {
            this.nextWord = nextWord;
        }

        public override void generateErrorMsg()
        {
            this.message = "Missing comment counterpart: '" + this.word + "' without '" + this.nextWord + "'";
        }

    }
}
