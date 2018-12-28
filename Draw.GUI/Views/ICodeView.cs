﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUIMVP.Views
{
    interface ICodeView
    {
        string HighlightMode { get; set; }

        string editorCode { get; set; }

        ListView ListView { get; set; }

        Color backColor { get; set; }

        MenuStrip MenuStrip { get; set; }
    }
}
