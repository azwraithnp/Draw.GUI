using Draw.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUIMVP.Models
{
    class DarkMenuStrip : IThematicMenuStrip
    {
        string theme;
        MenuStrip menuStrip;

        public DarkMenuStrip(MenuStrip menuStrip)
        {
            this.menuStrip = menuStrip;
        }

        public string Theme { get { return theme; } set { this.theme = value; } }
        public MenuStrip MenuStrip { get {return menuStrip; } set {this.menuStrip = value; } }

        public void setupMenuStrip()
        {
            menuStrip.Renderer = new DarkThemeRenderer();
            menuStrip.BackColor = Colors.themeDarkColumnHeaderColor;
            menuStrip.ForeColor = System.Drawing.Color.White;
        }
    }
}
