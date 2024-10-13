using System;
using System.ComponentModel;
using FluentAssertions;
using ShapeLibrary.Shapes;

namespace ShapeLibrary.Tests.ShapeTests;

public class TriangleTests
{
    [Fact]
    public void Triangle_Triangle_CreatesTriangleInstance()
    {
        var act = () => new Triangle(4, 7, 9);

        act.Should().NotThrow();
    }

    [Fact]
    public void Triangle_Triangle_ThrowsInvalidArgumentExceptionOnZeroOrNegativeValues()
    {
        var act = () => new Triangle(-1, 7, 9);

        act.Should().Throw<InvalidEnumArgumentException>();
    }

    [Fact]
    public void Triangle_Triangle_ThrowsInvalidArgumentExceptionOnInvalidTriangleSides()
    {
        var act = () => new Triangle(2, 2, 2);

        act.Should().Throw<InvalidEnumArgumentException>();
    }

    [Fact]
    public void Triangle_A_ReturnsCorrectSideA()
    {
        double expectedA = 1;
        var triangle = new Triangle(expectedA, 5, 4.5);

        double resultA = triangle.A;

        resultA.Should().Be(expectedA);
    }

    [Fact]
    public void Triangle_B_ReturnsCorrectSideB()
    {
        double expectedB = 5;
        var triangle = new Triangle(1, expectedB, 4.5);

        double resultB = triangle.B;

        resultB.Should().Be(expectedB);
    }

    [Fact]
    public void Triangle_C_ReturnsCorrectSideC()
    {
        double expectedC = 4.5;
        var triangle = new Triangle(1, 5, expectedC);

        double resultC = triangle.C;

        resultC.Should().Be(expectedC);
    }

    [Fact]
    public void Triangle_GetEpsilon_ReturnsDefaultValue()
    {
        double expectedEpsilon = 1e-10;
        var triangle = new Triangle(4, 7, 9);

        double resultEpsilon = triangle.Epsilon;

        resultEpsilon.Should().Be(expectedEpsilon);
    }

    [Fact]
    public void Triangle_SetEpsilon_SetsCorrectValue()
    {
        double expectedEpsilon = 0;
        var triangle = new Triangle(7, 4, 9);

        triangle.Epsilon = expectedEpsilon;
        double resultEpsilon = triangle.Epsilon;

        resultEpsilon.Should().Be(expectedEpsilon);
    }

    [Fact]
    public void Triangle_CalculateArea_ReturnsCorrectArea()
    {
        double sideA = 4;
        double sideB = 7;
        double sideC = 9;
        double simePerimeter = (sideA + sideB + sideC) / 2;
        double expectedArea = Math.Sqrt(simePerimeter * (simePerimeter - sideA) * (simePerimeter - sideB) * (simePerimeter - sideC));
        var triangle = new Triangle(sideA, sideB, sideC);

        double resultArea = triangle.CalculateArea();

        resultArea.Should().Be(expectedArea);
    }

    [Fact]
    public void Triangle_IsRight_ReturnsTrueOnRightTriangle()
    {
        double sideA = 3;
        double sideB = 5;
        double sideC = Math.Sqrt(sideA * sideA + sideB * sideB);
        var triangle = new Triangle(sideA, sideB, sideC);

        bool isRight = triangle.IsRight();

        isRight.Should().BeTrue();
    }

    [Fact]
    public void Triangle_IsRight_ReturnsFalseOnRegularTriangle()
    {
        double sideA = 3;
        double sideB = 5;
        double sideC = 9;
        var triangle = new Triangle(sideA, sideB, sideC);

        bool isRight = triangle.IsRight();

        isRight.Should().BeFalse();
    }
}
