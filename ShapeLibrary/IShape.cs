namespace ShapeLibrary.Shapes;

/// <summary>
/// Represents shape with calculatable area.
/// </summary>
public interface IShape
{
    /// <summary>
    /// Calculate shape area.
    /// </summary>
    /// <returns>A double representing shape area.</returns>
    public double CalculateArea();
}
