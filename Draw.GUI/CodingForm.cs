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
using System.Web.Helpers;
using System.Windows.Forms;

namespace Draw.GUI
{
    public partial class CodingForm : Form, ICodeView
    {
        string code, highlightMode;
        string file = "Untitled";
         
        Graphics panelCanvas = null;

        List<TextMarker> markers = new List<TextMarker>();

        CodingPresenter presenter;
        CommandValidatorPresenter validatorPresenter;
        CommandParserPresenter parserPresenter;

        int countForRECT = 0;
        int countForCIRC = 0;
        int countForArc = 0;
        int countForPie = 0;

        Point MouseDownLocation;

        Rectangle rec = new Rectangle(0, 0, 0, 0);
        List<Rectangle> rectsForRECT = new List<Rectangle>();
        List<Rectangle> rectsForCIRC = new List<Rectangle>();
        List<Rectangle> rectsForArc = new List<Rectangle>();
        List<Rectangle> rectsForPie = new List<Rectangle>();

        List<Point> anglesForArc = new List<Point>();
        List<Point> anglesForPie = new List<Point>();

        bool clicked = false;
        string toolDrawType = "none";


        public CodingForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            this.UpdateStyles();
            
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

        public GroupBox groupbox { get => this.groupBox1; set => this.groupBox1 = value; }

        public string toolBoxControl { get => this.toolDrawType; set => this.toolDrawType = value; }

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
            
            if(!toolBoxControl.Equals("none"))
            {
                foreach (Rectangle rec in rectsForRECT)
                {
                    g.FillRectangle(Brushes.DeepPink, rec);
                }

                foreach (Rectangle rec in rectsForCIRC)
                {
                    g.FillEllipse(Brushes.DeepPink, rec);
                }

                for (int i = 0; i < rectsForArc.Count; i++)
                {
                    Rectangle rec = rectsForArc[i];
                    Point point = anglesForArc[i];
                    g.DrawArc(new Pen(Color.DeepPink), rec, point.X, point.Y);
                }

                for (int i = 0; i < rectsForPie.Count; i++)
                {
                    Rectangle rec = rectsForPie[i];
                    Point point = anglesForPie[i];
                    g.FillPie(Brushes.DeepPink, rec, point.X, point.Y);
                }
            }

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
            if(GeneratedLists.errorMessages.Count==0)
            {
                foreach (TextMarker marker in markers)
                {
                    textEditorControl1.Document.MarkerStrategy.RemoveMarker(marker);
                }

                textEditorControl1.Refresh();

                markers.Clear();
                return;
            }

            foreach (ErrorMessage error in GeneratedLists.errorMessages)
            {
                Console.WriteLine(GeneratedLists.errorMessages.Count);
                int offset = error.index;
                int length = error.word.Length;
                TextMarker marker = new TextMarker(offset, length, TextMarkerType.WaveLine, Color.Red);
                textEditorControl1.Document.MarkerStrategy.AddMarker(marker);
                markers.Add(marker);
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
                clicked = true;

                parserPresenter = new CommandParserPresenter(this);
                
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
                clicked = true;
               
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
            clicked = true;

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

        public void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfo user = new UserInfo();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files | *.txt";
            if(user.Root != null)
            {
                openFileDialog.InitialDirectory = user.Root.ToString();
            }

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
                    sr.Close();
                    sr.Dispose();
                    
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Exception: " + exc.Message);
                }

                fileName = fName;
                user.Recentfile = fileName;

                string jsonData = Json.Encode(user);

                using (StreamWriter file = System.IO.File.CreateText("userinfo.txt"))
                {
                    file.WriteLine(jsonData);
                }
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

        private void colorFillDrawingObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = true;

            if (this.colorFillDrawingObjectsToolStripMenuItem.Checked)
            {
                Counters.colorFill = false;
                this.colorFillDrawingObjectsToolStripMenuItem.Checked = false;

            }
            else
            {
                Counters.colorFill = true;
                this.colorFillDrawingObjectsToolStripMenuItem.Checked = true;
            }

            Refresh();
        }

