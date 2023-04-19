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
        public static readonly string NAME = "snow_storm";
        /// <summary>
        /// The radius of the spell unique to the object type.
        /// </summary>
        public static readonly double RAD = 7.0;
        private static readonly long RECHARGE_TIME = 6 * 1000;
        private static readonly double DMG = 0.0;
        private static readonly long LINGERING_EFFECT_TIME = 6 * 1000;
        private static readonly long LINGERING_EFFECT_FREQ = 500;

        private static readonly double SPEED_REDUCTION = 0.2;
        private readonly ISet<IEnemy> enemiesEffected = new HashSet<IEnemy>();

        /// <summary>
        /// Creates a new spell of type ice.
        /// </summary>
        public SnowStorm() 
            : base(NAME, RAD, DMG, RECHARGE_TIME, LINGERING_EFFECT_TIME, LINGERING_EFFECT_FREQ) { }

        protected override void Effect(IEnemy target) {
            target.SetSpeed(target.Speed() - (target.Speed() * SPEED_REDUCTION));
            enemiesEffected.Add(target);
        }

        protected override void ResetEffect() {
            foreach (IEnemy e in enemiesEffected) {
                e.ResetSpeed();
            }
            enemiesEffected.Clear();
        }
    }
}
