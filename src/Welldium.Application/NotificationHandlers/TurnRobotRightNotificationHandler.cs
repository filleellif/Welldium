using MediatR;
using Welldium.Application.Notifications;
using Welldium.Domain;

namespace Welldium.Application.NotificationHandlers;

public class TurnRobotRightNotificationHandler : INotificationHandler<TurnRobotRightNotification>
{
    private readonly ISimulationRepository _simulationRepository;

    public TurnRobotRightNotificationHandler(ISimulationRepository simulationRepository)
    {
        _simulationRepository = simulationRepository;
    }

    public async Task Handle(TurnRobotRightNotification notification, CancellationToken cancellationToken)
    {
        var simulation = await _simulationRepository.Get(notification.SimulationId);

        if (simulation is null)
        {
            return;
        }

        simulation.TurnRobotRight(notification.RobotId);

        await _simulationRepository.Save(simulation);
    }
}
