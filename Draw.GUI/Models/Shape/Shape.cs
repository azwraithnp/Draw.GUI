using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI.Models.Shape
{
    public abstract class Shape
    {
        public int PointX, PointY;
        public Pen refPen;
        public Graphics canvas;
        
        public Shape(int x, int y, Pen refPen, Graphics canvas)
        {
            this.PointX = x;
            this.PointY = y;
            this.refPen = refPen;
            this.canvas = canvas;
        }

        public abstract void draw();
    }
}
