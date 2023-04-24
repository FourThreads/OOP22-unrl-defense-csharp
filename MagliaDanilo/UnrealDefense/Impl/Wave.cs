using MagliaDanilo.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Common;

namespace MagliaDanilo.UnrealDefense.Impl
{
    public class Wave : IWave
    {
        private readonly Queue<Pair<IHorde, long>> _hordes;

        public Wave()
        {
            _hordes = new Queue<Pair<IHorde, long>>();
        }
        
        public Pair<IHorde, long> GetNextHorde()
        {
            return _hordes.Dequeue();
        }

        public void AddHorde(IHorde horde, long secondsToSpawn)
        {
            _hordes.Enqueue(new Pair<IHorde, long>(horde, secondsToSpawn));
        }

        public bool IsWaveOver()
        {
            return _hordes.Count == 0;
        }
    }
}