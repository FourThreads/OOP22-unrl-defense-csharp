using BudaFrancesco.UnrealDefense.Api;

namespace BudaFrancesco.UnrealDefense.Impl
{
    public class WorldImpl : IWorld
    {
        private static readonly long SPAWNING_TIME = 1500;
        private static readonly int ENEMY_POWER = 1;
        private static readonly int PATH_DEPHT = 3;
        private static readonly double SAFETY_MARGIN = 0.2;
    

        private String Name { get; set; }
        private IPlayer Player { get; set; }

        public void UpdateState(long time)
        {
            throw new NotImplementedException();
        }

        public bool TryBuildTower(Position pos, string towerName)
        {
            throw new NotImplementedException();
        }

        public void SpawnEnemy(Enemy enemy, Position pos)
        {
            throw new NotImplementedException();
        }

        public List<Enemy> SorroundingEnemies(Position center, double radius)
        {
            throw new NotImplementedException();
        }

        public List<Entity> GetSceneEntities()
        {
            throw new NotImplementedException();
        }

        public int GetHearts()
        {
            throw new NotImplementedException();
        }

        public Set<Position> GetAvailablePositions()
        {
            throw new NotImplementedException();
        }

        public double GetMoney()
        {
            throw new NotImplementedException();
        }

        public Set<Tower> GetAvailableTowers()
        {
            throw new NotImplementedException();
        }

        public Path GetPath()
        {
            throw new NotImplementedException();
        }

        public IWorld.GameState GameState()
        {
            throw new NotImplementedException();
        }
    }
}