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
        };
    }
}