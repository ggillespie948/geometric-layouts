using GeometricLayouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeometricLayouts.Models
{
    public class TriangleLayout : IGeometricLayout
    {
        private int MaxRow { get; }
        private int MaxCol { get; }
        private int LegWidth { get; }

        public TriangleLayout(int MaxRow, int MaxCol, int LegWidth)
        {
            this.MaxRow = MaxRow;
            this.MaxCol = MaxCol;
            this.LegWidth = LegWidth;
        }

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
