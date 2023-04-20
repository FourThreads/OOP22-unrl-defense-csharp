namespace BudaFrancesco.UnrealDefense.Api
{
    public interface IIntegrity
    {
        int Hearts { get; }
        void Damage(int hearts);
        Boolean IsCompromised();
    }
}