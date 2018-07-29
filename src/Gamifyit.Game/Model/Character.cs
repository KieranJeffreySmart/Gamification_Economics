namespace Gamifyit.Game.Model
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using Gamifyit.Framework.DomainObjects;

    public class Character : Entity<ModelState.Character>
    {
        private readonly ValueObjectDictionary<int, EntityIdentity, StateIdentity> assets;

        public Character(ModelState.Character state) : base(state)
        {
            this.assets = new ValueObjectDictionary<int, EntityIdentity, StateIdentity>(this.State.Assets, EntityIdentity.StateFactory, EntityIdentity.ValueObjectFactory);

        }

        public IReadOnlyDictionary<int, int> Attributes => this.State.Attributes;

        public IReadOnlyDictionary<int, EntityIdentity> Assets => this.assets;
    }
}
