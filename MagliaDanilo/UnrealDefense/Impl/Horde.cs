using MagliaDanilo.UnrealDefense.Api;

namespace MagliaDanilo.UnrealDefense.Impl
{
    public class Horde : IHorde
    {
        private readonly List<IEnemy> _enemies;

        public Horde()
        {
            _enemies = new List<IEnemy>();
        }

        public List<IEnemy> GetEnemies()
        {
            return new List<IEnemy>(_enemies);
        }

        public void AddEnemy(IEnemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void AddMultipleEnemies(IEnemy enemy, short numberOfEnemies)
        {
            for (var i = 0; i < numberOfEnemies; i++)
            {
                AddEnemy(enemy);
            }
        }
    }
}