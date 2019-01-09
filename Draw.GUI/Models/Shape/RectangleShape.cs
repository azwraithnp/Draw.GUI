using System;
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
        
        public RectangleShape(int x, int y, int height, int width, Pen pen, Graphics canvas) : base(x, y, pen, canvas)
        {
            this.Height = height;
            this.Width = width;
        }
        
        public override void draw()
        {
            Pen obj = new Pen(Color.Red, 5);
            Console.WriteLine("Pontx : " + PointX + "Pointy : " + PointY + "Width : " + Width + "Height : " + Height);
            canvas.DrawRectangle(refPen, PointX, PointY, Width, Height);
        }
    }
}
