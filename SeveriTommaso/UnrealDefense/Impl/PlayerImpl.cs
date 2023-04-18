namespace SeveriTommaso.UnrealDefense.Impl
{
    using System.Collections.Generic;
    using SeveriTommaso.UnrealDefense.Api;

    /// <summary>
    /// The main player in a tower defense game.
    /// </summary>
    /// <author> tommaso.severi2@studio.unibo.it
    public sealed class PlayerImpl : IPlayer
    {
        private IDictionary<string, ISpell> _spells;
        public string Name { get; set; }
        public IWorld World { get; set; }
        public ISet<ISpell> Spells { get => _spells.Values.ToHashSet(); set => _spells = value.ToDictionary(sp => sp.Name); }

        /// <summary>
        /// Creates a new player.
        /// </summary>
        public PlayerImpl()
        {
            Name = "";
            World = new WorldImpl();
            _spells = new Dictionary<string, ISpell>();
        }

        public bool BuildTower(IPosition pos, string towerName) => World.TryBuildTower(pos, towerName);

        public bool ThrowSpell(IPosition pos, String name) => _spells.ContainsKey(name) && _spells[name].IfPossibleActivate(pos);

        public void UpdateSpellState(long elapsed)
        {
            foreach (ISpell sp in Spells)
            {
                sp.UpdateState(elapsed);
            }
        }

        /// <returns>the set of active spells</returns>
        public ISet<ISpell> GetActiveSpells() => (ISet<ISpell>)Spells.Select(sp => sp.IsActive).ToHashSet();
    }
}