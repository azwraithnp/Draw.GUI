using Draw.GUI;
using Draw.GUIMVP.Models;
using Draw.GUIMVP.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUIMVP.Presenters
{
    class WelcomePresenter
    {
        IWelcomeView welcomeView;

        public WelcomePresenter(IWelcomeView welcomeView)
        {
            this.welcomeView = welcomeView;
        }

        public void GetColor()
        {
            //TODO User info JSON implementation
            UserInfo user = new UserInfo();
            user.Theme = "dark";
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

        public void newFileLabel_LinkClicked()
        {
            CodingForm codingForm = new CodingForm();
            codingForm.Show();
        }


        
       
    }
}
