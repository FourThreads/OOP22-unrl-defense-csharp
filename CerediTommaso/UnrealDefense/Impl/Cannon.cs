using MagliaDanilo.UnrealDefense.Api;

namespace CerediTommaso.UnrealDefense.Impl
{
    public sealed class Cannon : Tower
    {
        private const int CnCost = 200;
        private const int CnDamage = 10;
        private const long CnAttackForSecond = 2000;
        public static readonly string CnName = "cannon";
        public static readonly double CnRadius = 20;
        private static readonly double CnExplosionRadius = 5;

        public Cannon() : base(CnName, CnRadius, CnDamage, CnAttackForSecond, CnCost)
        {
        }

        public override Tower Copy() => new Cannon();

        protected override void AdditionalAttack(IEnemy enemy)
        {
            if (enemy.Position == null || ParentWorld == null) return;
            IList<IEnemy> enemiesInRange = ParentWorld.SorroundingEnemies(enemy.Position, CnExplosionRadius);
            if (enemiesInRange.Count > 0)
            {
                foreach (IEnemy e in enemiesInRange)
                {
                    e.ReduceHealth(CnDamage);
                }
            }
        }
    }
}