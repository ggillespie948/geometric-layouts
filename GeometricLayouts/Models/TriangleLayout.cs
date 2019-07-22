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
                throw new Exception("Error: could not parse column number from Id");
            }
            int v1X = GetXOffsetPosition(colNum);
            int v1Y = GetYOffsetPosition(id.ToCharArray()[0]);
            return new Triangle(id, v1X, v1Y, LegLength, colNum % 2 == 1);
        }

        public string GetShapeIdFromVertexCoordinates(int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y)
        {
            string letterRow = "";
            string numberColumn = "";

            // TO DO: validate triangle coordinates actually make a valid right angled triangle

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
