namespace Welldium.Domain;

public class Simulation : Entity
{
    private readonly List<Robot> _robots = new();

    public IReadOnlyCollection<Robot> Robots => _robots.AsReadOnly();

    private readonly List<Area> _areas = new();

    private readonly Dictionary<Robot, Area> _robotAssignments = new();

    public Simulation(Guid id) : base(id)
    {
        var random = new Random(Guid.NewGuid().GetHashCode());
        _areas = Enumerable.Range(0, 100)
            .Select(i => new Area(new Point(random.Next(100), random.Next(100)), new Size(random.Next(10), random.Next(10))))
            .ToList();
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

    public void AddRobot(Robot robot)
    {
        _robots.Add(robot);

        var area = _areas
            .SkipWhile(a => _robotAssignments.Any(ra => ra.Value == a))
            .FirstOrDefault();
        if (area is not null)
        {
            _robotAssignments.Add(robot, area);
        }
    }

    public void RemoveRobot(Guid robotId)
    {
        var robot = GetRobot(robotId);
        if (robot is not null)
        {
            _robots.Remove(robot);
        }
    }

    public void AdvanceRobot(Guid robotId)
    {
        GetRobot(robotId)?.Advance();
    }

    public void TurnRobotLeft(Guid robotId)
    {
        GetRobot(robotId)?.TurnLeft();
    }

    public void TurnRobotRight(Guid robotId)
    {
        GetRobot(robotId)?.TurnRight();
    }

    private Robot? GetRobot(Guid robotId)
    {
        return _robots.SingleOrDefault(r => r.Id.Equals(robotId));
    }
}
