using GeometricLayouts.Models;
using System;
using Xunit;

namespace GeometricLayouts.Tests
{
    public class TrianlgeLayoutTests
    {
        [Fact]
        public void GenerateShapeFromId_Returns_Expected_Output()
        {
            var expectedOutput = new Triangle("A1",0,9,0,0,9,9);
            TriangleLayout layoutGenerator = new TriangleLayout(6,12,10);

            var output = (Triangle)layoutGenerator.GenerateShapeFromId("A1");

            Assert.Equal(expectedOutput, output);
        }
    }
}
