using BudaFrancesco.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Common;
using MagliaDanilo.UnrealDefense.Impl;
using SeveriTommaso.UnrealDefense.Api;
using SeveriTommaso.UnrealDefense.Impl;

namespace SeveriTommasoTest
{
    /// <summary>
    /// Test class for SpellImpl.
    /// </summary>
    [TestClass]
    class SpellImplTest
    {
        private readonly ISpell _testFireBall;
        private readonly ISpell _testSnowStorm;
        private readonly IWorld _testWorld;
        
        /// <summary>
        /// Initializes the values before each test.
        /// </summary>
        public SpellImplTest()
        {
            //testWorld = new World.Builder("testWorld", new PlayerImpl(), new Position(0, 0), 0, 0)
            //        .addPathSegment(Direction.END, 0)
            //        .build();
            _testFireBall = new FireBall();
            _testSnowStorm = new SnowStorm();
            _testFireBall.ParentWorld = _testWorld;
            _testSnowStorm.ParentWorld = _testWorld;
        }

        /// <summary>
        /// Test if the activation, attack, effect and deactivation methods work.
        /// Fireball is taken as the tested spell but either one works
        /// </summary>
        [TestMethod]
        public void TestActivation() {
            // Checks if the spell activates before time
            // An empty position is used since it doesn't matter
            Position testPosition = new Position(0, 0);
            _testFireBall.UpdateState(FireBall.FbRechargeTime - 1 * 1000);
            Assert.IsFalse(_testFireBall.IfPossibleActivate(testPosition));
            _testFireBall.UpdateState(1 * 1000);
            // Checks if the spell activates after due time
            Assert.IsTrue(_testFireBall.IsReady());
            _testFireBall.UpdateState(FireBall.FbLingeringEffectTime);
            // After the spell activation time has passed the spell should deactivate
            Assert.IsFalse(_testFireBall.IsActive());
        }

        /// <summary>
        /// Test if the fireball effect is applied correctly.
        /// </summary>
        [TestMethod]
        public void TestFireBallEffect()
        {
            _testFireBall.UpdateState(FireBall.FbRechargeTime);
            const double targetStartingHealth = FireBall.FbDmg + (FireBall.FbLingeringDamage * (FireBall.FbLingeringEffectTime / FireBall.FbLingeringEffectFreq));
            IEnemy testTarget = new Enemy("test", targetStartingHealth, 0, 0);
            _testWorld.SpawnEnemy(testTarget, new Position(0,0));
            // places the spell on the enemy
            Assert.IsTrue(_testFireBall.IfPossibleActivate(testTarget.Position));
            // Checks if the enemy targeted actually took the main damage
            Assert.AreEqual(testTarget.Health, targetStartingHealth - FireBall.FbDmg);
            // Checks if the enemy targeted actually took the lingering damage
            _testFireBall.UpdateState(FireBall.FbLingeringEffectFreq);
            Assert.AreEqual(testTarget.Health, targetStartingHealth - FireBall.FbDmg - FireBall.FbLingeringDamage);
            // Checks if the enemy targeted is dead after the remaining time
            _testFireBall.UpdateState(FireBall.FbLingeringEffectTime - FireBall.FbLingeringEffectFreq);
            Assert.IsTrue(testTarget.IsDead());
        }
        
        /// <summary>
        /// Test if the snowstorm effect is applied correctly.
        /// </summary>
        [TestMethod]
        public void TestSnowStormEffect()
        {
            _testSnowStorm.UpdateState(SnowStorm.SnRechargeTime);
            IEnemy testTarget = new Enemy("test", 1, 0, 0);
            const double startingSpeed = testTarget.Speed;
            _testWorld.SpawnEnemy(testTarget, new Position(0,0));
            // places the spell on the enemy
            Assert.IsTrue(_testSnowStorm.IfPossibleActivate(testTarget.Position));
            // Checks if the enemy targeted actually took the lingering effect
            _testSnowStorm.UpdateState(SnowStorm.FbLingeringEffectFreq);
            Assert.AreNotEqual(testTarget.Speed, startingSpeed);
        }
    }
}
