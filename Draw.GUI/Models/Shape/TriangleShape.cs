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
    /// creates a model class for triangle shape to be drawn during runtime,
    /// inherits the Shape model class
    /// </summary>
    class TriangleShape : Shape
    {
        Point point3;

        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="p3">third point of the shape</param>
        /// <param name="rPen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which the shape will be drawn</param>
        public TriangleShape(Point p1, Point p2, Point p3, Pen rPen, Graphics canvas) : base(p1, p2, rPen, canvas)
        {
            this.point3 = p3;
        }

        /// <summary>
        /// creates a method to draw the actual shape onto the canvas using the instance variables,
        /// draws or fills the polygon according to user preference
        /// </summary>
        public override void draw()
        {
            if(Counters.colorFill)
            {
                canvas.FillPolygon(new SolidBrush(refPen.Color), new[] { point1, point2, point3 });
            }
            else
            {
                canvas.DrawPolygon(refPen, new[] { point1, point2, point3 });
            }
        }
    }
}
