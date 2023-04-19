using System.Runtime.InteropServices;
using System.Xml.XPath;

namespace BudaFrancesco.UnrealDefense.Api
{
    using System.Collections.Generic;
    public interface IWorld
    {
        /// <summary>
        /// possible states of the world.
        /// </summary>
        enum GameState
        {
            /// <summary>
            /// the game is in progress.
            /// </summary>
            Playing,
            /// <summary>
            /// the game is over, and the player won.
            /// </summary>
            Victory,
            /// <summary>
            /// the game is over, and the player lost.
            /// </summary>
            Defeat
        }

        Boolean TryBuildTower(IPosition pos, String towerName);

        void SpawnEnemy(IEnemy enemy, IPosition pos);

        IList<IEnemy> SorroundingEnemies(IPosition center, double radius);

        IList<IEntity> getSceneEntities();

        /// <returns> the number of hearts of the castle </returns> 
        int GetHearts();

        /// <returns>  a set of the available positions </returns>
        ISet<IPosition> GetAvailablePositions();

        /// <returns> the money in the bank </returns>
        double GetMoney();

        ISet<ITower> GetAvailableTowers();

        IPath getPath();

        /// <returns> the game state </returns>
        GameState GetGameState();
    }
    
}