using MediatR;
using Microsoft.AspNetCore.Mvc;
using Welldium.Application.Notifications;

namespace Welldium.Api.Controllers.Simulation.Robot;

[ApiController]
[Route(Constants.Routes.Simulation)]
public class RobotController : ControllerBase
{
    private readonly INotificationHandler<CreateRobotNotification> _createRobotHandler;
    private readonly INotificationHandler<RemoveRobotNotification> _removeRobotHandler;

    public RobotController(
        INotificationHandler<CreateRobotNotification> createRobotHandler,
        INotificationHandler<RemoveRobotNotification> removeRobotHandler)
    {
        _createRobotHandler = createRobotHandler;
        _removeRobotHandler = removeRobotHandler;
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
}
