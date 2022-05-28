namespace Domain.Common;

public abstract record BaseEntity<T>
{
    public virtual T Id { get; init; } = default!;
}
