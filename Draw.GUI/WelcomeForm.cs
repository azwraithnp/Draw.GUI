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
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
            this.BackColor = col;

          

        }

        private void newFileLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CodingForm codingForm = new CodingForm();
            codingForm.Show();
        }
    }
}
