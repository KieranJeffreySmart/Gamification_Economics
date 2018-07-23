namespace Gamifyit.Game.Model
{
    using System.Collections.Generic;

    using Gamifyit.Economics.Model;
    using Gamifyit.Framework.DomainObjects;

    public class Character : Entity<ModelState.Character>
    {
        public Character(ModelState.Character state) : base(state)
        {
            this.Type = new CharacterType(this.State.Type);
            this.Sex = new CharacterSex(this.State.Sex);
            this.Companies = new ValueObjectCollection<EntityIdentity, StateIdentity>(this.State.Companies, EntityIdentity.StateFactory, EntityIdentity.ValueObjectFactory);
            this.Businesses = new ValueObjectCollection<EntityIdentity, StateIdentity>(this.State.Businesses, EntityIdentity.StateFactory, EntityIdentity.ValueObjectFactory);
        }

        public CharacterType Type { get; }
        public CharacterSex Sex { get; }

        public IReadOnlyCollection<EntityIdentity> Companies { get; }
        public IReadOnlyCollection<EntityIdentity> Businesses { get; }

        public void StartNewBusiness(string name)
        {
            var business = new Business(name);
        }
    }
}
