using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI.Models.Shape
{
    /// <summary>
    /// creates a model abstract class for the shapes,
    /// acts as a parent class which its subtypes can inherit from
    /// </summary>
    public abstract class Shape
    {
        public Point point1, point2;
        public Pen refPen;
        public Graphics canvas;
        
        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="refPen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which the shape will be drawn</param>
        public Shape(Point p1, Point p2, Pen refPen, Graphics canvas)
        {
            this.point1 = p1;
            this.point2 = p2;
            this.refPen = refPen;
            this.canvas = canvas;
        }

        /// <summary>
        /// creates an abstract method to draw the shapes
        /// </summary>
        public abstract void draw();
    }
}
