public interface IEnemy 
{
    public double Speed();
    public void ReduceHealth(double damage);
    public void SetSpeed(double speed);
    public void ResetSpeed();
}