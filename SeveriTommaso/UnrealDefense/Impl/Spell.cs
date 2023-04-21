using CerediTommaso.UnrealDefense.Impl;
using MagliaDanilo.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Common;
using SeveriTommaso.UnrealDefense.Api;

namespace SeveriTommaso.UnrealDefense.Impl
{
    /// <summary>
    /// Implementation of a generic spell in a tower defense game.
    /// </summary>
    /// <author> tommaso.severi2@studio.unibo.it </author>
    public abstract class Spell : DefenseEntity, ISpell
    {
        private bool _active;
        private long _lingerTime;
        private readonly long _lingeringEffectTime;
        private readonly long _lingeringEffectFrequency;

        /// <summary>
        /// Creates a new spell.
        /// </summary>
        /// <param name="name">the name of the spell</param>
        /// <param name="radius">the radius of the spell</param>
        /// <param name="damage">the damage of the spell</param>
        /// <param name="rechargeTime">the recharge time of the spell</param>
        /// <param name="lingeringEffectTime">the time the spell will be active</param>
        /// <param name="lingeringEffectFrequency">the frequency in which the effect is applied</param>
        protected Spell(string name, double radius, double damage, long rechargeTime, 
                long lingeringEffectTime, long lingeringEffectFrequency) 
                : base(name, radius, damage, rechargeTime)
        {
            _lingeringEffectTime = lingeringEffectTime;
            _lingeringEffectFrequency = lingeringEffectFrequency;
            _active = false;
            _lingerTime = 0;
        }
        
        public bool IsActive() => _active;

        public bool IsReady() => TimeSinceLastAction >= AttackRate && !IsActive();

        public bool IfPossibleActivate(Position position) {
            if (!IsActive() && IsReady()) {
                Activate();
                Position = position;
                CheckAttack();
                return true;
            }
            return false;
        }

        protected override void Attack()
        {
            if (ParentWorld == null || Position == null) return;
            foreach (IEnemy e in ParentWorld.SorroundingEnemies(Position, Radius))
            {
                e.ReduceHealth(Damage);
            }
        }

        public override void UpdateState(long time) {
            IncrementTime(time);
            if (IsActive()) {
                _lingerTime += time;
                IfPossibleApplyEffect();
            }
        }

        /// <summary>
        /// Activates the spell.
        /// </summary>
        private void Activate() => _active = true;

        /// <summary>
        /// Sets the spell back to its waiting state after dealing damage.
        /// </summary>
        private void Deactivate() {
            _active = false;
            _lingerTime = 0;
            ResetElapsedTime();
            ResetEffect();
        }

        /// <summary>
        /// Applies the effect of the spell to the enemies in range if possible.
        /// </summary>
        private void IfPossibleApplyEffect() {
            if (ParentWorld == null || Position == null) return;
            if (_lingerTime >= _lingeringEffectFrequency) {
                foreach (IEnemy e in ParentWorld.SorroundingEnemies(Position, Radius))
                {
                    Effect(e);
                }
                this._lingerTime -= this._lingeringEffectFrequency;
            }
            if (TimeSinceLastAction >= this._lingeringEffectTime) {
                Deactivate();
            }
        }

        /// <summary>
        /// The effect of the spell while lingering.
        /// </summary>
        /// <param name="target">the target to apply the effect to</param>
        protected abstract void Effect(IEnemy target);

        /// <summary>
        /// Resets the effect applied by the spell after deactivating.
        /// </summary>
        protected abstract void ResetEffect();
    }
}
