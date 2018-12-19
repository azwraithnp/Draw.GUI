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
    public partial class CodingForm : Form
    {
        public CodingForm()
        {
            InitializeComponent();

            //Creates a FileSyntaxModeProvider object to provide binary for the color syntaxing
            FileSyntaxModeProvider fsmp;

            //Provide directory path for fsmp object
            string dirc = Application.StartupPath;

            //Checks if the provided directory path exists
            if (Directory.Exists(dirc))
            {
                //Initialize the fsmp object with the provided directory path
                fsmp = new FileSyntaxModeProvider(dirc);

                /*Pass the fsmp object created as argument for the sytanxmodefileprovider 
                 * of highlightingmanager of the texteditor */
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
            }

            //Set syntax highlighting mode to be C#
            textEditorControl1.SetHighlighting("draw.gui");

            textEditorControl1.Text = "!this is a single line comment" + "\n" + "!write down your code below";

            //int offset = 5;
            //int length = 5;
            //TextMarker marker = new TextMarker(offset, length, TextMarkerType.WaveLine, Color.Red);
            //textEditorControl1.Document.MarkerStrategy.AddMarker(marker);

            textEditorControl1.BackColor = System.Drawing.Color.Black;

        }

        private void buildToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new CommandParser(textEditorControl1.Text);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
