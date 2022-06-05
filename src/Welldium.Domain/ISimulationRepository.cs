namespace Welldium.Domain;

public interface ISimulationRepository
{
    Task<Simulation?> Get(Guid id);

    Task Save(Simulation simulation);
}