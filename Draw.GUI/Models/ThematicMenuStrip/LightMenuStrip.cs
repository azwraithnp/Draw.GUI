using Draw.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUIMVP.Models
{
    class LightMenuStrip : IThematicMenuStrip
    {
        string theme;
        MenuStrip menuStrip;

        public LightMenuStrip(MenuStrip menuStrip)
        {
            this.menuStrip = menuStrip;
        }

        public string Theme { get { return theme; } set { this.theme = value; } }
        public MenuStrip MenuStrip { get {return menuStrip; } set {this.menuStrip = value; } }

        public void setupMenuStrip()
        {
            menuStrip.Renderer = new LightThemeRenderer();
            menuStrip.BackColor = Colors.themeLightColumnHeaderColor;
            menuStrip.ForeColor = System.Drawing.Color.Black;
        }
    }
}
