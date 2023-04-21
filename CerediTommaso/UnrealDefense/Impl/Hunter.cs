using MagliaDanilo.UnrealDefense.Api;

namespace CerediTommaso.UnrealDefense.Impl
{
    public sealed class Hunter : Tower
    {
        private const int HtCost = 100;
        private const int HtDamage = 5;
        private const long HtAttackForSecond = 750;

        public static readonly string HtName = "hunter";

        public static readonly double HtRadius = 15;

        public Hunter() : base(HtName, HtRadius, HtDamage, HtAttackForSecond, HtCost){}

        public override Tower Copy() => new Hunter();

        protected override void AdditionalAttack(IEnemy enemy) {}
    }
}