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
            var layout = new List<Triangle>();
            for (int i = 1; i < MaxRow + 1; i++)
            {
                for (int j = 1; j < MaxCol + 1; j++)
                {
                    layout.Add((Triangle)GenerateShapeFromId(NumberToLetter(i) + j));
                }
            }
            return layout;
        }

        public IShape GenerateShapeFromId(string id)
        {
            if (!int.TryParse(id.Remove(0, 1), out int colNum))
            {
                return null;
            }

            var c = id.ToCharArray()[0];

            if ((colNum > MaxCol || colNum < 1) || char.ToUpper(c) - 64 < 0 || char.ToUpper(c) - 64 > 26)
                return null;


            int v1X = GetXOffsetPosition(colNum);
            int v1Y = GetYOffsetPosition(c);
            return new Triangle(id, v1X, v1Y, LegLength, colNum % 2 == 1);
        }

        public bool VerticesMakeRightAngledTriangle(int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y)
        {
            if(v1Y > v2Y)
            {
                // LOWER SECTION
                if (v1Y - v2Y == LegLength && v2X == v1X || v1Y - v2Y == LegLength - 1 && v2X == v1X
                    &&
                    v3X - v1X == LegLength && v1Y == v3Y || v3X - v1X == LegLength - 1 &&  v1Y == v3Y)
                    return true;
                else
                    return false;
            }
            else if (v1X > v2X)
            {
                // UPPER SECTION
                if (v1X - v2X == LegLength && v1Y == v2Y || v1X - v2X == LegLength-1 && v1Y == v2Y
                    &&
                    v3Y - v1Y == LegLength && v3X == v1X || v3Y - v1Y == LegLength-1 && v3X == v1X)
                    return true;
                else
                    return false;
            }

            return false;
        }

        public string GetShapeIdFromVertexCoordinates(int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y)
        {
            string letterRow = "";
            string numberColumn = "";

            if (VerticesMakeRightAngledTriangle(v1X, v1Y, v2X, v2Y, v3X, v3Y))
            {
                if (v1Y > v2Y)
                {
                    // LOWER SECTION
                    if ((v1X + 1) % LegLength == 0 && (v1Y + 1) % LegLength == 0 || v1X == 0)
                    {
                        letterRow = NumberToLetter((v1Y + 1) / LegLength);
                        numberColumn = ((v2X + 1 + LegLength) / (LegLength / 2) - 1).ToString();
                    }
                    else
                    {
                        throw new Exception("Error, triangle is invalid.");
                    }
                }
                else if (v1X > v2X)
                {
                    // UPPER SECTION
                    if ((v1X + 1) % LegLength == 0 && (v1Y + 1) % LegLength == 0 || v1Y == 0)
                    {
                        letterRow = NumberToLetter(((v1Y + 1) / LegLength) + 1);
                        numberColumn = ((v2X + 1 + LegLength) / (LegLength / 2)).ToString();
                    }
                    else
                    {
                        throw new Exception("Error, triangle is invalid.");
                    }
                }
            }

            return letterRow + numberColumn;
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

        private string NumberToLetter(int number)
        {
            char c = (char)((65) + (number - 1));
            return c.ToString();
        }
        #endregion
    }
}
