using MagliaDanilo.UnrealDefense.Common;

namespace MagliaDanilo.UnrealDefense.Api
{
    public interface IPath
    {
        enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        
        Pair<Direction, Double> this[int index] { get; }
        void AddDirection(Direction direction, double unit);
        
        Position SpawningPoint { get; }
    }
}