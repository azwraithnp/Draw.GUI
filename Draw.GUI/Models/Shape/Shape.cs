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
        public Point point1, point2;
        public Pen refPen;
        public Graphics canvas;
        
        public Shape(Point p1, Point p2, Pen refPen, Graphics canvas)
        {
            this.point1 = p1;
            this.point2 = p2;
            this.refPen = refPen;
            this.canvas = canvas;
        }

        public abstract void draw();
    }
}
