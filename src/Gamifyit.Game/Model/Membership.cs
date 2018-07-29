namespace Gamifyit.Game.Model
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.CommandQuerySeperation;
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Repositories;

    public class Membership : Entity<ModelState.Membership>
    {
        public Membership(ModelState.Membership state) : base(state)
        {
            this.Member = new Member(this.State.Member);
        }

        public Membership(string email, string username) : this(new ModelState.Membership { Member = new ModelState.Member { Email = email, Username = username } })
        {
        }

        public Member Member { get; }
    }
}
