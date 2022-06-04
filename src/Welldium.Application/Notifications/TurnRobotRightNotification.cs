using MediatR;

namespace Welldium.Application.Notifications;

public class TurnRobotRightNotification : INotification
{
    public Guid SimulationId { get; }

    public Guid RobotId { get; }

    public TurnRobotRightNotification(Guid simulationId, Guid robotId)
    {
        SimulationId = simulationId;
        RobotId = robotId;
    }
}