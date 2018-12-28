using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUIMVP.Models
{
    interface IThematicMenuStrip
    {
        string Theme { get; set; }
        MenuStrip MenuStrip { get; set; }

        void setupMenuStrip();
    }
}
