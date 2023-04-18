public interface IWorld
{
    public bool TryBuildTower(IPosition pos, string tower);    

    public ISet<IEnemy> SorroundingEnemies(IPosition pos, double radius);
}