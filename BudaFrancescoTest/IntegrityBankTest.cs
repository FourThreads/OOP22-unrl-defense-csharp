using BudaFrancesco.UnrealDefense.Api;
using BudaFrancesco.UnrealDefense.Impl;

namespace BudaFrancescoTest;

[TestClass]
public class IntegrityBankTest
{
    private readonly IBank _testBank;
    private readonly IIntegrity _testIntegrity;

    public IntegrityBankTest()
    {
        _testBank = new Bank(100);
        _testIntegrity = new Integrity(5);
    }
    
    [TestMethod]
    public void BankTest()
    {
        // Checks that you can't spend more than the money you got in the bank
        Assert.IsFalse(_testBank.TrySpend(300));
        
        // Adds 200 coins to the bank
        _testBank.AddMoney(200);
        
        // Checks that the final amount is 300
        Assert.AreEqual(_testBank.Money, 300);
        
        // Checks that you can spend a part or all the money you got in the bank
        Assert.IsTrue(_testBank.TrySpend(100));
        Assert.IsTrue(_testBank.TrySpend(200));
    }
    
    [TestMethod]
    public void IntegrityTest()
    {
        // Checks that the Integrity isn't compromised while having 5 hearts
        Assert.IsFalse(_testIntegrity.IsCompromised());
        
        // Damages the Integrity and Checks that the new amount of hearts is correct 
        _testIntegrity.Damage(2);
        Assert.AreEqual(_testIntegrity.Hearts, 3);
        
        // Damages the integrity of a higher value than bearable
        // Checks that the new amount of hearts is 0 and the integrity is compromised
        _testIntegrity.Damage(10);
        Assert.AreEqual(_testIntegrity.Hearts, 0);
        Assert.IsTrue(_testIntegrity.IsCompromised());
    }
}