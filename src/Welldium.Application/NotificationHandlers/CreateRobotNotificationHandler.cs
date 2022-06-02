using MediatR;
using Welldium.Application.Notifications;
using Welldium.Domain;

namespace Welldium.Application.NotificationHandlers;

public class CreateRobotNotificationHandler : INotificationHandler<CreateRobotNotification>
{
    private readonly ISimulationRepository _simulationRepository;

    public CreateRobotNotificationHandler(ISimulationRepository simulationRepository)
    {
        _simulationRepository = simulationRepository;
    }

    public async Task Handle(CreateRobotNotification notification, CancellationToken cancellationToken)
    {
        var robot = new Robot(notification.RobotId, notification.RobotName);

        var simulation = await _simulationRepository.Get(notification.SimulationId);

        if (simulation is null)
        {
            return;
        }

        simulation.AddRobot(robot);

        await _simulationRepository.Save(simulation);
    }
}