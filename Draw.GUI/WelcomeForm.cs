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
    /// <summary>
    /// creates a form to welcome the user to the application
    /// inherits Form and IWelcomeView interface
    /// </summary>
    public partial class WelcomeForm : Form, IWelcomeView
    {
        WelcomePresenter welcomePresenter;

        Color backColor, foreColor;
        CheckBox checkBox = new ToggleCheckBox();
        UserInfo user = new UserInfo();

        /// <summary>
        /// constructor for welcome form that initializes the properties and variablesS
        /// </summary>
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

        /// <summary>
        /// creates a click handler method for filename label on the welcome form
        /// </summary>
        /// <param name="sender">obligated sender object parameter</param>
        /// <param name="e">obligated event arguments parameter</param>
        private void FileNameLabel_Click(object sender, EventArgs e)
        {
            string fName = user.Recentfile;
            string fileCode = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fName);

                //Read the first line of text
                string line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    fileCode = fileCode + line + Environment.NewLine;

                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                sr.Dispose();

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
            }

            Console.WriteLine(fileCode);

            CodingForm form = new CodingForm(fileCode);
            form.Show();
        }

        /// <summary>
        /// creates a checked changed handler method for the theme checkbox
        /// </summary>
        /// <param name="sender">obligated sender object parameter</param>
        /// <param name="e">obligated event arguments parameter</param>
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
        
        /// <summary>
        /// background color of this form to be used by the presenter class for this form
        /// </summary>
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

        /// <summary>
        /// fore color of this form to be used by the presenter class for this form
        /// </summary>
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

        /// <summary>
        /// paint handle for this form where we call the presenter class to set the theme properties 
        /// </summary>
        /// <param name="sender">obligated sender object parameter</param>
        /// <param name="e">obligated paint event arguments parameter</param>
        private void WelcomeForm_Paint(object sender, PaintEventArgs e)
        {
            welcomePresenter = new WelcomePresenter(this);
            welcomePresenter.GetColor();
        }

        /// <summary>
        /// link clicked handle for the add folder label in the welcome form
        /// </summary>
        /// <param name="sender">obligated sender object parameter</param>
        /// <param name="e">obligated link label link clicked event arguments</param>
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

        /// <summary>
        /// link clicked handle for github repository label in the welcome form
        /// </summary>
        /// <param name="sender">obligated sender object parameter</param>
        /// <param name="e">obligated link label clicked event arguments</param>
        private void repoLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/azwraithnp/Draw.GUI");
        }

        /// <summary>
        /// link clicked handle for keywords and syntax label in the welcome form
        /// </summary>
        /// <param name="sender">obligated sender object parameter</param>
        /// <param name="e">obligated link label clicked event arguments</param>
        private void keywordsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/azwraithnp/Draw.GUI/blob/master/README.md");
        }

        /// <summary>
        /// link clicked handle to open new file and load it into coding form
        /// </summary>
        /// <param name="sender">obligated sender object parameter</param>
        /// <param name="e">obligated link label clicked event arguments</param>
        private void openFileLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CodingForm form = new CodingForm("");
            form.Show();
            form.openFileToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        /// link clicked handle to open xml file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmldocLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/azwraithnp/Draw.GUI/blob/master/Draw.GUI.xml");
        }

        /// <summary>
        /// link clicked handle for the new file label in the welcome form
        /// </summary>
        /// <param name="sender">obligated sender object parameter</param>
        /// <param name="e">obligated link label link clicked event arguments</param>
        private void newFileLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CodingForm codingForm = new CodingForm("");
            codingForm.Show();
        }
    }
}
