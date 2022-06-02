namespace Welldium.Domain;

public abstract class Entity
{
    public virtual Guid Id { get; protected set; }

    protected Entity(Guid id)
    {
        Id = id;
    }
}