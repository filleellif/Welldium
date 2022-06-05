namespace Welldium.Domain;

public class Simulation : Entity
{
    private readonly List<Robot> _robots = new();

    public IReadOnlyCollection<Robot> Robots => _robots.AsReadOnly();

    public Simulation(Guid id) : base(id)
    {
    }

    public void AddRobot(Guid robotId, string robotName)
    {
        var random = new Random(Guid.NewGuid().GetHashCode());
        var area = new Area(
            new Point(random.Next(10, 100), random.Next(10, 100)),
            new Size(random.Next(2, 10), random.Next(2, 10)));
        var robot = new Robot(robotId, robotName, area);
        _robots.Add(robot);
    }

    public void RemoveRobot(Guid robotId)
    {
        var robot = GetRobot(robotId);
        if (robot is not null)
        {
            _robots.Remove(robot);
        }
    }

    public void MoveRobot(Guid robotId, IEnumerable<Move> moves)
    {
        var robot = GetRobot(robotId);
        if (robot is null)
        {
            return;
        }

        foreach (var move in moves)
        {
            robot.Move(move);
        }
    }

    private Robot? GetRobot(Guid robotId)
    {
        return _robots.SingleOrDefault(r => r.Id.Equals(robotId));
    }
}
