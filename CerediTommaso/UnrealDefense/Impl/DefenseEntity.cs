using BudaFrancesco.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Impl;

namespace CerediTommaso.UnrealDefense.Impl
{
    /// <summary>
    /// A model of a defensive type entity in a strategic game.
    /// </summary>
    /// <author> tommaso.ceredi@studio.unibo.it </author>
    /// <author> tommaso.severi2@studio.unibo.it </author>
    public abstract class DefenseEntity : Entity
    {
        private readonly double _radius;
        private readonly double _damage;
        private readonly long _attackRate;
        private long _timeSinceLastAction;
        private bool _isAttacking;
        
        /// <summary>
        /// Crates a new defensive entinty.
        /// </summary>
        /// <param name="name"> its name </param>
        /// <param name="radius"> the radius it can deal damage from </param>
        /// <param name="damage"> the damage it inflicts to an enemy </param>
        /// <param name="attackRate"> the rate at which it deals damage </param>
        public DefenseEntity(string name, double radius, double damage, long attackRate) : base(name)
        {
            _radius = radius;
            _damage = damage;
            _attackRate = attackRate;
            _timeSinceLastAction = 0;
            _isAttacking = false;
        }
        
        /// <summary>
        /// The damage of the defensive entity.
        /// </summary>
        /// <returns> the damage of the defensive entity </returns>
        public double Damage { get=>_damage; }
        
        /// <summary>
        /// The radius of the defensive entity.
        /// </summary>
        /// <returns> the radius of the defensive entity </returns>
        public double Radius { get=>_radius; }
        
        /// <summary>
        /// The attack rate of the defensive entity.
        /// </summary>
        /// <returns> the radius of the defensive entity </returns>
        public long AttackRate { get=>_attackRate; }
        
        /// <summary>
        /// The check attack method of the defensive entity.
        /// </summary>
        /// <returns> true if the entity is attacking </returns>
        public bool IsAttacking { get=>_isAttacking; }
        
        /// <summary>
        /// The time since the last action of the defensive entity.
        /// </summary>
        /// <returns> the time elapsed since the last action of the entity was performed in milliseconds </returns>
        public long TimeSinceLastAction { get=>_timeSinceLastAction; }
        
        /// <summary>
        /// The parent world of the defensive entity.
        /// </summary>
        /// <returns> the parent world of the defensive entity </returns>
        public IWorld? ParentWorld { get; set; }
        
        /// <summary>
        /// Increase the time elapsed since the last action.
        /// </summary>
        /// <param name="amount"> increase the time elapsed in milliseconds since the last action </param>
        public void IncrementTime(long amount)
        {
            _timeSinceLastAction += amount;
        }
        
        /// <summary>
        /// Reset the time elapsed since the last action.
        /// </summary>
        public void ResetElapsedTime()
        {
            _timeSinceLastAction = 0;
        }

        /// <summary>
        /// Checks if the entity can attack.
        /// </summary>
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
        
        /// <summary>
        /// This method is called when is time to attack.
        /// </summary>
        protected abstract void Attack();
        
    }
}