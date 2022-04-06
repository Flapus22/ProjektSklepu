namespace BD;

public interface IEntityWithName<Type> : IEntity<Type>
{
    public Type Id { get; set; }
    public string Name { get; set; }
}



