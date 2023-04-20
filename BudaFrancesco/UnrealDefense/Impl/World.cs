using System.Collections;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using BudaFrancesco.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Common;

namespace BudaFrancesco.UnrealDefense.Impl
{
    public class World : IWorld
    {

        public String Name { get; }
        private readonly IIntegrity _castleIntegrity;
        private readonly IBank _bank;
        private readonly IList<IEnemy> _livingEnemies;
        
        private World (String name, IIntegrity castleIntegrity, IBank bank) {
            Name = name;
            _castleIntegrity = castleIntegrity;
            _bank = bank;
            _livingEnemies = new List<IEnemy>();
        }

        public void SpawnEnemy(IEnemy enemy, Position pos)
        {
            _livingEnemies.Add(enemy);
            enemy.Position = pos;
        }

        private double distance(Position a, Position b) => Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

        public IList<IEnemy> SorroundingEnemies(Position center, double radius) =>
            _livingEnemies.Where(e => distance(e.Position, center) <= radius).ToList();

        public int GetHearts() => _castleIntegrity.Hearts;

        public double GetMoney() => _bank.Money;
    }
}