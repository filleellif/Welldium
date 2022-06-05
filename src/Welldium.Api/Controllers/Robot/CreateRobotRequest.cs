namespace Welldium.Api.Controllers.Robot;

public record CreateRobotRequest
{
    public string Name { get; set; } = string.Empty;
}
