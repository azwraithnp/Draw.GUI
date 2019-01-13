using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUIMVP.Views
{
    /// <summary>
    /// Creates a view interface to be used by WelcomeForm that deals with welcoming the user to the application
    /// </summary>
    interface IWelcomeView
    {
        Color themeBackColor { get; set; }
        Color themeForeColor { get; set; }    
    }
}
