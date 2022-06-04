using MediatR;
using Microsoft.AspNetCore.Mvc;
using Welldium.Application.Notifications;

namespace Welldium.Api.Controllers.Robot.Remove;

[ApiController]
[Route(Constants.Routes.Simulation + "/{simulationId}" + Constants.Routes.Robot + "/{robotId}")]
public class RemoveController : ControllerBase
{
    private readonly INotificationHandler<RemoveRobotNotification> _handler;

    public RemoveController(INotificationHandler<RemoveRobotNotification> handler)
    {
        _handler = handler;
    }

    //[HttpDelete(Name = Constants.RouteNames.RemoveRobot)]
    //public async Task Create(
    //    Guid simulationId,
    //    Guid robotId,
    //    CancellationToken cancellationToken)
    //{
    //    await _handler.Handle(new RemoveRobotNotification(simulationId, robotId), cancellationToken);
    //}
}
