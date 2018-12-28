using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUIMVP.Models
{
    interface IThematicListView
    {
        string Theme { get; set; }
        ListView ListView { get; set; }
        
        void setupHandlers();

        void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e);

        void listView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e);

        void listView_DrawItem(object sender, DrawListViewItemEventArgs e);
    }
}
