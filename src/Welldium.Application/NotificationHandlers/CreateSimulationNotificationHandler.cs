using MediatR;
using Welldium.Application.Notifications;
using Welldium.Domain;

namespace Welldium.Application.NotificationHandlers;

public class CreateSimulationNotificationHandler : INotificationHandler<CreateSimulationNotification>
{
    private readonly ISimulationRepository _simulationRepository;

    public CreateSimulationNotificationHandler(ISimulationRepository simulationRepository)
    {
        _simulationRepository = simulationRepository;
    }

    public async Task Handle(CreateSimulationNotification notification, CancellationToken cancellationToken)
    {
        var simulation = new Simulation(notification.SimulationId);

        await _simulationRepository.Save(simulation);
    }
}
