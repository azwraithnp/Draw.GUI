using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUI.Models.Shape
{
    /// <summary>
    /// creates a model factory class to manage and return the specific shape required by the program
    /// </summary>
    class ShapeFactory
    {
        /// <summary>
        /// creates a method to get a rectangle shape
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="height">height of the shape</param>
        /// <param name="width">width of the shape</param>
        /// <param name="pen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which the shape will be drawn</param>
        /// <returns></returns>
        public Shape getRectangleShape(Point p1, Point p2, int height, int width, Pen pen, Graphics canvas)
        {
            return new RectangleShape(p1, p2, height, width, pen, canvas);
        }

        /// <summary>
        /// creates a method to get a circle shape
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="radius">radius of the circle</param>
        /// <param name="pen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which the shape will be drawn</param>
        /// <returns></returns>
        public Shape getCircleShape(Point p1, Point p2, int radius, Pen pen, Graphics canvas)
        {
            return new CircleShape(p1, p2, radius, pen, canvas);
        }

        /// <summary>
        /// creates a method to get a triangle shape
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="p3">third point of the shape</param>
        /// <param name="pen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which the shape will be drawn</param>
        /// <returns></returns>
        public Shape getTriangleShape(Point p1, Point p2, Point p3, Pen pen, Graphics canvas)
        {
            return new TriangleShape(p1, p2, p3, pen, canvas);
        }

        /// <summary>
        /// creates a method to get a polygon shape
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="points">remaining array of points for the shape</param>
        /// <param name="pen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which the shape will be drawn</param>
        /// <returns></returns>
        public Shape getPolygonShape(Point p1, Point p2, Point[] points, Pen pen, Graphics canvas)
        {
            return new PolygonShape(p1, p2, points, pen, canvas);
        }

        /// <summary>
        /// creates a method to get an arc shape
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="height">height of the rectangle to be used</param>
        /// <param name="width">width of the rectangle to be used</param>
        /// <param name="startAngle">start angle of the arc</param>
        /// <param name="sweepAngle">sweep angle of the arc</param>
        /// <param name="pen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which the shape will be drawn</param>
        /// <returns></returns>
        public Shape getArcShape(Point p1, Point p2, int height, int width, int startAngle, int sweepAngle, Pen pen, Graphics canvas)
        {
            return new ArcShape(p1, p2, height, width, startAngle, sweepAngle, pen, canvas);
        }

        /// <summary>
        /// creates a method to get a pie shape
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="height">height of the rectangle to be used</param>
        /// <param name="width">width of the rectangle to be used</param>
        /// <param name="startAngle">start angle of the pie</param>
        /// <param name="sweepAngle">sweep angle of the pie</param>
        /// <param name="pen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which the shape will be drawn</param>
        /// <returns></returns>
        public Shape getPieShape(Point p1, Point p2, int height, int width, int startAngle, int sweepAngle, Pen pen, Graphics canvas)
        {
            return new PieShape(p1, p2, height, width, startAngle, sweepAngle, pen, canvas);
        }

        /// <summary>
        /// creates a method to get a bezier shape
        /// </summary>
        /// <param name="p1">first point of the shape</param>
        /// <param name="p2">second point of the shape</param>
        /// <param name="p3">third point of the shape</param>
        /// <param name="p4">fourth point of the shape</param>
        /// <param name="pen">pen used to draw the shape</param>
        /// <param name="canvas">graphics object on which the shape will be drawn</param>
        /// <returns></returns>
        public Shape getBezierShape(Point p1, Point p2, Point p3, Point p4, Pen pen, Graphics canvas)
        {
            return new BezierShape(p1, p2, p3, p4, pen, canvas);
        }
    }
}
