System.Collections.Generic;

namespace CerediTommaso.UnrealDefense.Impl
{
    /// <summary>
    /// A tower that can be placed in a world.
    /// </summary>
    /// <author> tommaso.ceredi@studio.unibo.it </author>
    public abstract class Tower : DefenseEntity, ITower
    {
        private readonly int cost;
        private Enemy? target;
        
        /// <summary>
        /// Constructor of the tower.
        /// </summary>
        /// <param name="name"> the name of the tower </param>
        /// <param name="radius"> the radius of the tower </param>
        /// <param name="damage"> the damage of the tower </param>
        /// <param name="attackRate"> the attack rate of the tower </param>
        /// <param name="cost"> the cost of the tower </param>
        public Tower(string name, int radius, int damage, int attackRate, int cost) : base(name, radius, damage, attackRate)
        {
            this.cost = cost;
        }
        
        public abstract Tower Copy();
        
        public int Cost => this.cost;

        public void UpdateState(long time)
        {
            this.IncrementTime(time);
            this.CheckAttack();
        }

        protected override void Attack()
        {
            List<Enemy> enemiesInRange = this.ParentWorld.SorroundingEnemies(this.Position.Value, this.Radius);
            if (enemiesInRange.Count > 0)
            {
                if this.target == null || !enemiesInRange.Contains(this.target.Value)
                {
                    this.target = enemiesInRange[0];
                }
                this.target.Value.ReduceHealth(this.Damage);
                this.AdditionalAttack(this.target.Value);
            } else
            {
                this.target = null;
            }
        }
        
        public Enemy? Target => this.target;
        
        protected abstract void AdditionalAttack(Enemy enemy);
    }
}