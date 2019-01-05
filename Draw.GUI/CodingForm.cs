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

        CodingPresenter presenter;
        CommandParserPresenter parserPresenter;

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

        public ListView ListView { get { return listView1; } set { listView1 = value; } }

        public string editorCode { get { return code; } set { code = value; } }

        public Color backColor { get { return this.BackColor; } set { this.BackColor = value; } }

        public MenuStrip MenuStrip { get { return this.menuStrip1; } set { this.menuStrip1 = value; } }

        public string HighlightMode { get { return this.highlightMode; } set { this.highlightMode = value; } }

        private void buildToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            code = textEditorControl1.Text;

            parserPresenter = new CommandParserPresenter(this);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }

}
