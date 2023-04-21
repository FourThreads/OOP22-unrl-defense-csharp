using BudaFrancesco.UnrealDefense.Api;

namespace BudaFrancesco.UnrealDefense.Impl;

public class Integrity : IIntegrity
{
    public int Hearts { get; private set; }

    public Integrity(int value)
    {
        Hearts = value;
    }
    public void Damage(int val)
    {
        var tmp = Hearts - val;
        Hearts = tmp > 0 ? tmp : 0;
    }

    public bool IsCompromised() => Hearts == 0;
}