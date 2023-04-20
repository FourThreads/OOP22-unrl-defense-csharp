namespace BudaFrancesco.UnrealDefense.Api
{
    public interface IBank
    {
        double Money { get; }
        void AddMoney(double money);
        Boolean TrySpend(double price);
    }
}