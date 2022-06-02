using MediatR;
using Microsoft.AspNetCore.Mvc;
using Welldium.Application.Notifications;

namespace Welldium.Api.Controllers.Simulation.Create;

[ApiController]
[Route(Constants.Routes.Simulation)]
public class CreateController : ControllerBase
{
    private readonly INotificationHandler<CreateSimulationNotification> _handler;

    public CreateController(INotificationHandler<CreateSimulationNotification> handler)
    {
        _handler = handler;
    }

    [HttpPost(Name = Constants.RouteNames.CreateSimulation)]
    public async Task<IActionResult> CreateSimulation(CancellationToken cancellationToken)
    {
        var simulationId = Guid.NewGuid();

        await _handler.Handle(new CreateSimulationNotification(simulationId), cancellationToken);

        return CreatedAtRoute(Constants.RouteNames.GetSimulation, new { id = simulationId }, null);
    }
}
