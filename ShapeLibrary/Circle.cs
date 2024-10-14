namespace ShapeLibrary.Shapes;

/// <summary>
/// Class represents circle.
/// </summary>
public class Circle : IShape
{
    public double Radius { get; }

    /// <summary>
    /// Creates instance of Circle.
    /// </summary>
    /// <param name="radius">Circle radius.</param>
    /// <exception cref="ArgumentException">Throws when <paramref name="radius"/> is less or equal to zero.</exception>
    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Radius must be greater than zero.", nameof(radius));
        }

        Radius = radius;
    }

    /// <summary>
    /// Calculate area of circle.
    /// </summary>
    /// <returns>A double representing circle area.</returns>
    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}
