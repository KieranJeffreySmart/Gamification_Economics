namespace Gamifyit.Game.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class Member : Entity<ModelState.Member>
    {
        public Member(ModelState.Member state) : base(state)
        {
            this.EmailAddress = new EmailAddress(this.State.Email);
            this.games = new ValueObjectCollection<EntityIdentity, StateIdentity>(this.State.Games, EntityIdentity.StateFactory, EntityIdentity.ValueObjectFactory);
        }

        ValueObjectCollection<EntityIdentity, StateIdentity> games;
 
        public IReadOnlyCollection<EntityIdentity> Games => this.games;

        public EmailAddress EmailAddress { get; }

        public string Username => this.State.Username;

        public void AddGame(EntityIdentity gameIdentity)
        {
            this.games.Add(gameIdentity);
        }
    }
}
