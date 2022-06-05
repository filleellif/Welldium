namespace Welldium.ReadModels.Extensions;

public static class SimulationExtensions
{
    public static Models.Simulation FromDomain(this Domain.Simulation simulation)
    {
        return new Models.Simulation
        {
            Robots = simulation.Robots.Select(r => r.FromDomain()),
        };
    }

    public static Models.Robot FromDomain(this Domain.Robot robot)
    {
        return new Models.Robot
        {
            Name = robot.Name,
            AssignedArea = robot.Area.FromDomain(),
            CurrentPosition = robot.Position.FromDomain(),
            IsOutOfBounds = robot.IsOutOfBounds,
        };
    }

    public static Models.Area FromDomain(this Domain.Area area)
    {
        return new Models.Area
        {
            MinX = area.Point.X,
            MaxX = area.Point.X + area.Size.Width,
            MinY = area.Point.Y,
            MaxY = area.Point.Y + area.Size.Height,
        };
    }

    public static Models.Point FromDomain(this Domain.Point point)
    {
        return new Models.Point
        {
            X = point.X,
            Y = point.Y,
        };
    }
}