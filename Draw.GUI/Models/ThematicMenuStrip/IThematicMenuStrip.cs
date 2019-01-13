using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUIMVP.Models
{
    /// <summary>
    /// creates an interface to create different menustrips according to theme
    /// </summary>
    interface IThematicMenuStrip
    {
        string Theme { get; set; }
        MenuStrip MenuStrip { get; set; }

        /// <summary>
        /// creates a method to set the properties of the menustrip renderer, backcolor and forecolor
        /// </summary>
        void setupMenuStrip();
    }
}
