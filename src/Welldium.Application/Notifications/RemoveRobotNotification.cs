using MediatR;

namespace Welldium.Application.Notifications;

public class RemoveRobotNotification : INotification
{
    public Guid SimulationId { get; }

    public Guid RobotId { get; }

    public RemoveRobotNotification(Guid simulationId, Guid robotId)
    {
        SimulationId = simulationId;
        RobotId = robotId;
    }
}
