using System.Collections.Generic;

namespace CerediTommaso.UnrealDefense.Impl
{
    public sealed class Connon : Tower
    {
        private const int COST = 200;
        private const int DAMAGE = 10;
        private const long ATTACK_FOR_SECOND = 2000;
        
        public static readonly string NAME = "cannon";
        
        public static readonly double RADIUS = 20;
        
        private static readonly double EXPLOSION_RADIUS = 5;
        
        public Cannon() : base(NAME, RADIUS, DAMAGE, ATTACK_FOR_SECOND, COST)
        {
        }
        
        public override Tower Copy()
        {
            return new Cannon();
        }
        
        protected override void AdditionalAttack(Enemy enemy)
        {
            List<Enemy> enemiesInRange = this.ParentWorld.SorroundingEnemies(enemy.Position.Value, EXPLOSION_RADIUS);
            if (enemiesInRange.Count > 0)
            {
                foreach (Enemy e in enemiesInRange)
                {
                    e.ReduceHealth(this.Damage);
                }
            }
        }
    }