using GeometricLayouts.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Xunit;

namespace GeometricLayouts.Tests
{
    public class TrianlgeLayoutTests
    {
        [Theory]
        [InlineData("A1")]
        [InlineData("A2")]
        [InlineData("A11")]
        [InlineData("A12")]
        [InlineData("B1")]
        [InlineData("B2")]
        [InlineData("B3")]
        [InlineData("B4")]
        [InlineData("F11")]
        [InlineData("F12")]
        public void GenerateShapeFromId_Returns_Expected_Output(string Id)
        {
            Triangle expectedOutput = GetExpectedTriangleOutput(Id);
            TriangleLayout layoutGenerator = new TriangleLayout(6,12,10);

            var output = (Triangle)layoutGenerator.GenerateShapeFromId(Id);

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData("A1")]
        [InlineData("A2")]
        [InlineData("A11")]
        [InlineData("A12")]
        [InlineData("B1")]
        [InlineData("B2")]
        [InlineData("B3")]
        [InlineData("B4")]
        [InlineData("F11")]
        [InlineData("F12")]
        public void GetShapeIdFromVertextCoordinates_Returns_Expected_Output(string Id)
        {
            Triangle inputTriangle = GetExpectedTriangleOutput(Id);
            TriangleLayout layoutGenerator = new TriangleLayout(6, 12, 10);

            var outputId = layoutGenerator.GetShapeIdFromVertexCoordinates(inputTriangle.V1.X, inputTriangle.V1.Y, inputTriangle.V2.X, inputTriangle.V2.Y, inputTriangle.V3.X, inputTriangle.V3.Y);

            Assert.Equal(inputTriangle.Id, outputId);
        }


        [Theory]
        [InlineData("A1")]
        [InlineData("A2")]
        [InlineData("A11")]
        [InlineData("A12")]
        [InlineData("B1")]
        [InlineData("B2")]
        [InlineData("B3")]
        [InlineData("B4")]
        [InlineData("F11")]
        [InlineData("F12")]
        public void GetVertices_IShape_Works_As_Expected(string Id)
        {
            Triangle expectedOutputVerticesTriangle = GetExpectedTriangleOutput(Id);
            var expectedVertices = new List<Point>() { expectedOutputVerticesTriangle.V1, expectedOutputVerticesTriangle.V2, expectedOutputVerticesTriangle.V3 };

            var output = expectedOutputVerticesTriangle.GetVertices().ToList();

            Assert.Equal(expectedVertices, output);
        }


        private static Triangle GetExpectedTriangleOutput(string Id)
        {
            switch (Id)
            {
                case "A1":
                    return new Triangle("A1", 0, 9, 0, 0, 9, 9);

                case "A2":
                    return new Triangle("A2", 9, 0, 0, 0, 9, 9);

                case "A11":
                    return new Triangle("A11", 49, 9, 49, 0, 59, 9);

                case "A12":
                    return new Triangle("A12", 59, 0, 49, 0, 59, 9);

                case "B1":
                    return new Triangle("B1", 0, 19, 0, 9, 9, 19);

                case "B2":
                    return new Triangle("B2", 9, 9, 0, 9, 9, 19);

                case "B3":
                    return new Triangle("B3", 9, 19, 9, 9, 19, 19);

                case "B4":
                    return new Triangle("B4", 19, 9, 9, 9, 19, 19);

                case "F11":
                    return new Triangle("F11", 49, 59, 49, 49, 59, 59);

                case "F12":
                    return new Triangle("F12", 59, 49, 49, 49, 59, 59);

                default:
                    throw new Exception("Invalid test data");
            }

        }
    }
}
