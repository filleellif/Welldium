using Welldium.Domain;
using Welldium.ReadModels.Extensions;

namespace Welldium.ReadModels;

public class SimulationQueries : ISimulationQueries
{
    private readonly ISimulationRepository _simulationRepository;

    public SimulationQueries(ISimulationRepository simulationRepository)
    {
        _simulationRepository = simulationRepository;
    }

    public async Task<Models.Simulation?> GetSimulation(Guid simulationId)
    {
        var simulation = await _simulationRepository.Get(simulationId);

        return simulation?.FromDomain();
    }
}
