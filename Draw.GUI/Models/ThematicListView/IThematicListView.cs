using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUIMVP.Models
{
    /// <summary>
    /// creates an interface to create different listviews according to theme
    /// </summary>
    interface IThematicListView
    {
        string Theme { get; set; }
        ListView ListView { get; set; }
        
        /// <summary>
        /// creates a method to set the properties of the listview item, subitem and column headers
        /// </summary>
        void setupHandlers();

        /// <summary>
        /// creates a method to set the properties of listview column headers
        /// </summary>
        /// <param name="sender">obligated sender object parameter</param>
        /// <param name="e">obligated drawlistviewcolumnheader event arguments parameter</param>
        void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e);

        /// <summary>
        /// creates a method to set the properties of listview sub item
        /// </summary>
        /// <param name="sender">obligated sender object parameter</param>
        /// <param name="e">obligated drawlistviewsubitem event arguments parameter</param>
        void listView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e);

        /// <summary>
        /// creates a method to set the properties of listview item
        /// </summary>
        /// <param name="sender">obligated sender object parameter</param>
        /// <param name="e">obligated drawlistviewitem event arguments parameter</param>
        void listView_DrawItem(object sender, DrawListViewItemEventArgs e);
    }
}
