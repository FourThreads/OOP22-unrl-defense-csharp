public class World : IWorld
{
    public ISet<IEnemy> SorroundingEnemies(IPosition pos, double radius)
    {
        return new HashSet<IEnemy>();
    }

    public bool TryBuildTower(IPosition pos, string tower) {
        return true;
    }
}