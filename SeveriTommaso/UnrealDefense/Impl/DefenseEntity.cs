using UnrealDefense.Api;

public abstract class DefenseEntity : IEntity
{
    public string Name { get; set; }
    public double Radius { get; set; }
    public double Damage { get; set; }
    public long RechargeTime { get; set; }
    public IPosition Position { get; set; }
    public IWorld ParentWorld { get; set; }
    public long AttackRate { get; set; }
    public long TimeSinceLastAction { get; set; }

    public DefenseEntity(string name, double radius, double damage, long rechargeTime)
    {
        Name = name;
        Radius = radius;
        Damage = damage;
        RechargeTime = rechargeTime;
    }

    public abstract void UpdateState(long elapsed);

    public void ResetElapsedTime() { }

    public void CheckAttack() { }

    public void IncrementTime(long elapsed) { }
}