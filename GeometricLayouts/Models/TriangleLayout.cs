using GeometricLayouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeometricLayouts.Models
{
    public class TriangleLayout : IGeometricLayout
    {
        public IEnumerable<IShape> GenerateLayout()
        {
            throw new NotImplementedException();
        }

        public IShape GenerateShapeFromId(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
