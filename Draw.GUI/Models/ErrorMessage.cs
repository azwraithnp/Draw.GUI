using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    abstract class ErrorMessage
    {
        public string message;
        public string word;
        public string fileName;
        public int index;
        public int line;

        public ErrorMessage(int index, string word, string fileName, int line)
        {
            this.index = index;
            this.word = word;
            this.fileName = fileName;
            this.line = line;
        }

        abstract public void generateErrorMsg();

    }
}
