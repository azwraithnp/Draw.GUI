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
        public Shape getRectangleShape(Point p1, Point p2, int height, int width, Pen pen, Graphics canvas)
        {
            return new RectangleShape(p1, p2, height, width, pen, canvas);
        }

        public Shape getCircleShape(Point p1, Point p2, int radius, Pen pen, Graphics canvas)
        {
            return new CircleShape(p1, p2, radius, pen, canvas);
        }

        public Shape getTriangleShape(Point p1, Point p2, Point p3, Pen pen, Graphics canvas)
        {
            return new TriangleShape(p1, p2, p3, pen, canvas);
        }

        public Shape getPolygonShape(Point p1, Point p2, Point[] points, Pen pen, Graphics canvas)
        {
            return new PolygonShape(p1, p2, points, pen, canvas);
        }

        public Shape getArcShape(Point p1, Point p2, int height, int width, int startAngle, int sweepAngle, Pen pen, Graphics canvas)
        {
            return new ArcShape(p1, p2, height, width, startAngle, sweepAngle, pen, canvas);
        }

        public Shape getPieShape(Point p1, Point p2, int height, int width, int startAngle, int sweepAngle, Pen pen, Graphics canvas)
        {
            return new PieShape(p1, p2, height, width, startAngle, sweepAngle, pen, canvas);
        }

        public Shape getBezierShape(Point p1, Point p2, Point p3, Point p4, Pen pen, Graphics canvas)
        {
            return new BezierShape(p1, p2, p3, p4, pen, canvas);
        }
    }
}
