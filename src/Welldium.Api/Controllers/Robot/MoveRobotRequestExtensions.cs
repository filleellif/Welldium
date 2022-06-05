using Welldium.Application.Notifications;

namespace Welldium.Api.Controllers.Robot;

public static class MoveRobotRequestExtensions
{
    public static MoveRobotNotification ToNotification(this MoveRobotRequest request, Guid simulationId, Guid robotId)
    {
        var moves = request.Moves.Select(m =>
        {
            return m switch
            {
                Move.Advance => Domain.Move.Advance,
                Move.TurnLeft => Domain.Move.TurnLeft,
                Move.TurnRight => Domain.Move.TurnRight,
                _ => throw new ArgumentException(),
            };
        });

        return new MoveRobotNotification(simulationId, robotId, moves);
    }
}