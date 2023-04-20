using System.Globalization;
using System.Runtime.ConstrainedExecution;
using BudaFrancesco.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Api;

namespace BudaFrancesco.UnrealDefense.Impl
{
    public class WorldImpl : IWorld
    {

        private String Name { set; get; }
        private readonly IIntegrity _castleIntegrity;
        private readonly IBank _bank;
        private readonly IList<IEnemy> _livingEnemies;

        public void SpawnEnemy(IEnemy enemy, Position pos)
        {
            throw new NotImplementedException();
        }

        public IList<IEnemy> SorroundingEnemies(Position center, double radius)
        {
            throw new NotImplementedException();
        }

        public int GetHearts()
        {
            throw new NotImplementedException();
        }

        public double GetMoney()
        {
            throw new NotImplementedException();
        }
    }
}