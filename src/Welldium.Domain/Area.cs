namespace Welldium.Domain;

public record Area(Point Point, Size Size)
{
    public Point GetMiddle()
    {
        return new Point(
            Point.X + Size.Width / 2,
            Point.Y + Size.Height / 2);
    }

    public override string ToString()
    {
        return $"({Point.X}-{Point.X + Size.Width}), ({Point.Y}-{Point.Y + Size.Height})";
    }
}