namespace MagliaDanilo.UnrealDefense.Api
{
    public interface IEnemy : IEntity
    {
        double Health { get; }
        double Speed { get; set; }
        double DropAmount { get; }

        void ResetSpeed();
        bool IsDead();
        bool HasReachedEndOfPath();
        void Move( long time );
        IEnemy Copy();
    }
}