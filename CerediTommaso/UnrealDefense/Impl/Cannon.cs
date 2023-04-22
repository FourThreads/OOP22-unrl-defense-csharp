using MagliaDanilo.UnrealDefense.Api;

namespace CerediTommaso.UnrealDefense.Impl
{
    /// <summary>
    /// A tower that can be placed in a world.
    /// </summary>
    /// <author> tommaso.ceredi@studio.unibo.it </author>
    public sealed class Cannon : Tower
    {
        /// <summary>
        /// The cost of the tower.
        /// </summary>
        public const int CnCost = 200;
        private const int CnDamage = 10;
        /// <summary>
        /// The attack speed of the tower.
        /// </summary>
        public const long CnAttackForSecond = 2000;
        /// <summary>
        /// The name of the tower.
        /// </summary>
        public static readonly string CnName = "cannon";
        /// <summary>
        /// The radius of the tower.
        /// </summary>
        public static readonly double CnRadius = 20;
        private static readonly double CnExplosionRadius = 5;

        /// <summary>
        /// Constructor of the Cannon class.
        /// </summary>
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