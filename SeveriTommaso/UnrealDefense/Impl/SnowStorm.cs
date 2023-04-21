using MagliaDanilo.UnrealDefense.Api;

namespace SeveriTommaso.UnrealDefense.Impl
{
    /// <summary>
    /// An ice spell used in a tower defense game to slow down enemies.
    /// </summary>
    /// <author> tommaso.severi2@studio.unibo.it </author>
    public sealed class SnowStorm : Spell
    {
        /// <summary>
        /// The name of the spell unique to the object type.
        /// </summary>
        public const string SnName = "snow_storm";

        /// <summary>
        /// The radius of the spell unique to the object type.
        /// </summary>
        public const double SnRad = 7.0;

        /// <summary>
        /// The recharge time taken by the snowstorm
        /// </summary>
        public const long SnRechargeTime = 6 * 1000;
        
        /// <summary>
        /// The damage inflicted by snowstorm
        /// </summary>
        public const double SnDmg = 0.0;
        
        /// <summary>
        /// The lingering effect time
        /// </summary>
        public const long SnLingeringEffectTime = 6 * 1000;
        
        /// <summary>
        /// The frequency the effect is dealt by snowstorm
        /// </summary>
        public const long SnLingeringEffectFreq = 500;

        /// <summary>
        /// The speed reduction inflicted by snowstorm
        /// </summary>
        public const double SnSpeedReduction = 0.2;
        
        private readonly ISet<IEnemy> _enemiesEffected = new HashSet<IEnemy>();

        /// <summary>
        /// Creates a new spell of type ice.
        /// </summary>
        public SnowStorm() 
            : base(SnName, SnRad, SnDmg, SnRechargeTime, SnLingeringEffectTime, SnLingeringEffectFreq) { }

        protected override void Effect(IEnemy target) {
            target.Speed = target.Speed - (target.Speed * SnSpeedReduction);
            _enemiesEffected.Add(target);
        }

        protected override void ResetEffect()
        {
            foreach (IEnemy e in _enemiesEffected) e.ResetSpeed();
            _enemiesEffected.Clear();
        }
    }
}
