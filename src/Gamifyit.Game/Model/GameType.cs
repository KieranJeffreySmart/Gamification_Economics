namespace Gamifyit.Game.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class GameType : Entity<ModelState.GameType>
    {
        public GameType(ModelState.GameType state)
            : base(state)
        {
            this.CharacterAssets = new ValueObjectCollectionDictionary<LookupItem, EntityIdentity, StateIdentity>(this.State.CharacterAssets, EntityIdentity.StateFactory, EntityIdentity.ValueObjectFactory);
        }

        public ValueObjectCollectionDictionary<LookupItem, EntityIdentity, StateIdentity> CharacterAssets { get; }

        public string Name => this.State.LookupItem.Value;

        public IReadOnlyCollection<LookupItem<long>> Currencies;
    }
}