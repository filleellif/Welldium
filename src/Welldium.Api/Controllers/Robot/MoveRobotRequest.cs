namespace Welldium.Api.Controllers.Robot;

public record MoveRobotRequest
{
    public IEnumerable<Move> Moves { get; set; } = Enumerable.Empty<Move>();
}
