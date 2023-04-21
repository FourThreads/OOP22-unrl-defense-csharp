using MagliaDanilo.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Common;

namespace MagliaDanilo.UnrealDefense.Impl;

public class Path : IPath
{
    public Position SpawningPoint { get; }
    public Pair<IPath.Direction, double> this[int index] => _path[index];
    
    private readonly List<Pair<IPath.Direction, double>> _path;

    public Path(Position spawningPoint)
    {
        SpawningPoint = spawningPoint;
        _path = new List<Pair<IPath.Direction, double>>();
    }

    public void AddDirection(IPath.Direction direction, double unit)
    {
        _path.Add(new Pair<IPath.Direction, double>(direction, unit));
    }

    
}