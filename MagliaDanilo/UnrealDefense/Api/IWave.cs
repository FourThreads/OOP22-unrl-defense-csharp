using MagliaDanilo.UnrealDefense.Common;

namespace MagliaDanilo.UnrealDefense.Api
{
    public interface IWave
    {
        Pair<IHorde, long>? GetNextHorde();
        void AddHorde(IHorde horde, long secondsToSpawn);
        bool IsWaveOver();
    }
}