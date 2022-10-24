namespace ShapesLibrary.Test
{
    public class CircleTests
    {
        [Fact]
        public void CircleSet_UncorrectFormatNegativeRadius_ExpectedException()
        {
            double radius = -4;

            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                new Circle(radius)
            );
        }

        [Fact]
        public void CircleSetGet_CorrectFormatPositiveRadius_Test()
        {
            double expected = 4;
            double radius = 4;
            Circle circle = new Circle(radius); //Setter

            Assert.Equal(expected, circle.Radius); //Getter
        }

        [Fact]
        public void CalcArea_CorrectFormatPositiveRadius_Test()
        {
            double expected = 50.26548245743669;
            double radius = 4;
            double circleArea = new Circle(radius).CalcArea();

            Assert.Equal(expected, circleArea, 10);
        }
    }
}