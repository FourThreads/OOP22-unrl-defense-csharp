namespace MagliaDanilo.UnrealDefense.Api
{
    public interface IHorde
    {
        List<IEnemy> Enemies { get; }

        void AddEnemy(IEnemy enemy);
        void AddMultipleEnemies(IEnemy enemy, short numberOfEnemies);
    }
}