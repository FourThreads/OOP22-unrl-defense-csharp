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
        Assert.IsTrue(Math.Abs(testEnemy.Health - (InitialHealth - reduceHealthBy)) < 0.001);
    }

    [TestMethod]
    public void TestSpeedManipulation()
    {
        const double reduceSpeedBy = 2.0;
        IEnemy testEnemy = CreateBaseEnemy();
        testEnemy.Speed = InitialSpeed - reduceSpeedBy;
        Assert.IsTrue(Math.Abs(testEnemy.Speed - (InitialSpeed - reduceSpeedBy)) < 0.001);
        testEnemy.ResetSpeed();
        Assert.IsTrue(Math.Abs(testEnemy.Speed - InitialSpeed) < 0.001);
    }
}