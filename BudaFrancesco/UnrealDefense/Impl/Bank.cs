using BudaFrancesco.UnrealDefense.Api;

namespace BudaFrancesco.UnrealDefense.Impl;

public class Bank : IBank
{
    public double Money { get; private set; }
    public void AddMoney(double money)
    {
        Money += money;
    }

    public bool TrySpend(double price)
    {
        if (Money >= price)
        {
            Money -= price;
            return true;
        }
        return false;
    }
}