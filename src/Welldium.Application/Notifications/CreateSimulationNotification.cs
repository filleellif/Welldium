using MediatR;

namespace Welldium.Application.Notifications;

public class CreateSimulationNotification : INotification
{
    public Guid SimulationId { get; }

    public CreateSimulationNotification(Guid simulationId)
    {
        SimulationId = simulationId;
    }
}
