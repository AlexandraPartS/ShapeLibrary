using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLibrary.Test
{
    public class TriangleTests
    {
        [Fact]
        public void TriangleSet_UncorrectFormatValuesNegative_ExpectedException()
        {
            double value1 = -3, value2 = 4, value3 = 5;
            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                new Triangle(value1, value2, value3)
            );
        }

        [Fact]
        public void TriangleSetGet_CorrectFormatValues_Test()
        {
            double[] expected = { 3, 4, 5};
            double value1 = 3, value2 = 4, value3 = 5;
            Triangle triangle = new Triangle(value1, value2, value3);
            double[] actual = { triangle.A, triangle .B, triangle .C};

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void CalcArea_Test()
        {
            double expected = 6;
            Triangle triangle = new Triangle(3, 4, 5);
            double actual = triangle.CalcArea();

            Assert.Equal(expected, actual, 10);
        }


        [Fact]
        public void TriangleIsRight_ValuesForRightTriangle_Test()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            bool actual = triangle.TriangleIsRight();

            Assert.True(actual);
        }
        [Fact]
        public void TriangleIsRight_ValuesForNonRightTriangle_Test()
        {
            Triangle triangle = new Triangle(3, 3, 5);
            bool actual = triangle.TriangleIsRight();

            Assert.False(actual);
        }

    }
}
