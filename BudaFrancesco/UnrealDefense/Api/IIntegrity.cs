namespace BudaFrancesco.UnrealDefense.Api
{
    public interface IIntegrity
    {
        int Hearts { get; }
        void Damage(int val);
        Boolean IsCompromised();
    }
}