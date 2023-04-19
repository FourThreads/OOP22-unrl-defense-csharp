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
        PLAYING,
        /// <summary>
        /// the game is over, and the player won.
        /// </summary>
        VICTORY,
        /// <summary>
        /// the game is over, and the player lost.
        /// </summary>
        DEFEAT
    }

     /// <summary>
     /// update the state of the world.
     /// </summary> 
     /// <param name='time'> time elapsed since last update
    void updateState(long time);

    /// <summary>
    /// try to build a tower in the given position.
    /// </summary>
    /// <param name='pos'> the position where the tower will be built
    /// <param name='towerName'> the name of the tower to build
    /// <returns> true if the tower has been built, false otherwise
    Boolean tryBuildTower(Position pos, String towerName);

    /// <summary>
    /// spawn an enemy in the given position.
    /// </summary>
    /// <param name='enemy'> the enemy to spawn
    /// <param name='pos'> the position where the enemy will be spawned
    void spawnEnemy(Enemy enemy, Position pos);

    /// <summary>
    /// the method finds the enemies in the given circle. the firts enemy of the list is the most advanced in the path.
    /// </summary>
    /// <param name='center'> the center of the circle
    /// <param name='radius'> the radius of the circle
    /// <returns> the enemies sorrounding the given position
    List<Enemy> sorroundingEnemies(Position center, double radius);

    /// <summary>
    /// the method returns all the entities currently present in the world.
    /// enemies are sorted from the one whose y and x coordinates are lowest
    /// to the one whose x and y coordinates are highest.
    /// </summary>
    /// <returns> the list of the entities in the world
    List<Entity> getSceneEntities();

    /// <returns> the number of hearts of the castle
    int getHearts();

    /// <returns>  a set of the available positions
    Set<Position> getAvailablePositions();

    /// <returns> the money in the bank
    double getMoney();

    /// <returns> a set of the available towers
    Set<Tower> getAvailableTowers();

    /// <returns> the world's path
    Path getPath();

    /// <returns> the game state
    GameState gameState();
}