using MediatR;
using Microsoft.AspNetCore.Mvc;
using Welldium.Application.Notifications;

namespace Welldium.Api.Controllers.Robot;

[ApiController]
[Route(Constants.Routes.Simulation)]
public class RobotController : ControllerBase
{
    private readonly INotificationHandler<CreateRobotNotification> _createRobotHandler;
    private readonly INotificationHandler<RemoveRobotNotification> _removeRobotHandler;
    private readonly INotificationHandler<MoveRobotNotification> _moveRobotHandler;
    private readonly LinkGenerator _linkGenerator;

    public RobotController(
        INotificationHandler<CreateRobotNotification> createRobotHandler,
        INotificationHandler<RemoveRobotNotification> removeRobotHandler,
        INotificationHandler<MoveRobotNotification> moveRobotHandler,
        LinkGenerator linkGenerator)
    {
        _createRobotHandler = createRobotHandler;
        _removeRobotHandler = removeRobotHandler;
        _moveRobotHandler = moveRobotHandler;
        _linkGenerator = linkGenerator;
    }

    [HttpPost("{simulationId}", Name = Constants.RouteNames.CreateRobot)]
    public async Task<IActionResult> CreateRobot(
        Guid simulationId,
        [FromBody] CreateRobotRequest request,
        CancellationToken cancellationToken)
    {
        var robotId = Guid.NewGuid();

        var links = new[]
        {
            new Link("RemoveRobot", _linkGenerator.GetPathByName(Constants.RouteNames.RemoveRobot, new { simulationId, robotId })),
            new Link("MoveRobot", _linkGenerator.GetPathByName(Constants.RouteNames.MoveRobot, new { simulationId, robotId })),
        };

        await _createRobotHandler.Handle(new CreateRobotNotification(simulationId, robotId, request.Name), cancellationToken);

        return Ok(new { Links = links });
    }

    [HttpDelete("{simulationId}/{robotId}", Name = Constants.RouteNames.RemoveRobot)]
    public async Task RemoveRobot(
        Guid simulationId,
        Guid robotId,
        CancellationToken cancellationToken)
    {
        await _removeRobotHandler.Handle(new RemoveRobotNotification(simulationId, robotId), cancellationToken);
    }

    [HttpPost("{simulationId}/{robotId}/move", Name = Constants.RouteNames.MoveRobot)]
    public async Task MoveRobot(
        Guid simulationId,
        Guid robotId,
        [FromBody] MoveRobotRequest request,
        CancellationToken cancellationToken)
    {
        var notification = request.ToNotification(simulationId, robotId);
        await _moveRobotHandler.Handle(notification, cancellationToken);
    }
}
