using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI.Models.Shape
{
    class BezierShape : Shape
    {
        Point p3, p4;

        public BezierShape(Point p1, Point p2, Point p3, Point p4, Pen refPen, Graphics canvas) : base(p1, p2, refPen, canvas)
        {
            this.p3 = p3;
            this.p4 = p4;
        }

        public override void draw()
        {
            canvas.DrawBezier(refPen, point1, point2, p3, p4);
        }
    }
}
