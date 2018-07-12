﻿namespace Gamifyit.Game.Model
{
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model.Exceptions;
    using Gamifyit.Game.Repositories;

    public class User : Entity<ModelState.User>
    {
        private readonly IMembershipRepository membershipRepository;
        private readonly IEventMediator eventMediator;

        public User(ModelState.User state, IMembershipRepository membershipRepository, IEventMediator eventMediator) : this(state)
        {
            this.membershipRepository = membershipRepository;
            this.eventMediator = eventMediator;
        }

        protected User(ModelState.User state) : base(state)
        {
        }

        public Membership Membership { get; private set; }

        public void Register(string email, string username)
        {
            if (this.Membership != null)
            {
                throw new UserAlreadyRegisteredException();
            }

            this.Membership = new Membership(email, username);
            this.membershipRepository.Add(this.Membership);
            this.eventMediator.Publish(new UserRegisteredEvent(this));
        }
    }
}