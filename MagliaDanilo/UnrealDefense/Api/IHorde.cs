namespace MagliaDanilo.UnrealDefense.Api
{
    public interface IHorde
    {
        List<IEnemy> GetEnemies();
        void AddEnemy(IEnemy enemy);
        void AddMultipleEnemies(IEnemy enemy, short numberOfEnemies);
    }
}