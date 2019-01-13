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
    /// creates a model class for circle shape to be drawn during runtime,
    /// inherits the Shape model class
    /// </summary>
    class CircleShape : Shape
    {
        int radius;

        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="radius">radius of the circle</param>
        /// <param name="refPen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which the shape will be drawn</param>
        public CircleShape(Point p1, Point p2, int radius, Pen refPen, Graphics canvas) : base(p1, p2, refPen, canvas)
        {
            this.radius = radius;
        }

        /// <summary>
        /// creates a method to draw the actual shape onto the canvas using the instance variables,
        /// creates a rectangle object using the instance variables,
        /// using the rectangle object to fill ellipse or draw ellipse according to user preference
        /// </summary>
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
