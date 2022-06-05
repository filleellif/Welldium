using Welldium.ReadModels.Models;

namespace Welldium.ReadModels;

public interface ISimulationQueries
{
    Task<Simulation?> GetSimulation(Guid simulationId);
}
