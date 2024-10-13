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
}
