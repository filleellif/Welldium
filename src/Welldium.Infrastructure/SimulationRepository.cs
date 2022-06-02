using System.Collections.Concurrent;
using Welldium.Domain;

namespace Welldium.Infrastructure;

public class SimulationRepository : ISimulationRepository
{
    private readonly ConcurrentDictionary<Guid, Simulation> _simulations = new ConcurrentDictionary<Guid, Simulation>();

    public Task<Simulation?> Get(Guid id)
    {
        if (_simulations.TryGetValue(id, out var simulation))
        {
            return Task.FromResult<Simulation?>(simulation);
        }

        return Task.FromResult<Simulation?>(null);
    }

    public Task Save(Simulation simulation)
    {
        _simulations.AddOrUpdate(simulation.Id, simulation, (id, existing) =>
        {
            return simulation;
        });

        return Task.CompletedTask;
    }
}
