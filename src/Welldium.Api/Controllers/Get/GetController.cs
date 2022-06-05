using Microsoft.AspNetCore.Mvc;
using Welldium.ReadModels;

namespace Welldium.Api.Controllers.Get;

[ApiController]
[Route(Constants.Routes.Simulation)]
public class GetController : ControllerBase
{
    private readonly ISimulationQueries _simulationQueries;

    public GetController(ISimulationQueries simulationQueries)
    {
        _simulationQueries = simulationQueries;
    }

    [HttpGet("{simulationId}", Name = Constants.RouteNames.GetSimulation)]
    public async Task<IActionResult> Create(Guid simulationId)
    {
        var simulation = await _simulationQueries.GetSimulation(simulationId);

        return Ok(simulation);
    }
}
