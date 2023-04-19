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

        /// <returns> the number of hearts of the castle </returns> 
        int GetHearts();

        /// <returns>  a set of the available positions </returns>
        Set<IPosition> GetAvailablePositions();

        /// <returns> the money in the bank </returns>
        double GetMoney();

        /// <returns> the game state </returns>
        GameState GetGameState();
    }
}