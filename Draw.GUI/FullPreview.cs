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

        public FullPreview(string code, string file)
        {
            InitializeComponent();
            this.code = code;
            this.file = file;
            this.Text = file;

            UserInfo user = new UserInfo();
            if(user.Theme.Equals("light"))
            {
                backColor = Colors.themeLightColor;
            }
            else
            {
                backColor = Colors.themeDarkColor;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if(Counters.showGrid)
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
    }
}
