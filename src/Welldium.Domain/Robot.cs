namespace Welldium.Domain;

public class Robot : Entity
{
    public string Name { get; }

    public Area Area { get; }

    public Point Position { get; private set; }

    public Direction Direction { get; private set; }

    public Robot(Guid id, string name, Area area) : base(id)
    {
        Name = name;
        Area = area;

        // start robot in the middle of the area facing up
        Position = area.GetMiddle();
        Direction = Direction.Up;
    }

    public void Advance()
    {
        switch (Direction)
        {
            case Direction.Up:
                Position = new Point(Position.X, Position.Y + 1);
                break;
            case Direction.Down:
                Position = new Point(Position.X, Position.Y - 1);
                break;
            case Direction.Left:
                Position = new Point(Position.X - 1, Position.Y);
                break;
            case Direction.Right:
                Position = new Point(Position.X + 1, Position.Y);
                break;
        }
    }

    internal void Move(Move move)
    {
        switch (move)
        {
            case Domain.Move.Advance:
                Advance();
                break;
            case Domain.Move.TurnLeft:
                TurnLeft();
                break;
            case Domain.Move.TurnRight:
                TurnRight();
                break;
            case Domain.Move.None:
                throw new ArgumentException("Illegal move");
        }
    }

    public void TurnLeft()
    {
        switch (Direction)
        {
            case Direction.Up:
                Direction = Direction.Left;
                break;
            case Direction.Down:
                Direction = Direction.Right;
                break;
            case Direction.Left:
                Direction = Direction.Down;
                break;
            case Direction.Right:
                Direction = Direction.Up;
                break;
        }
    }

    public void TurnRight()
    {
        switch (Direction)
        {
            case Direction.Up:
                Direction = Direction.Right;
                break;
            case Direction.Down:
                Direction = Direction.Left;
                break;
            case Direction.Left:
                Direction = Direction.Up;
                break;
            case Direction.Right:
                Direction = Direction.Down;
                break;
        }
    }
}
