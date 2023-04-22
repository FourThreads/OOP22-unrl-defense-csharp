using MagliaDanilo.UnrealDefense.Common;
using SeveriTommaso.UnrealDefense.Api;
using SeveriTommaso.UnrealDefense.Impl;

namespace SeveriTommasoTest
{
    [TestClass]
    public class PlayerTest
    {
        private readonly Player _testPlayer;
        
        /// <summary>
        /// Initializes the values before each test.
        /// </summary>
        public PlayerTest()
        {
            _testPlayer = new Player();
        }

        /// <summary>
        /// Tests if the spells are correctly handled by the player.
        /// </summary>
        [TestMethod]
        public void ThrowSpellTest()
        {
            // Creates a new Spell Set and gives it to the player
            ISet<ISpell> testSpells = new HashSet<ISpell>();
            testSpells.Add(new FireBall());
            testSpells.Add(new SnowStorm());
            _testPlayer.Spells = testSpells;
            // Updates the spell with a value sure to activate both spells
            _testPlayer.UpdateSpellState(FireBall.FbRechargeTime + SnowStorm.SnRechargeTime);
            foreach (ISpell sp in _testPlayer.Spells) Assert.IsTrue(sp.IsReady());
            // Throws the spells and checks if they are active
            _testPlayer.ThrowSpell(new Position(0, 0), FireBall.FbName);
            _testPlayer.ThrowSpell(new Position(0, 0), SnowStorm.SnName);
            foreach (ISpell sp in _testPlayer.Spells) Assert.IsTrue(sp.IsActive());
        }
    }
}