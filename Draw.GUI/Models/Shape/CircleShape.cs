using Draw.GUI.Models.Shape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class CircleShape : Shape
    {
        int radius;

        public CircleShape(Point p1, Point p2, int radius, Pen refPen, Graphics canvas) : base(p1, p2, refPen, canvas)
        {
            this.radius = radius;
        }

        public override void draw()
        {
            Rectangle rect = new Rectangle(point1.X - radius, point1.Y - radius, radius * 2, radius * 2);

            if (Counters.colorFill)
            {
                canvas.FillEllipse(new SolidBrush(refPen.Color), rect);
            }
            else
            {
                canvas.DrawEllipse(refPen, rect);
            }
        }
    }
}
