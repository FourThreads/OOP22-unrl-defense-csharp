namespace SeveriTommaso.UnrealDefense.Impl
{
    /**
    * A fireball spell that can be used in a tower defense game.
    * 
    * @author tommaso.severi2@studio.unibo.it
    */
    /// <summary>
    /// A fireball spell that can be used in a tower defense game.
    /// </summary>
    /// <author> tommaso.severi2@studio.unibo.it </author>
    public sealed class FireBall : Spell
    {
        /// <summary>
        /// The name of the spell unique to the object type.
        /// </summary>
        public static string NAME = "fireball";
        /// <summary>
        /// The radius of the spell unique to the object type.
        /// </summary>
        public static readonly double RAD = 6.0;
        private static readonly long RECHARGE_TIME = 8 * 1000;
        private static readonly double DMG = 20.0;
        private static readonly long LINGERING_EFFECT_TIME = 5 * 1000;
        private static readonly long LINGERING_EFFECT_FREQ = 1 * 1000;

        private static readonly double LINGERING_DAMAGE = 4.0;

        /// <summary>
        /// Creates a new spell of type fireball.
        /// </summary>
        public FireBall() 
                : base(NAME, RAD, DMG, RECHARGE_TIME, LINGERING_EFFECT_TIME, LINGERING_EFFECT_FREQ) { }

        protected override void Effect(IEnemy target) => target.ReduceHealth(LINGERING_DAMAGE);

        protected override void ResetEffect() { }
    }
}
