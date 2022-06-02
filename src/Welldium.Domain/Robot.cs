namespace Welldium.Domain;

public class Robot : Entity
{
    public string Name { get; }

    public Robot(Guid id, string name) : base(id)
    {
        Name = name;
    }
}
