namespace Welldium.ReadModels.Models;

public record Robot
{
    public string Name { get; set; } = string.Empty;

    public Area? AssignedArea { get; set; }

    public Point? CurrentPosition { get; set; }

    public bool? IsOutOfBounds { get; set; }
}
