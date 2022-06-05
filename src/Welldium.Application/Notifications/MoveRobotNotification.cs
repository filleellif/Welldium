using MediatR;
using Welldium.Domain;

namespace Welldium.Application.Notifications;

public class MoveRobotNotification : INotification
{
    public Guid SimulationId { get; }

    public Guid RobotId { get; }

    public IEnumerable<Move> Moves { get; }

    public MoveRobotNotification(Guid simulationId, Guid robotId, IEnumerable<Move> moves)
    {
        SimulationId = simulationId;
        RobotId = robotId;
        Moves = moves;
    }
}