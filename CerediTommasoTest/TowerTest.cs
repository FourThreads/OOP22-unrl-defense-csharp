using System.Linq;
using CerediTommaso.UnrealDefense.Api;
using CerediTommaso.UnrealDefense.Impl;
using NUnit.Framework;

namespace CerediTommasoTest
{
    [TestClass]
    class TowerTest
    {
        private World testWorld;
        private const long TEST_AFS = 1000;
        private const int TEST_COST = 100;
        
        [Init]
        public void Init()
        {
            this.testWorld = new WorldImpl.Builder("testWorld", new PlayerImpl(), new Position(0, 0), 1, TEST_COST)
                .AddPathSegment(Direction.END, 0)
                .AddAvailableTower(Hunter.NAME, new Hunter())
                .AddTowerBuildingSpace(0,0)
                .Build();
        }

        [Test]
        public void TestAttack()
        {
            const int testDamage = 5;
            Position testPosition = new Position(0, 0);
            this.testWorld.TryBuildTower(testPosition, Hunter.NAME);
            Tower testTower = (Tower)this.testWorld.GetSceneEntities().FirstOrDefault(e => e.Position.Value.Equals(testPosition));
            Enemy testEnemy = new EnemyImpl("test", testDamage, 0, 0);
            double startingHealth = testEnemy.Health;
            this.testWorld.SpawnEnemy(testEnemy, testPosition);
            testTower.UpdateState(TEST_AFS);
            Assert.IsTrue(testEnemy.Health < startingHealth);
        }
    }
}

