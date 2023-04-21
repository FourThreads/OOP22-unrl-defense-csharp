using BudaFrancesco.UnrealDefense.Api;
using MagliaDanilo.UnrealDefense.Common;
using SeveriTommaso.UnrealDefense.Api;

namespace SeveriTommaso.UnrealDefense.Impl
{
    /// <summary>
    /// The main player in a tower defense game.
    /// </summary>
    /// <author> tommaso.severi2@studio.unibo.it </author>
    public sealed class Player : IPlayer
    {
        private IDictionary<string, ISpell> _spells;
        public string Name { get; set; }
        public IWorld? World { get; set; }
        public ISet<ISpell> Spells { get => _spells.Values.ToHashSet(); set => _spells = value.ToDictionary(sp => sp.Name); }

        /// <summary>
        /// Creates a new player.
        /// </summary>
        public Player()
        {
            Name = "";
            World = null;
            _spells = new Dictionary<string, ISpell>();
        }

        public bool BuildTower(Position pos, string towerName)
        {
            return World != null;
                    // Not Implemented
                    // && World.TryBuildTower(pos, towerName);
        }

        public bool ThrowSpell(Position pos, string name) => _spells.ContainsKey(name) && _spells[name].IfPossibleActivate(pos);

        public void UpdateSpellState(long elapsed)
        {
            foreach (ISpell sp in Spells) sp.UpdateState(elapsed);
        }

        /// <returns>the set of active spells</returns>
        public ISet<ISpell> GetActiveSpells() => Spells.Where(sp => sp.IsActive()).ToHashSet();
    }
}
