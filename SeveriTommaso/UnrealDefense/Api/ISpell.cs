namespace SeveriTommaso.UnrealDefense.Api
{
    /// <summary>
    /// A spell that can be used by a player in a strategic game.
    /// </summary>
    /// <author> tommaso.severi2@studio.unibo.it </author>
    public interface ISpell : IEntity
    {
        /// <returns>true if the spell is being used, false otherwise</returns>
        bool IsActive();

        /// <returns>true if the spell is ready to be used, false otherwise</returns>
        bool IsReady();

        /// <summary>
        /// Tries to set the spell in its activated state, dealing damage and its effect.
        /// </summary>
        /// <param name="position">the desired place to throw th spell at</param>
        bool IfPossibleActivate(IPosition position);
    }
}
