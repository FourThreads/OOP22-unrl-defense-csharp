using SeveriTommaso.UnrealDefense.Api;
using SeveriTommaso.UnrealDefense.Impl;

namespace SeveriTommasoTest
{
    using UnrealDefense.Api;

    /// <summary>
    /// Test class for SpellImpl.
    /// </summary>
    [TestClass]
    class SpellImplTest
    {
        private const long TestRechargeTime = 3 * 1000;
        private const long TestLingeringEffectTime = 2 * 1000;
        private const long TestLingeringEffectFrequency = 1 * 1000;
        private readonly ISpell _testSpell;
        private readonly IWorld _testWorld;
        
        /// <summary>
        /// Initializes the values before each test.
        /// </summary>
        public SpellImplTest(IWorld testWorld)
        {
            //testWorld = new World.Builder("testWorld", new PlayerImpl(), new Position(0, 0), 0, 0)
            //        .addPathSegment(Direction.END, 0)
            //        .build();
            // The fireball spell is used to initialize the testSpell
            // but this is just an example, the test should work with any spell
            _testSpell = new FireBall();
            _testSpell.ParentWorld = _testWorld;
            _testWorld = testWorld;
        } 
        
        /// <summary>
        /// Test if the activation, attack, effect and deactivation methods work.
        /// </summary>
        [TestMethod]
        public void TestActivation() {
            // Checks if the spell activates before time
            // An empty position is used since it doesn't matter
            IPosition testPosition = new Position(0, 0);
            _testSpell.UpdateState(TestRechargeTime - 1 * 1000);
            Assert.isFalse(_testSpell.IfPossibleActivate(testPosition));
            _testSpell.UpdateState(1 * 1000);
            Assert.IsTrue(_testSpell.IsReady());
            // Once ready it spawns an enemy with the exact amount of health 
            // so that the enemy dies only after all the damage possible is dealt by the spell
            double targetStartingHealth = TEST_DAMAGE 
                    + (TEST_LINGERING_DAMAGE * (TestLingeringEffectTime / TestLingeringEffectFrequency));
            IEnemy testTarget = new Enemy("test", targetStartingHealth, 0, 0);
            _testWorld.SpawnEnemy(testTarget, testPosition);
            // places the spell on the enemy
            Assert.IsTrue(_testSpell.IfPossibleActivate(testTarget.Position()));
            // Checks if the enemy targeted actually took the main damage
            Assert.AreEqual(testTarget.GetHealth(), targetStartingHealth - TEST_DAMAGE);
            // Checks if the enemy targeted actually took the lingering damage
            _testSpell.UpdateState(TestLingeringEffectFrequency);
            Assert.IsEqual(testTarget.GetHealth(), targetStartingHealth - TEST_DAMAGE - TEST_LINGERING_DAMAGE);
            // Cheks if the enemy targeted is dead after the remaining time
            _testSpell.UpdateState(TestLingeringEffectTime - TestLingeringEffectFrequency);
            Assert.IsTrue(testTarget.isDead());
            // After the spell activation time has passed the spell should deactivate
            Assert.IsFalse(_testSpell.isActive());
        }
    }
}
