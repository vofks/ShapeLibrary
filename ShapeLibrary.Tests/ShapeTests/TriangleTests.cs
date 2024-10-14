using System;
using System.ComponentModel;
using FluentAssertions;
using ShapeLibrary.Shapes;

namespace ShapeLibrary.Tests.ShapeTests;

public class TriangleTests
{
    static readonly double hyp = double.Hypot(3, 3);

    [Theory]
    [InlineData(1, 2.5, 3)]
    [InlineData(2, 2, 2)]
    [InlineData(5, 7, 9)]
    public void Triangle_Triangle_CreatesTriangleInstance(double a, double b, double c)
    {
        var act = () => new Triangle(a, b, c);

        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(-5, 7, 9)]
    [InlineData(5, -7, 9)]
    [InlineData(5, 7, -9)]
    [InlineData(5, -7, -9)]
    [InlineData(-5, -7, -9)]
    [InlineData(-5, -7, 9)]
    [InlineData(-5, 7, -9)]
    [InlineData(0, -7, 9)]
    [InlineData(5, 0, 9)]
    [InlineData(5, 7, 0)]
    [InlineData(0, 0, 0)]
    public void Triangle_Triangle_ThrowsInvalidArgumentExceptionOnZeroOrNegativeValues(double a, double b, double c)
    {
        var act = () => new Triangle(a, b, c);

        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(1, 1, 3)]
    [InlineData(3, 1, 1)]
    [InlineData(1, 3, 1)]
    public void Triangle_Triangle_ThrowsInvalidArgumentExceptionOnInvalidTriangleSides(double a, double b, double c)
    {
        var act = () => new Triangle(a, b, c);

        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(1, 3, 3)]
    [InlineData(0.2, 0.3, 0.4)]
    [InlineData(10000, 12, 10001)]
    public void Triangle_A_ReturnsCorrectSideA(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);

        double result = triangle.A;

        result.Should().Be(a);
    }

    [Theory]
    [InlineData(1, 3, 3)]
    [InlineData(0.2, 0.3, 0.4)]
    [InlineData(10000, 12, 10001)]
    public void Triangle_B_ReturnsCorrectSideB(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);

        double result = triangle.B;

        result.Should().Be(b);
    }

    [Theory]
    [InlineData(1, 3, 3)]
    [InlineData(0.2, 0.3, 0.4)]
    [InlineData(10000, 12, 10001)]
    public void Triangle_C_ReturnsCorrectSideC(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);

        double result = triangle.C;

        result.Should().Be(c);
    }

    [Fact]
    public void Triangle_GetEpsilon_ReturnsDefaultValue()
    {
        double expectedEpsilon = 1e-10;
        var triangle = new Triangle(4, 7, 9);

        double resultEpsilon = triangle.Epsilon;

        resultEpsilon.Should().Be(expectedEpsilon);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(100)]
    [InlineData(1e-6)]
    public void Triangle_SetEpsilon_SetsCorrectValue(double expected)
    {
        var triangle = new Triangle(7, 4, 9);

        triangle.Epsilon = expected;
        double resultEpsilon = triangle.Epsilon;

        resultEpsilon.Should().Be(expected);
    }

    [Theory]
    [InlineData(5, 7, 9)]
    [InlineData(0.2, 0.3, 0.4)]
    [InlineData(15000, 30000, 40000)]
    public void Triangle_CalculateArea_ReturnsCorrectArea(double a, double b, double c)
    {
        double simePerimeter = (a + b + c) / 2;
        double expectedArea = Math.Sqrt(simePerimeter * (simePerimeter - a) * (simePerimeter - b) * (simePerimeter - c));
        var triangle = new Triangle(a, b, c);

        double resultArea = triangle.CalculateArea();

        resultArea.Should().Be(expectedArea);
    }

    [Theory]
    [InlineData(5, 7)]
    [InlineData(0.222, 0.33333)]
    [InlineData(2243256246.3, 1012423142.1)]
    public void Triangle_IsRight_ReturnsTrueOnRightTriangle(double a, double b)
    {
        double c = Math.Sqrt(a * a + b * b);
        var triangle = new Triangle(a, b, c);

        bool isRight = triangle.IsRight();

        isRight.Should().BeTrue();
    }

    [Theory]
    [InlineData(5, 7)]
    [InlineData(0.222, 0.33333)]
    [InlineData(2243256246.3, 1012423142.1)]
    public void Triangle_IsRight_ReturnsFalseOnRegularTriangle(double a, double b)
    {
        double c = a + b - 0.1 * (a + b);
        var triangle = new Triangle(a, b, c);

        bool isRight = triangle.IsRight();

        isRight.Should().BeFalse();
    }
}
