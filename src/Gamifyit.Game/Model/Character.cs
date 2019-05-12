namespace Gamifyit.Game.Model
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;

    public class Character : Entity<ModelState.Character>, ICharacter
    {
        private readonly ValueObjectCollection<EntityIdentity, StateIdentity> assets;

        private readonly ValueObjectCollection<EntityIdentity, StateIdentity> accounts;

        public Character(ModelState.Character state) : base(state)
        {
            this.assets = new ValueObjectCollection<EntityIdentity, StateIdentity>(this.State.Assets, EntityIdentity.StateFactory, EntityIdentity.ValueObjectFactory);
            this.accounts = new ValueObjectCollection<EntityIdentity, StateIdentity>(this.State.Accounts, EntityIdentity.StateFactory, EntityIdentity.ValueObjectFactory);
        }

        public IReadOnlyDictionary<int, int> Attributes => this.State.Attributes;

        public IReadOnlyCollection<EntityIdentity> Assets => this.assets;

        public IReadOnlyCollection<EntityIdentity> Accounts => this.accounts;

        public decimal NetWorth => this.State.NetWorth;
    }

    public interface ICharacter
    {
        IReadOnlyDictionary<int, int> Attributes { get; }

        IReadOnlyCollection<EntityIdentity> Assets { get; }

        IReadOnlyCollection<EntityIdentity> Accounts { get; }

        decimal NetWorth { get; }
    }
}
