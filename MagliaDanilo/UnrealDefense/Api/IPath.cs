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
        
        // Pair<Direction, Double> GetDirection();
        void AddDirection(Direction direction, double unit);
        
        // Position SpawningPoint { get; }
    }
}