﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI.Models.Shape
{
    class RectangleShape : Shape
    {
        int Height, Width;
        
        public RectangleShape(Point p1, Point p2, int height, int width, Pen pen, Graphics canvas) : base(p1, p2, pen, canvas)
        {
            this.Height = height;
            this.Width = width;
        }
        
        public override void draw()
        {
            Pen obj = new Pen(Color.Red, 5);
            canvas.DrawRectangle(refPen, point1.X, point1.Y, Width, Height);
        }
    }
}