using Draw.GUI;
using Draw.GUIMVP.Models;
using Draw.GUIMVP.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUIMVP.Presenters
{
    /// <summary>
    /// creates a presenter class to implement business logic for welcome form
    /// </summary>
    class WelcomePresenter
    {
        IWelcomeView welcomeView;

        /// <summary>
        /// creates a constructor to implement the interface
        /// </summary>
        /// <param name="welcomeView">required interface passed from the welcome view</param>
        public WelcomePresenter(IWelcomeView welcomeView)
        {
            this.welcomeView = welcomeView;

        }

        /// <summary>
        /// Creates a method to set back color and fore color for the welcome form according to theme
        /// </summary>
        public void GetColor()
        {
            //TODO User info JSON implementation
            UserInfo user = new UserInfo();
            
            if (user.Theme.Equals("dark"))
            {
                welcomeView.themeBackColor = Colors.themeDarkColor;
                welcomeView.themeForeColor = System.Drawing.Color.White;
            }
            else
            {
                welcomeView.themeBackColor = Colors.themeLightColor;
                welcomeView.themeForeColor = System.Drawing.Color.Black;
                
            }            
        }
        
    }
}
