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
        public int index;

        public ErrorMessage(int index, string word)
        {
            this.index = index;
            this.word = word;
        }

        abstract public void generateErrorMsg();

    }
}
