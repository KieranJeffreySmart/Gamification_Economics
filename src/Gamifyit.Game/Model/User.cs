namespace Gamifyit.Game.Model
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Model.Exceptions;
    using Gamifyit.Game.Repositories;

    public class User : Entity<ModelState.User>, IUser
    {
        private readonly IMembershipRepository membershipRepository;

        public User(ModelState.User state, IMembershipRepository membershipRepository) : this(state)
        {
            this.membershipRepository = membershipRepository;
        }

        protected User(ModelState.User state) : base(state)
        {
        }

        public Membership Membership { get; private set; }

        public async Task Register(string email, string username)
        {
            if (this.Membership != null)
            {
                throw new UserAlreadyRegisteredException();
            }

            this.Membership = new Membership(email, username);
            await this.membershipRepository.Add(this.Membership);
        }
    }
}
