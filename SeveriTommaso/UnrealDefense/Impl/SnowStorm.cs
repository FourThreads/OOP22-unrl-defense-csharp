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

        private const long SnRechargeTime = 6 * 1000;
        private const double SnDmg = 0.0;
        private const long SnLingeringEffectTime = 6 * 1000;
        private const long SnLingeringEffectFreq = 500;

        private const double SnSpeedReduction = 0.2;
        private readonly ISet<IEnemy> _enemiesEffected = new HashSet<IEnemy>();

        /// <summary>
        /// Creates a new spell of type ice.
        /// </summary>
        public SnowStorm() 
            : base(SnName, SnRad, SnDmg, SnRechargeTime, SnLingeringEffectTime, SnLingeringEffectFreq) { }

        protected override void Effect(IEnemy target) {
            target.SetSpeed(target.Speed() - (target.Speed() * SnSpeedReduction));
            _enemiesEffected.Add(target);
        }

        protected override void ResetEffect()
        {
            foreach (IEnemy e in _enemiesEffected) e.ResetSpeed();
            _enemiesEffected.Clear();
        }
    }
}
