using MagliaDanilo.UnrealDefense.Api;

namespace CerediTommaso.UnrealDefense.Impl
{
    public sealed class Hunter : Tower
    {
        /// <summary>
        /// The cost of the tower.
        /// </summary>
        public const int HtCost = 100;
        private const int HtDamage = 5;
        /// <summary>
        /// The attack speed of the tower.
        /// </summary>
        public const long HtAttackForSecond = 750;
        /// <summary>
        /// The name of the tower.
        /// </summary>
        public static readonly string HtName = "hunter";
        /// <summary>
        /// The radius of the tower.
        /// </summary>
        public static readonly double HtRadius = 15;

        /// <summary>
        /// Constructor of the Hunter class.
        /// </summary>
        public Hunter() : base(HtName, HtRadius, HtDamage, HtAttackForSecond, HtCost){}

        public override Tower Copy() => new Hunter();

        protected override void AdditionalAttack(IEnemy enemy) {}
    }
}