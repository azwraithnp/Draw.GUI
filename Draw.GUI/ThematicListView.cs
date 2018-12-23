using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUI
{
    class ThematicListView : Form
    {
        string theme;
        ListView listView1;

        public ListView ListView1 { get => listView1; set => listView1 = value; }

        public ThematicListView(ListView listView, string theme)
        {
            this.theme = theme;
            ListView1 = listView;
            DarkListViewOwnerDraw();
        }



        public void DarkListViewOwnerDraw()
        {
            ListView1.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            // Configure the ListView control for owner-draw and add 
            // handlers for the owner-draw events.
            ListView1.OwnerDraw = true;
            ListView1.DrawItem += new
                DrawListViewItemEventHandler(listView1_DrawItem);
            ListView1.DrawSubItem += new
                DrawListViewSubItemEventHandler(listView1_DrawSubItem);
            ListView1.DrawColumnHeader += new
                DrawListViewColumnHeaderEventHandler(listView1_DrawColumnHeader);
            
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {

                Color c = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));

                e.Graphics.FillRectangle(new SolidBrush(c), e.Bounds);
                

                // Draw the header text.
                using (Font headerFont =
                            new Font("Segoe UI", 9, FontStyle.Regular))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.White, e.Bounds, sf);
                }
            }
            return;
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                // Unless the item is selected, draw the standard 
                // background to make it stand out from the gradient.
                if ((e.ItemState & ListViewItemStates.Selected) == 0)
                {
                    e.DrawBackground();
                }
                
                // Draw the subitem text in red to highlight it. 
                e.Graphics.DrawString(e.SubItem.Text,
                ListView1.Font, Brushes.White, e.Bounds, sf);

                return;
            }
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
                e.DrawFocusRectangle();
            }
            else
            {
                // Draw the background for an unselected item.
                Color c = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));

                e.Graphics.FillRectangle(new SolidBrush(c), e.Bounds);
            }

            // Draw the item text for views other than the Details view.
            if (ListView1.View != View.Details)
            {
                // Draw the header text.
                using (Font headerFont =
                            new Font("Segoe UI", 9, FontStyle.Regular))
                {
                    e.Graphics.DrawString(e.Item.Text, headerFont,
                        Brushes.White, e.Bounds);
                }
            }
        }

        public void LightListViewOwnerDraw()
        {

        }

    }
}
