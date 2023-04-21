using BudaFrancesco.UnrealDefense.Impl;
using CerediTommaso.UnrealDefense.Impl;
using MagliaDanilo.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Common;
using MagliaDanilo.UnrealDefense.Impl;

namespace CerediTommasoTest
{
    
    [TestClass]
    class TowerTest
    {
        private World? _testWorld;
        
        [TestInitialize]
        public void Init()
        {
            _testWorld = new World.Builder("testWorld", 1, Hunter.HtCost)
                .Build();
        }
        
        [TestMethod]
        public void TestAttack()
        {
            const int testDamage = 5;
            Position testPosition = new Position(0, 0);
            Tower testTower = new Hunter();
            IEnemy testEnemy = new Enemy("test", testDamage, 0, 0);
            double startingHealth = testEnemy.Health;
            if (_testWorld != null) _testWorld.SpawnEnemy(testEnemy, testPosition);
            testTower.UpdateState(Hunter.HtAttackForSecond);
            Assert.IsTrue(testEnemy.Health < startingHealth);
        }
    }
}

