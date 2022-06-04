using MediatR;
using Welldium.Application.Notifications;
using Welldium.Domain;

namespace Welldium.Application.NotificationHandlers;

public class TurnRobotLeftNotificationHandler : INotificationHandler<TurnRobotLeftNotification>
{
    private readonly ISimulationRepository _simulationRepository;

    public TurnRobotLeftNotificationHandler(ISimulationRepository simulationRepository)
    {
        _simulationRepository = simulationRepository;
    }

    public async Task Handle(TurnRobotLeftNotification notification, CancellationToken cancellationToken)
    {
        var simulation = await _simulationRepository.Get(notification.SimulationId);

        if (simulation is null)
        {
            return;
        }

        simulation.TurnRobotLeft(notification.RobotId);

        await _simulationRepository.Save(simulation);
    }
}
