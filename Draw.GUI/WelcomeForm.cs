using Draw.GUIMVP.Presenters;
using Draw.GUIMVP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUI
{
    public partial class WelcomeForm : Form, IWelcomeView
    {
        WelcomePresenter welcomePresenter;

        Color backColor, foreColor;

        //TODO Change link color on hover
        //TODO Change link color for light theme

        public WelcomeForm()
        {
            InitializeComponent();
        }

        public Color themeBackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                backColor = value;
                this.BackColor = backColor;
            }
        }
        public Color themeForeColor
        {
            get
            {
                return foreColor;
            }
            set
            {
                foreColor = value;
                this.startLabel.ForeColor = themeForeColor;
                this.recentFileLabel.ForeColor = themeForeColor;
                this.helpLabel.ForeColor = themeForeColor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            welcomePresenter = new WelcomePresenter(this);
            welcomePresenter.GetColor();
        }


        private void newFileLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            welcomePresenter.newFileLabel_LinkClicked();
        }
    }
}
