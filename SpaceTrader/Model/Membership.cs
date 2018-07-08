using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.Model
{
    public class Membership : Entity<ModelState.Membership>
    {
        public Membership(ModelState.Membership state) : base(state)
        {
            Member = new Member(this.State.Member);
        }

        public Membership(string email, string username) : this(new ModelState.Membership { Member = new ModelState.Member { Email = email, Username = username } })
        {
        }

        public Member Member { get; }
    }
}
