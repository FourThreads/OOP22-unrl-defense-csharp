namespace MagliaDanilo.UnrealDefense.Api
{
    public interface IWave
    {
        // Pair<Horde, Long> GetNextHorde();
        void AddHorde(IHorde horde, long secondsToSpawn);
        bool IsWaveOver();
    }
}