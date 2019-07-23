using GeometricLayouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace GeometricLayouts.Models
{
    public class Triangle : IShape
    {
        public string Id { get; private set; }

        /// <summary>
        /// The right angle vertex in the triangle
        /// </summary>
        public Point V1 { get; private set; }

        /// <summary>
        /// The upper left vertex of the triangle
        /// </summary>
        public Point V2 { get; private set; }

        /// <summary>
        /// The lower right vertex of the triangle
        /// </summary>
        public Point V3 { get; private set; }

        private int LegLength { get; set; }

        public Triangle(string id, int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            this.Id = id;
            this.V1 = new Point(v1x, v1y);
            this.V2 = new Point(v2x, v2y);
            this.V3 = new Point(v3x, v3y);
        }

        /// <summary>
        /// Given the x+y posiiton of a given sqaure on the grid, calculate either of the 
        /// right-angled triangles inside of that square (lower or upper)
        /// </summary>
        /// <param name="X1"></param>
        /// <param name="Y1"></param>
        /// <param name="LegLength"></param>
        public Triangle(string id, int x1, int y1, int legLength, bool lowerSection)
        {
            this.Id = id;
            this.LegLength = legLength;

            this.V1 = CalculateRightAngleVertex(lowerSection, x1, y1);
            this.V3 = CalculateLowerVertex(lowerSection);
            this.V2 = CalculateUpperVertex(lowerSection);
        }

        private Point CalculateRightAngleVertex(bool lowerSection, int x, int y)
        {
            if (lowerSection)
            {
                if (x == 0 && y == 0)
                    return new Point(x, y + this.LegLength - 1);
                else if (y == 0)
                    return new Point(x - 1, y + this.LegLength - 1);
                else if (x == 0)
                    return new Point(x, y + this.LegLength - 1);
                else
                    return new Point(x - 1, y + this.LegLength - 1);
            }
            else //upper section
            {
                if (x == 0 && y == 0)
                    return new Point(x + this.LegLength - 1, y);
                else if (x == 0)
                    return new Point(x + this.LegLength - 1, y - 1);
                else if (y == 0)
                    return new Point(x + this.LegLength - 1, y);
                else
                    return new Point(x + this.LegLength - 1, y - 1);
            }
        }

        private Point CalculateLowerVertex(bool lowerSection)
        {
            if (V1 == null)
            {
                throw new Exception("Error: Right Angle Vertex has not been set!");
            }

            if (lowerSection)
                if (V1.X == 0)
                    return new Point(V1.X - 1 + this.LegLength, V1.Y);
                else
                    return new Point(V1.X + this.LegLength, V1.Y);
            else
                if (V1.Y == 0)
                    return new Point(V1.X, V1.Y + this.LegLength - 1);
                else
                    return new Point(V1.X, V1.Y + this.LegLength);
        }


        private Point CalculateUpperVertex(bool lowerCongruent)
        {
            if (V1 == null)
            {
                throw new Exception("Error: Right Angle Vertex has not been set!");
            }

            if (lowerCongruent)
                if (V1.Y == 9)
                    return new Point(V1.X, V1.Y - (this.LegLength - 1));
                else
                    return new Point(V1.X, V1.Y - this.LegLength);
            else
                if (V1.X == 9)
                    return new Point(V1.X - (this.LegLength - 1), V1.Y);
                else
                    return new Point(V1.X - this.LegLength, V1.Y);
        }

        public string VerticesToString
        {
            get
            {
                return string.Format("V1: {0}, V2: {1}, V3: {2}", V1.ToString(), V2.ToString(), V3.ToString());
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Triangle triangle &&
                   Id == triangle.Id &&
                   V1.Equals(triangle.V1) &&
                   V2.Equals(triangle.V2) &&
                   V3.Equals(triangle.V3);
        }
    }
}
