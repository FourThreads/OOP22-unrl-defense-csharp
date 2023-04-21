using BudaFrancesco.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Impl;

namespace CerediTommaso.UnrealDefense.Impl
{
    public abstract class DefenseEntity : Entity
    {
        private readonly double _radius;
        private readonly int _damage;
        private readonly long _attackRate;
        private long _timeSinceLastAction;
        private bool _isAttacking;
        
        public DefenseEntity(string name, double radius, int damage, long attackRate) : base(name)
        {
            _radius = radius;
            _damage = damage;
            _attackRate = attackRate;
            _timeSinceLastAction = 0;
            _isAttacking = false;
        }
        
        public int Damage { get=>_damage; }
        public double Radius { get=>_radius; }
        public long AttackRate { get=>_attackRate; }
        public bool IsAttacking { get=>_isAttacking; }
        public long TimeSinceLastAction { get=>_timeSinceLastAction; }
        public IWorld? ParentWorld { get; set; }
        
        public void IncrementTime(long amount)
        {
            _timeSinceLastAction += amount;
        }
        
        public void ResetElapsedTime()
        {
            _timeSinceLastAction = 0;
        }

        public void CheckAttack()
        {
            if (_timeSinceLastAction >= _attackRate)
            {
                ResetElapsedTime();
                _isAttacking = true;
                Attack();
            } else
            {
                _isAttacking = false;
            }
        }
        
        protected abstract void Attack();
        
    }
}