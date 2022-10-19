using ShapesLibrary;

namespace TestLibrary
{
    public class BasicTests
    {
        //Test for setter
        //[Fact]
        //public void TestForSetterCircleRadius()
        //{
        //    Circle circle = new Circle(4);
        //    Assert.Throws<ArgumentOutOfRangeException>(
        //        () =>
        //        circle.Radius = 3
        //    );
        //}


        [Fact]
        public void TestForCircleCorrectPositiveRadiusFormat()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                new Circle(-4)
            );
        }

        [Fact]
        public void TestForTriangleCorrectPositiveSidesFormat()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                new Triangle(-3, 4, 5)
            );
        }


        [Fact]
        public void TestForTriangleIsRight()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.True(triangle.TriangleIsRight());
        }

        [Fact]
        public void TestForTriangleIsNotRight()
        {
            var triangle = new Triangle(3, 3, 5);
            Assert.False(triangle.TriangleIsRight());
        }

        [Fact]
        public void TestForTriangleCalcArea()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.Equal(6, triangle.CalcArea());
        }




    }
}