namespace BudaFrancesco.UnrealDefense.Api
{
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

        /// <summary>
        /// update the state of the world.
        /// </summary> 
        /// <param name='time'> time elapsed since last update </param>
        void UpdateState(long time);

        /// <summary>
        /// try to build a tower in the given position.
        /// </summary>
        /// <param name='pos'> the position where the tower will be built </param>
        /// <param name='towerName'> the name of the tower to build </param>
        /// <returns> true if the tower has been built, false otherwise </returns>
        Boolean TryBuildTower(Position pos, String towerName);

        /// <summary>
        /// spawn an enemy in the given position.
        /// </summary>
        /// <param name='enemy'> the enemy to spawn </param>
        /// <param name='pos'> the position where the enemy will be spawned </param>
        void SpawnEnemy(Enemy enemy, Position pos);

        /// <summary>
        /// the method finds the enemies in the given circle. the firts enemy of the list is the most advanced in the path.
        /// </summary>
        /// <param name='center'> the center of the circle </param>
        /// <param name='radius'> the radius of the circle </param>
        /// <returns> the enemies sorrounding the given position </returns>
        List<Enemy> SorroundingEnemies(Position center, double radius);

        /// <summary>
        /// the method returns all the entities currently present in the world.
        /// enemies are sorted from the one whose y and x coordinates are lowest
        /// to the one whose x and y coordinates are highest.
        /// </summary>
        /// <returns> the list of the entities in the world </returns>
        List<Entity> GetSceneEntities();

        /// <returns> the number of hearts of the castle </returns> 
        int GetHearts();

        /// <returns>  a set of the available positions </returns>
        Set<Position> GetAvailablePositions();

        /// <returns> the money in the bank </returns>
        double GetMoney();

        /// <returns> a set of the available towers </returns>
        Set<Tower> GetAvailableTowers();

        /// <returns> the world's path </returns>
        Path GetPath();

        /// <returns> the game state </returns>
        GameState GetGameState();
    }
}