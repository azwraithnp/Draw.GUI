using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class BlockCommandErrorMessage : ErrorMessage
    {
        private string nextWord;

        public BlockCommandErrorMessage(int index, string word, string nextWord, string fileName, int line) : base(index, word, fileName, line) {
            this.nextWord = nextWord;
        }

        public override void generateErrorMsg()
        {
            this.message = "Missing block counterpart: '" + this.word + "' without '" + this.nextWord + "'";
        }

    }
}
