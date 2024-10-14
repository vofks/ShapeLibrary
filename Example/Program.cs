using ShapeLibrary.Shapes;

internal class Program
{
    private static void Main(string[] args)
    {
        IShape circle = new Circle(1);
        IShape triangle = new Triangle(4, 3, 2);
        IShape rightTriangle = new Triangle(Math.Sqrt(0.4 * 0.4 + 0.3 * 0.3), 0.4, 0.3);

        Console.WriteLine($"Circle area: {circle.CalculateArea()}");
        Console.WriteLine($"Triangle area: {triangle.CalculateArea()}");
        Console.WriteLine($"Is right triangle: {(triangle as Triangle).IsRight()}");
        Console.WriteLine($"Triangle area: {rightTriangle.CalculateArea()}");
        Console.WriteLine($"Is right triangle: {(rightTriangle as Triangle).IsRight()}");
    }
}