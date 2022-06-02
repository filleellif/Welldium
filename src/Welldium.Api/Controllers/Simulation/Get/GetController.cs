using Microsoft.AspNetCore.Mvc;
using Welldium.Domain;

namespace Welldium.Api.Controllers.Simulation.Get;

[ApiController]
[Route(Constants.Routes.Simulation)]
public class GetController : ControllerBase
{
    private readonly ISimulationRepository _simulationRepository;

    public GetController(ISimulationRepository simulationRepository)
    {
        _simulationRepository = simulationRepository;
    }

    [HttpGet("{id}", Name = Constants.RouteNames.GetSimulation)]
    public async Task<IActionResult> Create(Guid id)
    {
        var simulation = await _simulationRepository.Get(id);

        return Ok(simulation);
    }
}
