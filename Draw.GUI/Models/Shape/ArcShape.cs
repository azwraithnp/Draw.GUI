using Draw.GUI.Models.Shape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class ArcShape : Shape
    {
        int Height, Width, startAngle, sweepAngle;

        public ArcShape(Point p1, Point p2, int height, int width, int startAngle, int sweepAngle, Pen refPen, Graphics canvas) : base(p1, p2, refPen, canvas)
        {
            this.Height = height;
            this.Width = width;
            this.startAngle = startAngle;
            this.sweepAngle = sweepAngle;
        }

        public override void draw()
        {
            canvas.DrawArc(refPen, point1.X, point1.Y, Width, Height, startAngle, sweepAngle);
        }
    }
}