        private void clearCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = false;
            toolBoxControl = "none";
            rectangleBox.Checked = false;
            circleBox.Checked = false;
            arcBox.Checked = false;
            pieBox.Checked = false;
            Refresh();
        }

        private void rectangleBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rectangleBox.Checked)
            {
                toolBoxControl = "rectangle";
                
            }
            else
            {
                toolBoxControl = "none";
            }
        }

        private void circleBox_CheckedChanged(object sender, EventArgs e)
        {
            if(circleBox.Checked)
            {
                toolBoxControl = "circle";
                
            }
            else
            {
                toolBoxControl = "none";
            }
            
        }

        private void arcBox_CheckedChanged(object sender, EventArgs e)
        {
            if (arcBox.Checked)
            {
                toolBoxControl = "arc";
                
            }
            else
            {
                toolBoxControl = "none";
            }
        }

        private void pieBox_CheckedChanged(object sender, EventArgs e)
        {
            if (pieBox.Checked)
            {
                toolBoxControl = "pie";
                
            }
            else
            {
                toolBoxControl = "none";
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!toolBoxControl.Equals("none"))
            {
                
                if (e.Button == MouseButtons.Left)
                {
                    rec = new Rectangle(e.X, e.Y, 0, 0);
                    if (toolBoxControl.Equals("rectangle"))
                    {
                        rectsForRECT.Add(rec);
                        countForRECT++;

                    }
                    else if (toolBoxControl.Equals("circle"))
                    {
                        rectsForCIRC.Add(rec);
                        countForCIRC++;
                    }
                    else if (toolBoxControl.Equals("arc"))
                    {
                        rec = new Rectangle(e.X, e.Y, 200, 100);
                        rectsForArc.Add(rec);

                        anglesForArc.Add(new Point(0, 0));

                        countForArc++;
                    }
                    else if (toolBoxControl.Equals("pie"))
                    {
                        rec = new Rectangle(e.X, e.Y, 200, 100);
                        rectsForPie.Add(rec);

                        anglesForPie.Add(new Point(0, 0));

                        countForPie++;
                    }
                    Refresh();
                }
                if (e.Button == MouseButtons.Right)
                {
                    MouseDownLocation = e.Location;
                    Refresh();
                }
            }

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(!toolBoxControl.Equals("none"))
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (toolBoxControl.Equals("rectangle"))
                    {
                        rec.Width = e.X - rec.X;
                        rec.Height = e.Y - rec.Y;

                        rectsForRECT[countForRECT - 1] = rec;
                    }
                    else if (toolBoxControl.Equals("circle"))
                    {
                        rec.Width = e.X - rec.X;
                        rec.Height = e.Y - rec.Y;

                        rectsForCIRC[countForCIRC - 1] = rec;
                    }
                    else if (toolBoxControl.Equals("arc"))
                    {
                        int starta = e.X - rec.X;
                        int sweepa = e.Y - rec.Y;

                        anglesForArc[countForArc - 1] = new Point(starta, sweepa);

                    }
                    else if (toolBoxControl.Equals("pie"))
                    {
                        int starta = e.X - rec.X;
                        int sweepa = e.Y - rec.Y;

                        anglesForPie[countForPie - 1] = new Point(starta, sweepa);
                    }

                    Refresh();

                }

                if (e.Button == MouseButtons.Right)
                {
                    rec.Location = new Point((e.X - MouseDownLocation.X) + rec.Left, (e.Y - MouseDownLocation.Y) + rec.Top);
                    MouseDownLocation = e.Location;

                    if (toolBoxControl.Equals("rectangle"))
                    {
                        rectsForRECT[countForRECT - 1] = rec;
                    }
                    else if (toolBoxControl.Equals("circle"))
                    {
                        rectsForCIRC[countForCIRC - 1] = rec;
                    }
                    else if (toolBoxControl.Equals("arc"))
                    {
                        rectsForArc[countForArc - 1] = rec;
                    }
                    else if (toolBoxControl.Equals("pie"))
                    {
                        rectsForPie[countForPie - 1] = rec;
                    }

                    Refresh();
                }
            }
                
        }
        

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fileName.Equals("Untitled"))
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Text Files | *.txt";
                dialog.DefaultExt = "txt";

                if (dialog.ShowDialog() == DialogResult.OK)
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

            
            else
            {
                code = textEditorControl1.Text;

                System.IO.File.Delete(fileName);
                StreamWriter sw = new StreamWriter(fileName);
                Console.WriteLine(editorCode);
                foreach (string lineString in code.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    sw.WriteLine(lineString);
                }
                sw.Flush();
                sw.Close();
                
            }



        }

    }

}
