using Draw.GUI.Models.Shape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    /// <summary>
    /// creates a model class for polygon shape to be drawn during runtime,
    /// inherits the Shape model class
    /// </summary>
    class PolygonShape : Shape
    {
        Point[] points;

        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="points">remaining array of points for the polygon</param>
        /// <param name="refPen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which shape will be drawn</param>
        public PolygonShape(Point p1, Point p2, Point[] points, Pen refPen, Graphics canvas) : base(p1, p2, refPen, canvas)
        {
            this.points = points;
        }

        /// <summary>
        /// creates a method to draw the actual shape onto the canvas using the instance variables,
        /// creates a list of points using the first point and second point along with the remaining array of points,
        /// converts it to array and passes it to the drawing method,
        /// fills the polygon or draws the polygon according to user preferenceS
        /// </summary>
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
