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
    /// creates a model class for rectangle shape to be drawn during runtime,
    /// inherits the Shape model class
    /// </summary>
    class RectangleShape : Shape
    {
        int Height, Width;

        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="height">height of the shape</param>
        /// <param name="width">width of the shape</param>
        /// <param name="pen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which shape will be drawn</param>
        public RectangleShape(Point p1, Point p2, int height, int width, Pen pen, Graphics canvas) : base(p1, p2, pen, canvas)
        {
            this.Height = height;
            this.Width = width;
        }

        /// <summary>
        /// creates a method to draw the actual shape onto the canvas using the instance variables,
        /// fills or draws the rectangle according to user preference
        /// </summary>
        public override void draw()
        {
            if(Counters.colorFill)
            {
                canvas.FillRectangle(new SolidBrush(refPen.Color), point1.X, point1.Y, Width, Height);
            }
            else
            {
                canvas.DrawRectangle(refPen, point1.X, point1.Y, Width, Height);
            }
            
        }
    }
}
