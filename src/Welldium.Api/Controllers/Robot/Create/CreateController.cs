using MediatR;
using Microsoft.AspNetCore.Mvc;
using Welldium.Application.Notifications;

namespace Welldium.Api.Controllers.Robot.Create;

[ApiController]
[Route(Constants.Routes.Simulation + "/{simulationId}" + Constants.Routes.Robot)]
public class CreateController : ControllerBase
{
    private readonly INotificationHandler<CreateRobotNotification> _handler;

    public CreateController(INotificationHandler<CreateRobotNotification> handler)
    {
        _handler = handler;
    }

    [HttpPost(Name = Constants.RouteNames.CreateRobot)]
    public async Task Create(
        Guid simulationId,
        [FromBody] Request request,
        CancellationToken cancellationToken)
    {
        var robotId = Guid.NewGuid();

        await _handler.Handle(new CreateRobotNotification(simulationId, robotId, request.Name), cancellationToken);
    }
}
