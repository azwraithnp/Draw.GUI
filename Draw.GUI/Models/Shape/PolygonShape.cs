using Draw.GUI.Models.Shape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    class PolygonShape : Shape
    {
        Point[] points;

        public PolygonShape(Point p1, Point p2, Point[] points, Pen refPen, Graphics canvas) : base(p1, p2, refPen, canvas)
        {
            this.points = points;
        }

        public override void draw()
        {
            List<Point> totalPoints = points.ToList();
            totalPoints.Insert(0, point1);
            totalPoints.Insert(1, point2);
            points = totalPoints.ToArray();
            
            if(Counters.colorFill)
            {
                canvas.FillPolygon(new SolidBrush(refPen.Color), points);
            }
            else
            {
                canvas.DrawPolygon(refPen, points);
            }
            
        }
    }
}
