using MagliaDanilo.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Impl;

namespace CerediTommaso.UnrealDefense.Api
{
    /// <summary>
    /// A tower that can be placed in a world.
    /// </summary>
    /// <author> tommaso.ceredi@studio.unibo.it </author>
    public interface ITower : IEntity
    {
        /// <summary>
        /// The cost of the tower.
        /// </summary>
        /// <returns> the cost of the tower </returns>
        int Cost { get; }
        
        /// <summary>
        /// Create a copy of the tower.
        /// </summary>
        ITower Copy();
        
        /// <summary>
        /// The enemy that the tower is attacking, if any.
        /// </summary>
        Enemy? Target { get; }
    }
}