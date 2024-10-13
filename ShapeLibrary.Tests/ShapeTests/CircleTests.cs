using System.ComponentModel;
using FluentAssertions;
using ShapeLibrary.Shapes;

namespace ShapeLibrary.Tests.ShapeTests;

public class CircleTests
{
    [Theory]
    [InlineData(1.0)]
    [InlineData(5)]
    [InlineData(10e1)]
    [InlineData(10e-3)]
    public void Circle_Circle_CreatesCircleInstance(double radius)
    {
        var act = () => new Circle(radius);


        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-0.1)]
    [InlineData(-1e-10)]
    [InlineData(-double.MaxValue)]
    public void Circle_Circle_ThrowsInvalidArgumentExceptionOnZeroOrNegativeValues(double radius)
    {
        var act = () => new Circle(radius);

        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(0.1)]
    [InlineData(1e-5)]
    [InlineData(double.MaxValue)]
    public void Circle_Radius_ReturnsCorrectRadius(double expectedRadius)
    {
        var circle = new Circle(expectedRadius);

        circle.Radius.Should().Be(expectedRadius);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(1)]
    [InlineData(0.3333333333)]
    [InlineData(10e-20)]
    [InlineData(10e20)]
    [InlineData(123141515516463437)]
    public void Circle_CalculateArea_ReturnsCorrectArea(double radius)
    {
        double expectedArea = Math.PI * radius * radius;
        var circle = new Circle(radius);

        double resultArea = circle.CalculateArea();

        resultArea.Should().Be(expectedArea);
    }
}
