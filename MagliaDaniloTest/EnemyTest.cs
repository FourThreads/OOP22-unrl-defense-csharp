using System.Diagnostics;
using MagliaDanilo.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Impl;

namespace MagliaDaniloTest;

[TestClass]
public class EnemyTest
{
    private const double InitialHealth = 50.0;
    private const double InitialSpeed = 5.0;
    private const double InitialDropAmount = 10.0;
    

    private IEnemy CreateBaseEnemy()
    {
        return new Enemy("test", InitialHealth, InitialSpeed, InitialDropAmount);
    }
    
    [TestMethod]
    public void TestReduceHealth()
    {
        const double reduceHealthBy = 10.0;
        IEnemy testEnemy = CreateBaseEnemy();
        testEnemy.ReduceHealth(reduceHealthBy);
        Assert.IsTrue(testEnemy.Health == (InitialHealth - reduceHealthBy));
    }

    [TestMethod]
    public void TestSpeedManipulation()
    {
        const double reduceSpeedBy = 2.0;
        IEnemy testEnemy = CreateBaseEnemy();
        testEnemy.Speed = InitialSpeed - reduceSpeedBy;
        Assert.IsTrue(testEnemy.Speed == (InitialSpeed - reduceSpeedBy));
        testEnemy.ResetSpeed();
        Assert.IsTrue(testEnemy.Speed == InitialSpeed);
    }
}