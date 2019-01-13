using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI.Models.Shape
{
    /// <summary>
    /// creates a model class for bezier shape to be drawn during runtime,
    /// inherits the Shape model class
    /// </summary>
    class BezierShape : Shape
    {
        Point p3, p4;

        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="p3">third point of the shape</param>
        /// <param name="p4">fourth point of the shape</param>
        /// <param name="refPen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which the shape will be drawn</param>
        public BezierShape(Point p1, Point p2, Point p3, Point p4, Pen refPen, Graphics canvas) : base(p1, p2, refPen, canvas)
        {
            this.p3 = p3;
            this.p4 = p4;
        }

        /// <summary>
        /// creates a method to draw the actual shape onto the canvas using the instance variables
        /// </summary>
        public override void draw()
        {
            canvas.DrawBezier(refPen, point1, point2, p3, p4);
        }
    }
}
