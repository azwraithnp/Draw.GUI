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
        public string lineString;

        public ErrorMessage(int index, string word, string fileName, int line, string lineString)
        {
            this.index = index;
            this.word = word;
            this.fileName = fileName;
            this.line = line;
            this.lineString = lineString;
        }

        abstract public void generateErrorMsg();

    }
}
