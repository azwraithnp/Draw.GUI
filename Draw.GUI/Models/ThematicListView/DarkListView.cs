using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUIMVP.Models
{
    class DarkListView : IThematicListView
    {
        string theme = "dark";
        ListView listView;

        public string Theme { get { return theme; }  set { this.theme = value; } }
        public ListView ListView { get {return listView; } set {listView = value; } }

        public DarkListView(ListView listView)
        {
            this.listView = listView;
        }

        public void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {

                Color c = Colors.themeDarkColumnHeaderColor;

                e.Graphics.FillRectangle(new SolidBrush(c), e.Bounds);

                // Draw the header text.
                using (Font headerFont =
                            new Font("Segoe UI", 9, FontStyle.Regular))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.White, e.Bounds, sf);
                }
            }
        }

        public void listView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(new SolidBrush(Colors.themeDarkListItemSelected), e.Bounds);
                e.DrawFocusRectangle();
            }
            else
            {
                // Draw the background for an unselected item.
                Color c = Colors.themeDarkColor;
                e.Graphics.FillRectangle(new SolidBrush(c), e.Bounds);
            }

            // Draw the item text for views other than the Details view.
            if (listView.View != View.Details)
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

        public void listView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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
                listView.Font, Brushes.White, e.Bounds, sf);
            }
        }

        public void setupHandlers()
        {
            listView.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            // Configure the ListView control for owner-draw and add 
            // handlers for the owner-draw events.
            listView.OwnerDraw = true;
            listView.DrawItem += new
                DrawListViewItemEventHandler(listView_DrawItem);
            listView.DrawSubItem += new
                DrawListViewSubItemEventHandler(listView_DrawSubItem);
            listView.DrawColumnHeader += new
                DrawListViewColumnHeaderEventHandler(listView_DrawColumnHeader);
            listView.BackColor = Colors.themeDarkColor;
        }
    }
}
