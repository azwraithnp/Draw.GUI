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
    class LightThemeRenderer : ToolStripProfessionalRenderer
    {
        public LightThemeRenderer()
        {

        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            if (!e.Item.Selected)
            {
                Color c = Colors.themeLightColumnHeaderColor;
                using (SolidBrush brush = new SolidBrush(c))
                    e.Graphics.FillRectangle(brush, rc);
            }
            else
            {
                Color c = Colors.themeLightListItemSelected;
                using (SolidBrush brush = new SolidBrush(c))
                    e.Graphics.FillRectangle(brush, rc);
            }

        }
    }
}
