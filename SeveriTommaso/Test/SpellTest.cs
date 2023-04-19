namespace TestProject
{
    using UnrealDefense.Api;
    using UnrealDefense.Impl;

    /// <summary>
    /// Test class for SpellImpl.
    /// </summary>
    [TestClass]
    class SpellImplTest
    {
        private static readonly double TEST_RADIUS = 5;
        private static readonly double TEST_DAMAGE = 4;
        private static readonly long TEST_LINGERING_DAMAGE = 1;
        private readonly long _testRechargeTime = 3 * 1000;
        private readonly long _testLingeringEffectTime = 2 * 1000;
        private readonly long _testLingeringEffectFrequency = 1 * 1000;
        private ISpell _testSpell;
        private IWorld _testWorld;

        /// <summary>
        /// Initializes the values before each test.
        /// </summary>
        [SetUp]
        public void init() {
            //testWorld = new World.Builder("testWorld", new PlayerImpl(), new Position(0, 0), 0, 0)
            //        .addPathSegment(Direction.END, 0)
            //        .build();
            // The fireball spell is used to initialize the testSpell
            // but this is just an example, the test should work with any spell
            _testSpell = new FireBall();
            _testSpell.ParentWorld = _testWorld;
        }

        /// <summary>
        /// Test if the activation, attack, effect and deactivation methods work.
        /// </summary>
        [Test]
        public void testActivation() {
            // Checks if the spell activates before time
            // An empty position is used since it doesn't matter
            IPosition testPosition = new Position(0, 0);
            _testSpell.UpdateState(_testRechargeTime - 1 * 1000);
            Assert.isFalse(_testSpell.IfPossibleActivate(testPosition));
            _testSpell.UpdateState(1 * 1000);
            Assert.IsTrue(_testSpell.IsReady());
            // Once ready it spawns an enemy with the exact amount of health 
            // so that the enemy dies only after all the damage possible is dealt by the spell
            double targetStartingHealth = TEST_DAMAGE 
                    + (TEST_LINGERING_DAMAGE * (_testLingeringEffectTime / _testLingeringEffectFrequency));
            IEnemy testTarget = new Enemy("test", targetStartingHealth, 0, 0);
            _testWorld.SpawnEnemy(testTarget, testPosition);
            // places the spell on the enemy
            Assert.IsTrue(_testSpell.IfPossibleActivate(testTarget.Position()));
            // Checks if the enemy targeted actually took the main damage
            Assert.AreEqual(testTarget.GetHealth(), targetStartingHealth - TEST_DAMAGE);
            // Checks if the enemy targeted actually took the lingering damage
            _testSpell.UpdateState(_testLingeringEffectFrequency);
            Assert.IsEqual(testTarget.GetHealth(), targetStartingHealth - TEST_DAMAGE - TEST_LINGERING_DAMAGE);
            // Cheks if the enemy targeted is dead after the remaining time
            _testSpell.UpdateState(_testLingeringEffectTime - _testLingeringEffectFrequency);
            Assert.IsTrue(testTarget.isDead());
            // After the spell activation time has passed the spell should deactivate
            Assert.IsFalse(_testSpell.isActive());
        }
    }
}
