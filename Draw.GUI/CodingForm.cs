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
using System.Drawing.Imaging;
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
        string file = "Untitled";
         
        Graphics panelCanvas = null;
        
        CodingPresenter presenter;
        CommandValidatorPresenter validatorPresenter;
        CommandParserPresenter parserPresenter;

        bool clicked = false;

        public CodingForm()
        {
            InitializeComponent();

            resources = new System.ComponentModel.ComponentResourceManager(typeof(CodingForm));

            presenter = new CodingPresenter(this);
            presenter.highlightHandlers();
            
            presenter.setViewProperties();

            //Set syntax highlighting mode to be Draw.GUI according to theme
            textEditorControl1.SetHighlighting(highlightMode);
            
            textEditorControl1.Text = "!this is a single line comment" + Environment.NewLine + "!write down your code below";
            
        }

        public ListView ListView { get => listView1;  set => listView1 = value; }

        public string editorCode { get => code;  set { this.code = value; textEditorControl1.Text = value; }  }

        public Color backColor { get => this.BackColor;  set => this.BackColor = value;  }

        public MenuStrip MenuStrip { get => this.menuStrip1;  set => this.menuStrip1 = value; }

        public string HighlightMode { get => this.highlightMode;  set => this.highlightMode = value;  }

        public Graphics canvas { get => this.panelCanvas; set => this.panelCanvas = value; }

        public string fileName { get => this.file; set { this.file = value; this.Text = file; } }

        public Button newPage { get => this.button1; set => this.button1 = value; }

        public ComponentResourceManager resource { get => this.resources; set => this.resources = value; }

        private void buildToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            code = textEditorControl1.Text;

            validatorPresenter = new CommandValidatorPresenter(this);

            errorHighlighting();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            canvas = g;

            if(Counters.showGrid)
            {
                drawGrid(g);
            }
            
            if (clicked)
            {
                clicked = false;
                parserPresenter.parseCode();
            }
            
        }

        public void drawGrid(Graphics g)
        {
            int numOfCells = 200;
            int cellSize = 10;
            Pen p = new Pen(Color.Gray);

            for (int y = 0; y < numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }

        public void errorHighlighting()
        {
            foreach(ErrorMessage error in GeneratedLists.errorMessages)
            {
                Console.WriteLine(GeneratedLists.errorMessages.Count);
                int offset = error.index;
                int length = error.word.Length;
                TextMarker marker = new TextMarker(offset, length, TextMarkerType.WaveLine, Color.Red);
                textEditorControl1.Document.MarkerStrategy.AddMarker(marker);
                
            }

            textEditorControl1.Refresh();
        }

        private void runCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            code = textEditorControl1.Text;

            validatorPresenter = new CommandValidatorPresenter(this);

            errorHighlighting();

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

        private void button1_Click(object sender, EventArgs e)
        {
            code = textEditorControl1.Text;

            validatorPresenter = new CommandValidatorPresenter(this);

            errorHighlighting();

            if (GeneratedLists.errorMessages.Count == 0 && GeneratedLists.goodToRun)
            {
                FullPreview full = new FullPreview(editorCode, fileName);
                full.Show();
            }
            else
            {
                if (!(GeneratedLists.errorMessages.Count == 0))
                {
                    MessageBox.Show("Please fix the bugs and/or errors before running the code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }

        private void showOutputInFullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            code = textEditorControl1.Text;

            validatorPresenter = new CommandValidatorPresenter(this);

            if (GeneratedLists.errorMessages.Count == 0 && GeneratedLists.goodToRun)
            {
                FullPreview full = new FullPreview(editorCode, fileName);
                full.Show();
            }
            else
            {
                if (!(GeneratedLists.errorMessages.Count == 0))
                {
                    MessageBox.Show("Please fix the bugs and/or errors before running the code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void showGridlinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.showGridlinesToolStripMenuItem.Checked)
            {
                Counters.showGrid = false;
                this.showGridlinesToolStripMenuItem.Checked = false;
            }
            else
            {
                Counters.showGrid = true;
                this.showGridlinesToolStripMenuItem.Checked = true;
            }

            Refresh();
        }

        private void saveAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Image Files(*.bmp, *.jpg)|*.bmp;*.jpg;*.png";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FullPreview full = new FullPreview(editorCode, fileName);
                full.saveImage(dialog.FileName);
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files | *.txt";

            string fileCode = "";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog.FileName;
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
                    
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Exception: " + exc.Message);
                }

                fileName = fName;
            }
            
            editorCode = fileCode;
            
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WelcomeForm welcome = new WelcomeForm();
            welcome.Show();
        }

        private void closeWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text Files | *.txt";
            dialog.DefaultExt = "txt";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream fileStream = dialog.OpenFile();
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fileStream);
                foreach (string lineString in editorCode.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    sw.WriteLine(lineString);
                }
                sw.Flush();
                sw.Close();

                fileName = dialog.FileName;
            }



        }

    }

}
