namespace Welldium.Domain;

public class Planet : Entity
{
    public string Name { get; }

    public Planet(Guid id, string name) : base(id)
    {
        Name = name;
    }
}