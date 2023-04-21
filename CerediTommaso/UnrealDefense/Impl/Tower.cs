using CerediTommaso.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Impl;

using System.Collections.Generic;
using MagliaDanilo.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Common;

namespace CerediTommaso.UnrealDefense.Impl
{
    /// <summary>
    /// A tower that can be placed in a world.
    /// </summary>
    /// <author> tommaso.ceredi@studio.unibo.it </author>
    public abstract class Tower : DefenseEntity, ITower
    {
        private IEnemy? _target;
        public int Cost { get; }
        public IEnemy? Target { get=>_target; }

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
        
        public abstract ITower Copy();
        

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

        protected abstract void AdditionalAttack(IEnemy enemy);
    }
}