using SpaceTrader.Framework;
using SpaceTrader.Framework.DomainObjects;
using SpaceTrader.Framework.Events;
using SpaceTrader.Model.Exceptions;
using SpaceTrader.Repositories;

namespace SpaceTrader.Model
{
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
            if (Membership != null)
            {
                throw new UserAlreadyRegisteredException();
            }

            this.Membership = new Membership(email, username);
            this.membershipRepository.Add(this.Membership);
            this.eventMediator.Publish(new UserRegisteredEvent(this));
        }
    }
}
