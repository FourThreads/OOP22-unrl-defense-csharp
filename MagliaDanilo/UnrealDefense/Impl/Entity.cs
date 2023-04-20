using MagliaDanilo.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Common;

namespace MagliaDanilo.UnrealDefense.Impl;

public abstract class Entity : IEntity
{
    public Position Position { get; set; }
    public string Name { get; }

    protected Entity(Position position, string name)
    {
        Position = position;
        Name = name;
    }

    public abstract void UpdateState(long time);
}