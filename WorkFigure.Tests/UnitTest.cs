using System;
using Xunit;
using WorkFigure;

namespace WorkFigure.Tests
{
    public class UnitTest
    {
        [Theory]
        [InlineData(1, "3,14")]
        [InlineData(2, "12,57")]
        public void TestCircle(double radius, string result)
        {
            Assert.Equal(result, string.Format("{0:f}", FigureBuilder.CreateFigure(radius).CalcArea()));
        }

        [Theory]
        [InlineData(0, "Radius must be greater then 0.")]
        [InlineData(-1, "Radius must be greater then 0.")]
        public void TestCircleErrors(double radius, string result)
        {
            try
            {
                FigureBuilder.CreateFigure(radius);
            }
            catch (Exception ex)
            {
                Assert.Equal(result, ex.Message);
            }
        }

        [Theory]
        [InlineData(new double[] { 1, 1, 1 }, "0,43", false)]
        [InlineData(new double[] { 10, 11, 12 }, "51,52", false)]
        [InlineData(new double[] { 3, 4, 5 }, "6,00", true)]
        [InlineData(new double[] { 3, 5, 4 }, "6,00", true)]
        [InlineData(new double[] { 5, 3, 4 }, "6,00", true)]
        public void TestTriangle(double[] sides, string result, bool IsRight)
        {
            var triangle = FigureBuilder.CreateFigure(sides[0], sides[1], sides[2]);
            Assert.Equal(result, string.Format("{0:f}", triangle.CalcArea()));
            Assert.Equal(IsRight, triangle.IsRightTriangle());
        }

        [Theory]
        [InlineData(new double[] { 1, 1, 10 }, "This tiangle dousn't exist.")]
        [InlineData(new double[] { 1, 10, 1 }, "This tiangle dousn't exist.")]
        [InlineData(new double[] { 10, 1, 1 }, "This tiangle dousn't exist.")]
        [InlineData(new double[] { 1, 1, -1 }, "Sides of a triangle must be greater then 0.")]
        [InlineData(new double[] { 1, -1, 1 }, "Sides of a triangle must be greater then 0.")]
        [InlineData(new double[] { -1, 1, 1 }, "Sides of a triangle must be greater then 0.")]

        public void TestTriangleErrors(double[] sides, string result)
        {
            try
            {
                FigureBuilder.CreateFigure(sides[0], sides[1], sides[2]);
            }
            catch (Exception ex)
            {
                Assert.Equal(result, ex.Message);
            }
        }
    }
}
