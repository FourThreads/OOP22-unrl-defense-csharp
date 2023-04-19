using System.Collections.Generic;
using UnrealDefense.Api;

public interface IWorld
{
    public bool TryBuildTower(IPosition pos, string tower);    
    public ISet<IEnemy> SorroundingEnemies(IPosition pos, double radius);
    public IWorld Builder(string name, IPlayer player, IPosition pos, double n1, double n2); 
}