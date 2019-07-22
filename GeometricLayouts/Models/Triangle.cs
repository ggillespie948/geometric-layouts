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

        public Point V1 { get; private set; }
        public Point V2 { get; private set; }
        public Point V3 { get; private set; }

        public Triangle(string Id, int V1x, int V1y, int V2x, int V2y, int V3x, int V3y)
        {
            this.Id = Id;
            this.V1 = new Point(V1x, V1y);
            this.V1 = new Point(V2x, V3y);
            this.V1 = new Point(V3x, V3y);
        }

        public string VerticesToString => throw new NotImplementedException();
    }
}
