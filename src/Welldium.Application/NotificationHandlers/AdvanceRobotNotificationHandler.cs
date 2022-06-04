using MediatR;
using Welldium.Application.Notifications;
using Welldium.Domain;

namespace Welldium.Application.NotificationHandlers;

public class AdvanceRobotNotificationHandler : INotificationHandler<AdvanceRobotNotification>
{
    private readonly ISimulationRepository _simulationRepository;

    public AdvanceRobotNotificationHandler(ISimulationRepository simulationRepository)
    {
        _simulationRepository = simulationRepository;
    }

    public async Task Handle(AdvanceRobotNotification notification, CancellationToken cancellationToken)
    {
        var simulation = await _simulationRepository.Get(notification.SimulationId);

        if (simulation is null)
        {
            return;
        }

        simulation.AdvanceRobot(notification.RobotId);

        await _simulationRepository.Save(simulation);
    }
}
