using SeveriTommaso.UnrealDefense.Api;

namespace SeveriTommaso.UnrealDefense.Impl;

public abstract class DefenseEntity : IEntity
{
    public string Name { get; set; }
    protected double Radius { get; set; }
    protected double Damage { get; set; }
    public long RechargeTime { get; set; }
    public IPosition Position { get; set; }
    public IWorld ParentWorld { get; set; }
    public long AttackRate { get; set; }
    public long TimeSinceLastAction { get; set; }

    protected DefenseEntity(string name, double radius, double damage, long rechargeTime)
    {
        Name = name;
        Radius = radius;
        Damage = damage;
        RechargeTime = rechargeTime;
    }

    public abstract void UpdateState(long elapsed);

    public void ResetElapsedTime() { }

    protected static void CheckAttack() { }

    public void IncrementTime(long elapsed) { }
}