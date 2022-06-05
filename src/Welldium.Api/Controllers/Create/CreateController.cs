﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Welldium.Application.Notifications;

namespace Welldium.Api.Controllers.Create;

[ApiController]
[Route(Constants.Routes.Simulation)]
public class CreateController : ControllerBase
{
    private readonly INotificationHandler<CreateSimulationNotification> _handler;
    private readonly LinkGenerator _linkGenerator;

    public CreateController(INotificationHandler<CreateSimulationNotification> handler, LinkGenerator linkGenerator)
    {
        _handler = handler;
        _linkGenerator = linkGenerator;
    }

    [HttpPost(Name = Constants.RouteNames.CreateSimulation)]
    public async Task<IActionResult> CreateSimulation(CancellationToken cancellationToken)
    {
        var simulationId = Guid.NewGuid();

        await _handler.Handle(new CreateSimulationNotification(simulationId), cancellationToken);

        var createRobotLink = _linkGenerator.GetPathByName(Constants.RouteNames.CreateRobot, new { simulationId });
        var links = new[]
        {
            new Link(Guid.NewGuid().ToString(), "CreateRobot", createRobotLink!)
        };

        return CreatedAtRoute(Constants.RouteNames.GetSimulation, new { id = simulationId }, links);
    }
}