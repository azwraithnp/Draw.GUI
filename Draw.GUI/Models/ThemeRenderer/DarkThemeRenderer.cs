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
    class DarkThemeRenderer : ToolStripProfessionalRenderer
    {
        public DarkThemeRenderer()
        {

        }

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
