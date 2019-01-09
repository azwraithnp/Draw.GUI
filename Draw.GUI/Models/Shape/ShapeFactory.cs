using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI.Models.Shape
{
    class ShapeFactory
    {
        public Shape getRectangleShape(int x, int y, int height, int width, Pen pen, Graphics canvas)
        {
            return new RectangleShape(x, y, height, width, pen, canvas);
        }

        public Shape getCircleShape(int x, int y, int radius, Pen pen, Graphics canvas)
        {
            return new CircleShape(x, y, radius, pen, canvas);
        }


    }
}
