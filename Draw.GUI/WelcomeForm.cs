using Draw.GUI.Models;
using Draw.GUIMVP.Models;
using Draw.GUIMVP.Presenters;
using Draw.GUIMVP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Windows.Forms;

namespace Draw.GUI
{
    public partial class WelcomeForm : Form, IWelcomeView
    {
        WelcomePresenter welcomePresenter;

        Color backColor, foreColor;
        CheckBox checkBox = new ToggleCheckBox();
        UserInfo user = new UserInfo();

        public WelcomeForm()
        {
            InitializeComponent();
            checkBox.Location = new System.Drawing.Point(480, 380);

            UserInfo user = new UserInfo();
            if(user.Theme.Equals("light"))
            {
                checkBox.Checked = true;
            }
            else
            {
                checkBox.Checked = false;
            }

            
            if(user.Recentfile != null)
            {
                fileNameLabel.Text = user.Recentfile;
                fileNameLabel.Click += FileNameLabel_Click;
                fileNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(214)))));
            }

            checkBox.CheckedChanged += CheckBox_CheckedChanged;
            
            this.Controls.Add(checkBox);
        }

        private void FileNameLabel_Click(object sender, EventArgs e)
        {
            CodingForm code = new CodingForm();
            code.Show();
            code.openFileToolStripMenuItem_Click(sender, e);
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox.Checked)
            {
                user.Theme = "light";
            }
            else
            {
                user.Theme = "dark";
            }

            string jsonData = Json.Encode(user);

            using (StreamWriter file = File.CreateText("userinfo.txt"))
            {
                file.WriteLine(jsonData);
            }

            Refresh();
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
            
        }

        private void WelcomeForm_Paint(object sender, PaintEventArgs e)
        {
            welcomePresenter = new WelcomePresenter(this);
            welcomePresenter.GetColor();
        }

        private void addFolderDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
           
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
                user.Root = path;
            }
            
            string jsonData = Json.Encode(user);

            using (StreamWriter file = File.CreateText("userinfo.txt"))
            {
                file.WriteLine(jsonData);
            }
        }

        private void newFileLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            welcomePresenter.newFileLabel_LinkClicked();
        }
    }
}
