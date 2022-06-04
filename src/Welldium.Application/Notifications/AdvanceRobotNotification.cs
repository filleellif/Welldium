using MediatR;

namespace Welldium.Application.Notifications;

public class AdvanceRobotNotification : INotification
{
    public Guid SimulationId { get; }

    public Guid RobotId { get; }

    public AdvanceRobotNotification(Guid simulationId, Guid robotId)
    {
        SimulationId = simulationId;
        RobotId = robotId;
    }
}
