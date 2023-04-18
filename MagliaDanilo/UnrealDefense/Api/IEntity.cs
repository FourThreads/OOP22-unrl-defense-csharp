namespace MagliaDanilo.UnrealDefense.Api
{
    public interface IEntity
    {
        // Position { get; set; }
        string Name { get; }
        // World ParentWorld { get; set; }
        void UpdateState( long time );
    }
}