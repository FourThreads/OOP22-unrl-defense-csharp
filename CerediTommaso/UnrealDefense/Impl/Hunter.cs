using System.Collections.Generic;

namespace CerediTommaso.UnrealDefense.Impl
{
    public sealed class Connon : Tower
    {
        private const int COST = 100;
        private const int DAMAGE = 5;
        private const long ATTACK_FOR_SECOND = 750;
        
        public static readonly string NAME = "hunter";
        
        public static readonly double RADIUS = 15;
        
        private static readonly double EXPLOSION_RADIUS = 5;
        
        public Hunter() : base(NAME, RADIUS, DAMAGE, ATTACK_FOR_SECOND, COST)
        {
        }
        
        public override Tower Copy()
        {
            return new Hunter();
        }

        protected override void AdditionalAttack(Enemy enemy)
        {
        }
    }