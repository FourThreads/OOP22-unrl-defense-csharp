using BudaFrancesco.UnrealDefense.Impl;
using CerediTommaso.UnrealDefense.Impl;
using MagliaDanilo.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Common;
using MagliaDanilo.UnrealDefense.Impl;

namespace CerediTommasoTest
{
    /// <summary>
    /// Test class for TowerImpl.
    /// </summary>
    /// <author> tommaso.ceredi@studio.unibo.it </author>
    [TestClass]
    public class TowerTest
    {
        private World? _testWorld;
        
        /// <summary>
        /// Initialize the world.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _testWorld = new World.Builder( 1, Hunter.HtCost)
                .Build();
        }
        
        /// <summary>
        /// Test the attack method.
        /// </summary>
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
            Assert.IsTrue(testEnemy.Health <= startingHealth);
        }
    }
}

