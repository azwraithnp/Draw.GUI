﻿using Draw.GUI.Models.Shape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI
{
    /// <summary>
    /// creates a model class for pie shape to be drawn during runtime,
    /// inherits the Shape model class
    /// </summary>
    class PieShape : Shape
    {
        int Height, Width, startAngle, sweepAngle;

        /// <summary>
        /// creates a constructor to initialize the instance variables
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="height">height of the rectangle to be used</param>
        /// <param name="width">width of the rectangle to be used</param>
        /// <param name="startAngle">start angle of the pie</param>
        /// <param name="sweepAngle">sweep angle of the pie</param>
        /// <param name="refPen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which the shape will be drawn</param>
        public PieShape(Point p1, Point p2, int height, int width, int startAngle, int sweepAngle, Pen refPen, Graphics canvas) : base(p1, p2, refPen, canvas)
        {
            this.Height = height;
            this.Width = width;
            this.startAngle = startAngle;
            this.sweepAngle = sweepAngle;
        }

        /// <summary>
        /// creates a method to draw the actual shape onto the canvas using the instance variables,
        /// using the instance variables to fill pie or draw pie according to user preference
        /// </summary>
        public override void draw()
        {
            if(Counters.colorFill)
            {
                canvas.FillPie(new SolidBrush(refPen.Color), point1.X, point1.Y, Width, Height, startAngle, sweepAngle);
            }
            else
            {
                canvas.DrawPie(refPen, point1.X, point1.Y, Width, Height, startAngle, sweepAngle);
            }

        }
    }
}
