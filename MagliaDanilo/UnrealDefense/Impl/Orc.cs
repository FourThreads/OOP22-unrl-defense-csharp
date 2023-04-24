

namespace MagliaDanilo.UnrealDefense.Impl;

public class Orc : Enemy
{
    public const string OrcName = "orc";
    public const double OrcSpeed = 2.0;
    public const double OrcHealth = 80.0;
    public const double OrcDrop = 50.0;

    public Orc() : base(OrcName, OrcHealth, OrcSpeed, OrcDrop)
    {
        
    }
}