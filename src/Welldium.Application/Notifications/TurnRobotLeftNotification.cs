using MediatR;

namespace Welldium.Application.Notifications;

public class TurnRobotLeftNotification : INotification
{
    public Guid SimulationId { get; }

    public Guid RobotId { get; }

    public TurnRobotLeftNotification(Guid simulationId, Guid robotId)
    {
        SimulationId = simulationId;
        RobotId = robotId;
    }
}
