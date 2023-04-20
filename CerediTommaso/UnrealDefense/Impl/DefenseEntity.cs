using System;

namespace CerediTommaso.UnrealDefense.Impl
{
    public abstract class DefenseEntity : Entity
    {
        private readonly double radius;
        private readonly int damage;
        private readonly int attackRate;
        private long timeSinceLastAction;
        private bool isAttacking;
        
        public DefenseEntity(string name, double radius, int damage, int attackRate) : base(name)
        {
            this.radius = radius;
            this.damage = damage;
            this.attackRate = attackRate;
            this.timeSinceLastAction = 0;
            this.isAttacking = false;
        }
        
        public double Radius => this.radius;
        
        public int Damage => this.damage;
        
        public int AttackRate => this.attackRate;
        
        public long TimeSinceLastAction => this.timeSinceLastAction;

        public void IncrementTime(long amount)
        {
            this.timeSinceLastAction += amount;
        }
        
        public void ResetElapsedTime()
        {
            this.timeSinceLastAction = 0;
        }
        
        public void CheckAttack()
        {
            if (this.timeSinceLastAction >= this.attackRate)
            {
                this.ResetElapsedTime();
                this.isAttacking = true;
                this.Attack();
            } else
            {
                this.isAttacking = false;
            }
        }
        
        protected abstract void Attack();
        
        public bool IsAttacking => this.isAttacking;
    }
}