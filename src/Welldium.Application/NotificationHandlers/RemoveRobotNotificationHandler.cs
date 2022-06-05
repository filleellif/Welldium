using MediatR;
using Welldium.Application.Notifications;
using Welldium.Domain;

namespace Welldium.Application.NotificationHandlers;

public class RemoveRobotNotificationHandler : INotificationHandler<RemoveRobotNotification>
{
    private readonly ISimulationRepository _simulationRepository;

    public RemoveRobotNotificationHandler(ISimulationRepository simulationRepository)
    {
        _simulationRepository = simulationRepository;
    }

    public async Task Handle(RemoveRobotNotification notification, CancellationToken cancellationToken)
    {
        var simulation = await _simulationRepository.Get(notification.SimulationId);

        if (simulation is null)
        {
            return;
        }

        simulation.RemoveRobot(notification.RobotId);

        await _simulationRepository.Save(simulation);
    }
}
