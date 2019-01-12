using Draw.GUIMVP.Models;
using Draw.GUIMVP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUI.Presenters
{
    public partial class FullPreview : Form, ICodeView
    {
        string file;
        string code = "";
        Graphics panelCanvas;

        CommandParserPresenter presenter;

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
        
        string toolDrawType = "none";

        public FullPreview(string code, string file)
        {
            InitializeComponent();
            this.code = code;
            this.file = file;
            this.Text = file;

            this.StartPosition = FormStartPosition.CenterScreen;

            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            this.UpdateStyles();

            UserInfo user = new UserInfo();
            if(user.Theme.Equals("light"))
            {
                backColor = Colors.themeLightColor;
                groupBox1.ForeColor = Colors.themeDarkColor;
            }
            else
            {
                backColor = Colors.themeDarkColor;
                groupBox1.ForeColor = Colors.themeLightColor;
            }
        }

        public string HighlightMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string editorCode { get => this.code; set => this.code = value; }
        public string fileName { get => this.file; set => this.file=value; }
        public ListView ListView { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Color backColor { get => this.BackColor; set => this.BackColor = value; }
        public MenuStrip MenuStrip { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Graphics canvas { get => this.panelCanvas; set => this.panelCanvas = value; }
        public Button newPage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ComponentResourceManager resource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public GroupBox groupbox { get => this.groupBox1; set => this.groupBox1 = value; }
        public string toolBoxControl { get => this.toolDrawType; set => this.toolDrawType = value; }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (!toolBoxControl.Equals("none"))
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

            if (Counters.showGrid)
            {
                drawGrid(g);
            }

            canvas = g;

            presenter = new CommandParserPresenter(this);
            presenter.parseCode();
            
        }

        public void saveImage(string dialogFile)
        {
            var bitmap = new Bitmap(panel1.Width, panel1.Height, PixelFormat.Format24bppRgb);
            using (var gr = Graphics.FromImage(bitmap))
            {
                gr.CopyFromScreen(panel1.PointToScreen(new Point(0, 0)), new Point(0, 0), panel1.Size);
            }
            bitmap.Save(dialogFile, ImageFormat.Png);
            bitmap.Dispose();
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
            if (!toolBoxControl.Equals("none"))
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
            if (circleBox.Checked)
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
    }
}
