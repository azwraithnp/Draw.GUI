using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUIMVP.Views
{
    interface IWelcomeView
    {
        Color themeBackColor { get; set; }
        Color themeForeColor { get; set; }    
    }
}
