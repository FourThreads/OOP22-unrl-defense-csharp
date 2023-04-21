namespace MagliaDanilo.UnrealDefense.Impl;

public class Goblin : Enemy
{
    public const string GoblinName = "goblin";
    public const double GoblinSpeed = 2.0;
    public const double GoblinHealth = 80.0;
    public const double GoblinDrop = 50.0;

    public Goblin() : base(GoblinName, GoblinHealth, GoblinSpeed, GoblinDrop)
    {
        
    }
}