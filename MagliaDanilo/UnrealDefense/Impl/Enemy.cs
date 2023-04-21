using MagliaDanilo.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Common;

namespace MagliaDanilo.UnrealDefense.Impl;

public class Enemy : Entity, IEnemy
{
    
    private readonly double _defaultSpeed;
    public double Health { get; private set; }
    public double Speed { get; set; }
    public double DropAmount { get; }
    
    public Enemy(string name, double health, double speed, double dropAmount) : base(name)
    {
        Health = health;
        Speed = speed;
        _defaultSpeed = speed;
        DropAmount = dropAmount;
    }

    public override void UpdateState(long time)
    {
        throw new NotImplementedException();
    }


    public void ReduceHealth(double amount)
    {
        Health -= amount;
    }

    public void ResetSpeed()
    {
        Speed = _defaultSpeed;
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

    public bool HasReachedEndOfPath()
    {
        throw new NotImplementedException();
    }

    public void Move(long time)
    {
        throw new NotImplementedException();
    }

    public IEnemy Copy()
    {
        return new Enemy(Name, Health, _defaultSpeed, DropAmount);
    }
}