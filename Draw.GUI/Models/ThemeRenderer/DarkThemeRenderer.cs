using Draw.GUIMVP.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUI
{
    /// <summary>
    /// creates a dark themed renderer for the menustrip,
    /// inherits the ToolStripProfessionalRenderer class
    /// </summary>
    class DarkThemeRenderer : ToolStripProfessionalRenderer
    {
        public DarkThemeRenderer()
        {

        }

        /// <summary>
        /// overrides the method responsible for drawing the menuitem background on rendered,
        /// creates a rectangle object to draw on the item background,
        /// if item is selected, fill the background rectangle with highlight color,
        /// if item is not selected, fill the background rectangle with theme column header color
        /// </summary>
        /// <param name="e">obligated ToolStripItemRender event arguments parameter</param>
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            if (!e.Item.Selected)
            {
                Color c = Colors.themeDarkColumnHeaderColor;
                using (SolidBrush brush = new SolidBrush(c))
                {
                    e.Graphics.FillRectangle(brush, rc);
                }
            }
            else
            {
                Color c = Colors.themeDarkListItemSelected;
                using (SolidBrush brush = new SolidBrush(c))
                {
                    e.Graphics.FillRectangle(brush, rc);
                }
            }
        }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = Color.White;
                e.TextFont = new Font(e.Item.Font, FontStyle.Regular);
                
                base.OnRenderItemText(e);
            }

    }
}
