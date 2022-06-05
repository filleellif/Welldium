namespace Welldium.ReadModels.Models;

public class Simulation
{
    public IEnumerable<Robot> Robots { get; set; } = new List<Robot>();
}
