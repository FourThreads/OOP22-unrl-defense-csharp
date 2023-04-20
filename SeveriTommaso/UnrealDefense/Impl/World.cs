using SeveriTommaso.UnrealDefense.Api;

namespace SeveriTommaso.UnrealDefense.Impl;

public class World : IWorld
{
    public IWorld Builder(string name, IPlayer player, IPosition pos, double n1, double n2)
    {
        throw new System.NotImplementedException();
    }

    public ISet<IEnemy> SorroundingEnemies(IPosition pos, double radius)
    {
        return new HashSet<IEnemy>();
    }

    public bool TryBuildTower(IPosition pos, string tower) {
        return true;
    }

    ISet<IEnemy> IWorld.SorroundingEnemies(IPosition pos, double radius)
    {
        throw new System.NotImplementedException();
    }
}