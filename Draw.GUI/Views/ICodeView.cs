using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUIMVP.Views
{
    public interface ICodeView
    {
        string HighlightMode { get; set; }

        string editorCode { get; set; }

        string fileName { get; set; }

        string toolBoxControl { get; set; }

        ListView ListView { get; set; }

        Color backColor { get; set; }

        MenuStrip MenuStrip { get; set; }

        Graphics canvas { get; set; }

        Button newPage { get; set; }

        GroupBox groupbox { get; set; }
        
        ComponentResourceManager resource { get; set; }
    }
}
