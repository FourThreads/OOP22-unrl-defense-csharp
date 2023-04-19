using System.Collections.Generic;

namespace UnrealDefense.Api
{
    /// <summary>
    /// A player in a strategic game where his position is irrelevant and spells can
    /// be used
    /// </summary>
    /// <author> tommaso.severi2@studio.unibo.it </author>
    public interface IPlayer
    {
        /// <summary>
        /// The name of the player.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The current world.
        /// </summary>
        IWorld World { get; set; }

        /// <summary>
        /// The player's spells.
        /// </summary>
        ISet<ISpell> Spells { get; set; }

        /// <summary>
        /// Places a new tower on the world map if the player has enough money.
        /// </summary>
        /// <param name="pos">the position where to place it</param>
        /// <param name="towerName">the type of tower to build</param>
        /// <returns>true if the tower has been built, false otherwise</returns>
        bool BuildTower(IPosition pos, string towerName);

        /// <summary>
        /// Places a new spell on the world map effecting enemies.
        /// </summary>
        /// <param name="pos">the position where to place it</param>
        /// <param name="name">the type of spell to throw</param>
        /// <returns>true if the spell has been thrown, false otherwise</returns>
        bool ThrowSpell(IPosition pos, string name);

        /// <summary>
        /// Updates the state of the spells.
        /// </summary>
        /// <param name="elapsed">time passed since last update</param>
        void UpdateSpellState(long elapsed);
    }
}
