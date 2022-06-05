using MediatR;
using Welldium.Application.Notifications;
using Welldium.Domain;

namespace Welldium.Application.NotificationHandlers;

public class MoveRobotNotificationHandler : INotificationHandler<MoveRobotNotification>
{
    private readonly ISimulationRepository _simulationRepository;

    public MoveRobotNotificationHandler(ISimulationRepository simulationRepository)
    {
        _simulationRepository = simulationRepository;
    }

    public async Task Handle(MoveRobotNotification notification, CancellationToken cancellationToken)
    {
        var simulation = await _simulationRepository.Get(notification.SimulationId);

        if (simulation is null)
        {
            return;
        }

        simulation.MoveRobot(notification.RobotId, notification.Moves);

        await _simulationRepository.Save(simulation);
    }
}
