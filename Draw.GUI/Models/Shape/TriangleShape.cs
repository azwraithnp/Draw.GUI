using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI.Models.Shape
{
    class TriangleShape : Shape
    {
        Point point3;

        public TriangleShape(Point p1, Point p2, Point p3, Pen rPen, Graphics canvas) : base(p1, p2, rPen, canvas)
        {
            this.point3 = p3;
        }

        public override void draw()
        {
            canvas.DrawPolygon(refPen, new[] { point1, point2, point3 });
        }
    }
}
