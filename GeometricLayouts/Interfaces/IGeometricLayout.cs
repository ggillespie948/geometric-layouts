using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeometricLayouts.Interfaces
{
    public interface IGeometricLayout
    {
        IEnumerable<IShape> GenerateLayout();
        IShape GenerateShapeFromId(string id);
    }
}
