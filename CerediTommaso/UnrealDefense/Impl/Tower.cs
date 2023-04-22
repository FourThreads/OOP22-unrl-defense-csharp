using CerediTommaso.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Api;

namespace CerediTommaso.UnrealDefense.Impl
{
    /// <summary>
    /// A tower that can be placed in a world.
    /// </summary>
    /// <author> tommaso.ceredi@studio.unibo.it </author>
    public abstract class Tower : DefenseEntity, ITower
    {
        private IEnemy? _target;

        /// <summary>
        /// Constructor of the tower.
        /// </summary>
        /// <param name="name"> the name of the tower </param>
        /// <param name="radius"> the radius of the tower </param>
        /// <param name="damage"> the damage of the tower </param>
        /// <param name="attackRate"> the attack rate of the tower </param>
        /// <param name="cost"> the cost of the tower </param>
        public Tower(string name, double radius, int damage, long attackRate, int cost) : base(name, radius, damage, attackRate)
        {
            Cost = cost;
        }
        
        /// <summary>
        /// Create a copy of the tower.
        /// </summary>
        /// <returns> a copy of the tower </returns>
        public abstract ITower Copy();
        
        /// <summary>
        /// The cost of the tower.
        /// </summary>
        /// <returns> the cost of the tower </returns>
        public int Cost { get; }
        
        /// <summary>
        /// The enemy that the tower is attacking, if any.
        /// </summary>
        /// <returns> the enemy that the tower is attacking, if any </returns>
        public IEnemy? Target { get=>_target; }

        public override void UpdateState(long time)
        {
            IncrementTime(time);
            CheckAttack();
        }

        protected override void Attack()
        {
            if (ParentWorld == null || Position == null) return;
            IList<IEnemy> enemiesInRange = ParentWorld.SorroundingEnemies(Position, Radius);
            if (enemiesInRange.Count > 0)
            {
                if (_target == null || !enemiesInRange.Contains(_target))
                {
                    _target = enemiesInRange[0];
                }
                _target.ReduceHealth(this.Damage);
                AdditionalAttack(_target);
            } else
            {
                _target = null;
            }
        }

        /// <summary>
        /// Additional attack of the tower.
        /// </summary>
        /// <param name="enemy"> the enemy that the tower is attacking </param>
        protected abstract void AdditionalAttack(IEnemy enemy);
    }
}