using BudaFrancesco.UnrealDefense.Impl;
using MagliaDanilo.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Common;

namespace BudaFrancesco.UnrealDefense.Api
{
    using System.Collections.Generic;
    public interface IWorld
    {

        void SpawnEnemy(IEnemy enemy, Position pos);

        IList<IEnemy> SorroundingEnemies(Position center, double radius);

        /// <returns> the number of hearts of the castle </returns> 
        int GetHearts();

        /// <returns> the money in the bank </returns>
        double GetMoney();
        
    }
    
}