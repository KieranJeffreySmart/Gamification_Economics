using SpaceTrader.Framework.DomainObjects;
using System.Collections.Generic;

namespace SpaceTrader.Model
{
    public class Character : Entity<ModelState.Character>
    {
        public Character(ModelState.Character state) : base(state)
        {
            Companies = new ValueObjectCollection<EntityIdentity, StateIdentity>(this.State.Companies, EntityIdentity.StateFactory, EntityIdentity.ValueObjectFactory);
            Businesses = new ValueObjectCollection<EntityIdentity, StateIdentity>(this.State.Businesses, EntityIdentity.StateFactory, EntityIdentity.ValueObjectFactory);
        }

        public IReadOnlyCollection<EntityIdentity> Companies { get; }
        public IReadOnlyCollection<EntityIdentity> Businesses { get; }

        public void StartNewBusiness(string name)
        {
            var business = new Business(name);
        }
    }
}
