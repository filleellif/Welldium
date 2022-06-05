using MediatR;

namespace Welldium.Application.Notifications;

public class CreateRobotNotification : INotification
{
    public Guid SimulationId { get; }

    public Guid RobotId { get; }

    public string RobotName { get; }

    public CreateRobotNotification(Guid simulationId, Guid robotId, string robotName)
    {
        SimulationId = simulationId;
        RobotId = robotId;
        RobotName = robotName;
    }
}
