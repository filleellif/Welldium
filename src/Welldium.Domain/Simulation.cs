namespace Welldium.Domain;

public class Simulation : Entity
{
    private readonly List<Robot> _robots = new List<Robot>();

    public IReadOnlyCollection<Robot> Robots => _robots.AsReadOnly();

    public Simulation(Guid id) : base(id)
    {
    }

    public void AddRobot(Robot robot)
    {
        // assign the robot to an area on the planet

        _robots.Add(robot);
    }

    public void RemoveRobot(Robot robot)
    {
        _robots.Remove(robot);
    }
}