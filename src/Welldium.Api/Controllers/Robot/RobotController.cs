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

    public RobotController(
        INotificationHandler<CreateRobotNotification> createRobotHandler,
        INotificationHandler<RemoveRobotNotification> removeRobotHandler,
        INotificationHandler<MoveRobotNotification> moveRobotHandler)
    {
        _createRobotHandler = createRobotHandler;
        _removeRobotHandler = removeRobotHandler;
        _moveRobotHandler = moveRobotHandler;
    }

    [HttpPost("{simulationId}", Name = Constants.RouteNames.CreateRobot)]
    public async Task CreateRobot(
        Guid simulationId,
        [FromBody] CreateRobotRequest request,
        CancellationToken cancellationToken)
    {
        var robotId = Guid.NewGuid();

        await _createRobotHandler.Handle(new CreateRobotNotification(simulationId, robotId, request.Name), cancellationToken);
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
