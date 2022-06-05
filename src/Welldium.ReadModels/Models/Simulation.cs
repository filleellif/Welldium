namespace Welldium.ReadModels.Models;

public class Simulation
{
    public IEnumerable<Robot> Robots { get; set; } = new List<Robot>();
}

public record Robot
{
    public string Name { get; set; } = string.Empty;
}
