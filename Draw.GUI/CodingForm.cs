using Draw.GUI.Presenters;
using Draw.GUIMVP.Models;
using Draw.GUIMVP.Presenters;
using Draw.GUIMVP.Views;
using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUI
{
    public partial class CodingForm : Form, ICodeView
    {
        string code, highlightMode;

        Graphics panelCanvas = null;
        
        CodingPresenter presenter;
        CommandValidatorPresenter validatorPresenter;
        CommandParserPresenter parserPresenter;

        bool clicked = false;

        public CodingForm()
        {
            
            InitializeComponent();

            presenter = new CodingPresenter(this);
            presenter.highlightHandlers();

            presenter.setViewProperties();

            //Set syntax highlighting mode to be Draw.GUI according to theme
            textEditorControl1.SetHighlighting(highlightMode);


            textEditorControl1.Text = "!this is a single line comment" + Environment.NewLine + "!write down your code below";

            //int offset = 5;
            //int length = 5;
            //TextMarker marker = new TextMarker(offset, length, TextMarkerType.WaveLine, Color.Red);
            //textEditorControl1.Document.MarkerStrategy.AddMarker(marker);


        }

        public ListView ListView { get => listView1;  set => listView1 = value; }

        public string editorCode { get => code;  set => code = value;  }

        public Color backColor { get => this.BackColor;  set => this.BackColor = value;  }

        public MenuStrip MenuStrip { get => this.menuStrip1;  set => this.menuStrip1 = value; }

        public string HighlightMode { get => this.highlightMode;  set => this.highlightMode = value;  }

        public Graphics canvas { get => this.panelCanvas; set => this.panelCanvas = value; }

        private void buildToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            code = textEditorControl1.Text;

            validatorPresenter = new CommandValidatorPresenter(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            canvas = g;
            
            if(clicked)
            {
                clicked = false;
                parserPresenter.parseCode();
            }
            
        }

        private void runCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            code = textEditorControl1.Text;

            validatorPresenter = new CommandValidatorPresenter(this);

            if (GeneratedLists.errorMessages.Count == 0 && GeneratedLists.goodToRun)
            {
                clicked = true;
                parserPresenter = new CommandParserPresenter(this);
            }
            else
            {
                if(!(GeneratedLists.errorMessages.Count == 0))
                {
                    MessageBox.Show("Please fix the bugs and/or errors before running the code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Refresh();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }

}
