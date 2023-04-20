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
        public const string FbName = "fireball";

        /// <summary>
        /// The radius of the spell unique to the object type.
        /// </summary>
        public const double FbRad = 6.0;

        private const long FbRechargeTime = 8 * 1000;
        private const double FbDmg = 20.0;
        private const long FbLingeringEffectTime = 5 * 1000;
        private const long FbLingeringEffectFreq = 1 * 1000;

        private const double FbLingeringDamage = 4.0;

        /// <summary>
        /// Creates a new spell of type fireball.
        /// </summary>
        public FireBall() 
                : base(FbName, FbRad, FbDmg, FbRechargeTime, FbLingeringEffectTime, FbLingeringEffectFreq) { }

        protected override void Effect(IEnemy target) => target.ReduceHealth(FbLingeringDamage);

        protected override void ResetEffect() { }
    }
}
