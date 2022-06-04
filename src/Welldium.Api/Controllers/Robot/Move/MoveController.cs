using MediatR;
using Microsoft.AspNetCore.Mvc;
using Welldium.Application.Notifications;

namespace Welldium.Api.Controllers.Robot.Move;

[ApiController]
[Route(Constants.Routes.Simulation + "/{simulationId}" + Constants.Routes.Robot + "/{robotId}")]
public class MoveController : ControllerBase
{
    private readonly INotificationHandler<AdvanceRobotNotification> _advanceRobotHandler;
    private readonly INotificationHandler<TurnRobotLeftNotification> _turnRobotLeftHandler;
    private readonly INotificationHandler<TurnRobotRightNotification> _turnRobotRightHandler;

    public MoveController(
        INotificationHandler<AdvanceRobotNotification> advanceRobotHandler,
        INotificationHandler<TurnRobotLeftNotification> turnRobotLeftHandler,
        INotificationHandler<TurnRobotRightNotification> turnRobotRightHandler)
    {
        _advanceRobotHandler = advanceRobotHandler;
        _turnRobotLeftHandler = turnRobotLeftHandler;
        _turnRobotRightHandler = turnRobotRightHandler;
    }

    [HttpPost("advance", Name = Constants.RouteNames.AdvanceRobot)]
    public async Task AdvanceRobot(
        Guid simulationId,
        Guid robotId,
        CancellationToken cancellationToken)
    {
        await _advanceRobotHandler.Handle(new AdvanceRobotNotification(simulationId, robotId), cancellationToken);
    }

    [HttpPost("turnleft", Name = Constants.RouteNames.TurnRobotLeft)]
    public async Task TurnRobotLeft(
        Guid simulationId,
        Guid robotId,
        CancellationToken cancellationToken)
    {
        await _turnRobotLeftHandler.Handle(new TurnRobotLeftNotification(simulationId, robotId), cancellationToken);
    }

    [HttpPost("turnright", Name = Constants.RouteNames.TurnRobotRight)]
    public async Task TurnRobotRight(
        Guid simulationId,
        Guid robotId,
        CancellationToken cancellationToken)
    {
        await _turnRobotRightHandler.Handle(new TurnRobotRightNotification(simulationId, robotId), cancellationToken);
    }
}
