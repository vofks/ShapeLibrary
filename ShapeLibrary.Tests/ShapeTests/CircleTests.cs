using System.ComponentModel;
using FluentAssertions;
using ShapeLibrary.Shapes;

namespace ShapeLibrary.Tests.ShapeTests;

public class CircleTests
{
    [Fact]
    public void Circle_Circle_CreatesCircleInstance()
    {
        var act = () => new Circle(1);


        act.Should().NotThrow();
    }

    [Fact]
    public void Circle_Circle_ThrowsInvalidArgumentExceptionOnZeroAndNegativeValues()
    {
        var act = () => new Circle(0);

        act.Should().Throw<InvalidEnumArgumentException>();
    }

    [Fact]
    public void Circle_Radius_ReturnsCorrectRadius()
    {
        double expectedRadius = 1;
        var circle = new Circle(expectedRadius);

        circle.Radius.Should().Be(expectedRadius);
    }

    [Fact]
    public void Circle_CalculateArea_ReturnsCorrectArea()
    {
        double radius = 3;
        double expectedArea = Math.PI * radius * radius;
        var circle = new Circle(radius);

        double resultArea = circle.CalculateArea();

        resultArea.Should().Be(expectedArea);
    }
}
