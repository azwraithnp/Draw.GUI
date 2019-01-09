using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI.Models.Shape
{
    class CircleShape : Shape
    {
        int radius;

        public CircleShape(int x, int y, int radius, Pen refPen, Graphics canvas) : base(x, y, refPen, canvas)
        {
            this.radius = radius;
        }

        public override void draw()
        {
            Rectangle rect = new Rectangle(PointX - radius, PointY - radius, radius * 2, radius * 2);
            canvas.DrawEllipse(refPen, rect);
        }
    }
}
