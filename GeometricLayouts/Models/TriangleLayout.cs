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
        private int LegLength { get; }

        public TriangleLayout(int maxRow, int maxCol, int legLength)
        {
            this.MaxRow = maxRow;
            this.MaxCol = maxCol;
            this.LegLength = legLength;
        }

        public IEnumerable<IShape> GenerateLayout()
        {
            throw new NotImplementedException();
        }

        public IShape GenerateShapeFromId(string id)
        {
            if (!int.TryParse(id.Remove(0, 1), out int colNum))
            {
                throw new Exception("Error: could not parse column number from Id");
            }
            int v1X = GetXOffsetPosition(colNum);
            int v1Y = GetYOffsetPosition(id.ToCharArray()[0]);
            return new Triangle(id, v1X, v1Y, LegLength, colNum % 2 == 1);
        }

        public string GetShapeIdFromVertexCoordinates(int v1X, int v1y, int v2X, int v2y, int v3X, int v3y)
        {
            throw new NotImplementedException();
        }

        #region Private Helpers
        private int GetXOffsetPosition(int col)
        {
            return col % 2 == 0 ? ((col * LegLength / 2) - LegLength) : (col + 1) * LegLength / 2 - LegLength;
        }

        private int GetYOffsetPosition(char letter)
        {
            return (LetterToNumber(letter) * LegLength) - LegLength;
        }

        private int LetterToNumber(char letter)
        {
            return char.ToUpper(letter) - 64;
        }
        #endregion
    }
}
