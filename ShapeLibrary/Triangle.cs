using System.ComponentModel;

namespace ShapeLibrary.Shapes;

/// <summary>
/// Class represents triangle.
/// </summary>
public class Triangle : IShape
{
    public double Epsilon { get; set; } = 1e-10;
    public double A { get; }
    public double B { get; }
    public double C { get; }

    /// <summary>
    /// Creates instance of Triangle.
    /// </summary>
    /// <param name="a">First side length.</param>
    /// <param name="b">Second side length.</param>
    /// <param name="c">Third side length.</param>
    /// <exception cref="ArgumentException">Throws when one of parameters is less or equal to zero or sides do not form a triangle.</exception>
    public Triangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            throw new ArgumentException("Sides must be greater than zero.", a <= 0 ? nameof(a) : b <= 0 ? nameof(b) : nameof(c));
        }

        if (a + b <= c ||
            a + c <= b ||
            b + c <= a)
        {
            throw new ArgumentException("Sides do not form a triangle.");
        }

        A = a;
        B = b;
        C = c;
    }

    /// <summary>
    /// Calculate area of triangle.
    /// </summary>
    /// <returns>A double representing triangle area.</returns>
    public double CalculateArea()
    {
        double semiPerimeter = (A + B + C) / 2;

        return Math.Sqrt(semiPerimeter * (semiPerimeter - A) * (semiPerimeter - B) * (semiPerimeter - C));
    }

    /// <summary>
    /// Checks if triangle is right-angled.
    /// </summary>
    /// <returns>Returns true if triangle is right-angled, false otherwise.</returns>
    public bool IsRight()
    {
        double[] sides = [A, B, C];
        Array.Sort(sides);

        double sideA = sides[0];
        double sideB = sides[1];
        double hypotenuse = sides[2];

        return Math.Abs(1 - (sideA * sideA + sideB * sideB) / (hypotenuse * hypotenuse)) <= Epsilon;
    }
}
