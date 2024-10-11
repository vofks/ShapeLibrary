namespace ShapeLibrary.Shapes;

public class Triangle : IShape
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public double CalculateArea()
    {
        var semi = (A + B + C) / 2;

        return Math.Sqrt(semi * (semi - A) * (semi - B) * (semi - C));
    }

    public bool IsRight()
    {
        throw new NotImplementedException();
    }
}
