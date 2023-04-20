using System.Collections;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using BudaFrancesco.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Api;

namespace BudaFrancesco.UnrealDefense.Impl
{
    public class WorldImpl : IWorld
    {

        public String Name { get; }
        private readonly IIntegrity _castleIntegrity;
        private readonly IBank _bank;
        private readonly IList<IEnemy> _livingEnemies;
        
        private WorldImpl (String name, IIntegrity castleIntegrity, IBank bank) {
            Name = name;
            _castleIntegrity = castleIntegrity;
            _bank = bank;
            _livingEnemies = new List<IEnemy>();
        }

        public void SpawnEnemy(IEnemy enemy, Position pos)
        {
            _livingEnemies.Add(enemy);
            enemy.setPosition(pos.X, pos.Y);
        }

        private double distance(Position a, Position b) => Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

        public IList<IEnemy> SorroundingEnemies(Position center, double radius) =>
            _livingEnemies.Where(e => distance(e.getPosition(), center) <= radius);

        public int GetHearts() => _castleIntegrity.Hearts;

        public double GetMoney() => _bank.Money;
    }
}