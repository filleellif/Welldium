namespace Welldium.Api.Controllers.Simulation.Robot;

public record CreateRobotRequest
{
    public string Name { get; set; } = string.Empty;
}