using Draw.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUIMVP.Models
{
    /// <summary>
    /// creates a dark definition for menustrips,
    /// inherits the IThematicMenuStrip interface
    /// </summary>
    class DarkMenuStrip : IThematicMenuStrip
    {
        string theme;
        MenuStrip menuStrip;

        /// <summary>
        /// creates a constructor to change the properties of a menustrip
        /// </summary>
        /// <param name="menuStrip">required menustrip object</param>
        public DarkMenuStrip(MenuStrip menuStrip)
        {
            this.menuStrip = menuStrip;
        }

        public string Theme { get { return theme; } set { this.theme = value; } }
        public MenuStrip MenuStrip { get {return menuStrip; } set {this.menuStrip = value; } }

        /// <summary>
        /// creates a method to set the properties of the menustrip renderer, backcolor and forecolor
        /// </summary>
        public void setupMenuStrip()
        {
            menuStrip.Renderer = new DarkThemeRenderer();
            menuStrip.BackColor = Colors.themeDarkColumnHeaderColor;
            menuStrip.ForeColor = System.Drawing.Color.White;
        }
    }
}
